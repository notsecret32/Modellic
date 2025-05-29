using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture;
using Modellic.App.Core.Services;
using Modellic.App.Enums;
using Modellic.App.Exceptions;
using Modellic.App.Extensions;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.UI.Forms
{
    public partial class MainForm : Form
    {
        #region Private Members

        private FixtureManager _fixtureManager;

        #endregion

        #region Constructors

        public MainForm()
        {
            Logger.LogInformation("Начало инициализации формы");

            // Инициализируем компоненты
            InitializeComponent();

            // Инициализируем сервисы
            InitializeServices();

            // Инициализируем состояние элементов управления
            InitializeControls();

            Logger.LogInformation("Форма проинициализирована");
        }

        #endregion

        #region Form Event Handlers

        private void BtnCursorUp_Click(object sender, EventArgs e) => _fixtureManager.CursorUp();

        private void BtnCursorDown_Click(object sender, EventArgs e) => _fixtureManager.CursorDown();

        #endregion

        #region Async Form Event Handlers

        private async void BtnBuildStep_Click(object sender, EventArgs e) => await BuildStepAsync();

        private async void MenuItemConnectToSw_Click(object sender, EventArgs e) => await HandleSwConnectionAsync();

        private async void MenuItemOpenAssemblyExample_Click(object sender, EventArgs e) 
            => await OpenExampleAsync((ToolStripMenuItem)sender, isAssembly: true);
        private async void MenuItemOpenPartExample_Click(object sender, EventArgs e)
             => await OpenExampleAsync((ToolStripMenuItem)sender, isAssembly: false);

        #endregion

        #region Private Methods

        private bool AskRetry(string message) 
            => MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private void AttachActiveDocument()
        {
            if (ModellicEnv.Application.ActiveDocument != null)
            {
                _fixtureManager.AttachDocument(ModellicEnv.Application.ActiveDocument);
            }
        }

        private AssemblyExampleType GetAssemblyExampleType(string tag) => tag switch
        {
            "StopExample" => AssemblyExampleType.Stop,
            "AssemblyExample" => AssemblyExampleType.Assembly,
            _ => throw new ResourceManagerException($"Неизвестный тег: {tag}",
                ResourceManagerErrorCode.InvalidAssemblyTag)
        };

        private string GetButtonText(FixtureStepStatus status) => status switch
        {
            FixtureStepStatus.NotBuilded => "Построить",
            FixtureStepStatus.Building => "В процессе",
            FixtureStepStatus.Builded => "Построено",
            _ => "Перестроить" // Для Cancel, Error, ValidationFailed
        };

        private PartExampleType GetPartExampleType(string tag) => tag switch
        {
            "PartExample" => PartExampleType.Part,
            "FixtureExample" => PartExampleType.Fixture,
            "PlatformExample" => PartExampleType.Platform,
            _ => throw new ResourceManagerException($"Неизвестный тег: {tag}",
                ResourceManagerErrorCode.InvalidPartTag)
        };

        private void InitializeControls()
        {
            Logger.LogInformation("Инициализация элементов управления");

            menuItemConnectToSw.Enabled = !ModellicEnv.ApplicationManager.IsConnected;
            menuItemDisconnectFromSw.Enabled = ModellicEnv.ApplicationManager.IsConnected;

            // Инициализация состояния кнопок при старте
            btnBuildStep.Enabled = false;
            btnChangeStep.Enabled = false;
            btnClearStep.Enabled = false;

            Logger.LogInformation("Элементы управления проинициализированы");
        }

        private void InitializeServices()
        {
            _fixtureManager = new FixtureManager(stepsGridView);
            _fixtureManager.CursorPositionChanged += OnCursorPositionChanged;
            _fixtureManager.FixtureStepStatusChanged += OnFixtureStepStatusChanged;
        }

        private void SetUiState(bool isConnecting)
        {
            this.SafeInvoke(() =>
            {
                menuItemConnectToSw.Enabled = !isConnecting && !ModellicEnv.ApplicationManager.IsConnected;
                Cursor = isConnecting ? Cursors.WaitCursor : Cursors.Default;
            });
        }

        private void ShowErrorMessage(string title, string message)
            => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ShowInfoMessage(string message)
            => MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void UpdateButtonsState(FixtureStepStatus status)
        {
            this.SafeInvoke(() =>
            {
                var isBuilding = status == FixtureStepStatus.Building;
                var isBuilt = status == FixtureStepStatus.Builded;

                btnBuildStep.Enabled = !isBuilding && !isBuilt;
                btnChangeStep.Enabled = isBuilt;
                btnClearStep.Enabled = isBuilt;
                btnBuildStep.Text = GetButtonText(status);
            });
        }

        private void VerifyActiveDocument()
        {
            if (ModellicEnv.Application.ActiveDocument == null)
            {
                throw new InvalidOperationException("Нет активного документа");
            }
        }

        #endregion

        #region Private Async Methods

        private async Task BuildStepAsync()
        {
            try
            {
                await VerifySwConnectionAsync();
                VerifyActiveDocument();

                UpdateButtonsState(FixtureStepStatus.Building);
                await _fixtureManager.BuildStepAsync();
            }
            catch (OperationCanceledException)
            {
                ShowInfoMessage("Построение шага отменено");
            }
            catch (InvalidOperationException ex) when (AskRetry(ex.Message))
            {
                await HandleSwConnectionAsync();
            }
            catch (FixtureBuilderException ex)
            {
                ShowErrorMessage("Непредвиденная ошибка", ex.Message);
            }
        }

        private async Task HandleSwConnectionAsync()
        {
            try
            {
                SetUiState(isConnecting: true);

                await ModellicEnv.ApplicationManager.ConnectAsync();
                AttachActiveDocument();

                Logger.LogInformation("Подключение к SolidWorks успешно");
            }
            catch (SolidWorksException ex)
            {
                Logger.LogError($"Ошибка подключения: {ex.Details.ErrorMessage}");

                if (AskRetry(ex.Details.ErrorMessage))
                    await HandleSwConnectionAsync();
            }
            finally
            {
                SetUiState(isConnecting: false);
            }
        }

        private async Task OpenExampleAsync(ToolStripMenuItem menuItem, bool isAssembly)
        {
            try
            {
                await VerifySwConnectionAsync();

                string fullPath;

                if (isAssembly)
                {
                    var type = GetAssemblyExampleType(menuItem.Tag.ToString());
                    fullPath = ResourceManager.GetAssemblyExampleFullPath(type);
                }
                else
                {
                    var type = GetPartExampleType(menuItem.Tag.ToString());
                    fullPath = ResourceManager.GetPartExampleFullPath(type);
                }

                Logger.LogInformation($"Открытие примера: {fullPath}");

                var (_, Error, Warning) = await ModellicEnv.Application.OpenDocumentAsync(
                    fullPath,
                    isAssembly ? SwDocumentType.Assembly : SwDocumentType.Part);

                Logger.LogInformation($"Результат: Ошибка={Error}, Предупреждение={Warning}");
            }
            catch (ResourceManagerException ex)
            {
                ShowErrorMessage("Ошибка ресурсов", ex.Message);
            }
        }

        private async Task VerifySwConnectionAsync()
        {
            if (!ModellicEnv.ApplicationManager.IsConnected &&
                AskRetry("Нет подключения к SolidWorks. Подключиться?"))
            {
                await HandleSwConnectionAsync();
            }
        }

        #endregion

        #region Event Callbacks

        private void OnCursorPositionChanged(FixtureStep step, int cursorPosition)
        {
            UpdateButtonsState(step.Status);
        }

        private void OnFixtureStepStatusChanged(FixtureStep step, FixtureStepStatus status)
        {
            UpdateButtonsState(status);
        }

        #endregion
    }
}