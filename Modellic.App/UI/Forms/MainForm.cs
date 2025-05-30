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

        private bool _isCreatingDocument;

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

        private DialogResult AskYesNo(string message)
            => MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            _ => "Перестроить"
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

            // Кнопка построения шага активна при старте
            btnBuildStep.Enabled = true;
            btnBuildStep.Text = "Построить";

            // Остальные кнопки неактивны
            btnChangeStep.Enabled = false;
            btnClearStep.Enabled = false;

            // Состояние меню подключения
            menuItemConnectToSw.Enabled = !ModellicEnv.ApplicationManager.IsConnected;
            menuItemDisconnectFromSw.Enabled = ModellicEnv.ApplicationManager.IsConnected;

            Logger.LogInformation("Элементы управления проинициализированы");
        }

        private void InitializeServices()
        {
            _fixtureManager = new FixtureManager(stepsGridView);
            _fixtureManager.CursorPositionChanged += OnCursorPositionChanged;
            _fixtureManager.FixtureStepStatusChanged += OnFixtureStepStatusChanged;
        }

        private void SetUiState(bool isBusy, string busyText = null)
        {
            this.SafeInvoke(() =>
            {
                if (isBusy)
                {
                    btnBuildStep.Enabled = false;
                    btnChangeStep.Enabled = false;
                    btnClearStep.Enabled = false;

                    if (!string.IsNullOrEmpty(busyText))
                    {
                        btnBuildStep.Text = busyText;
                    }
                }
                else
                {
                    UpdateButtonsState(_fixtureManager.CurrentStep?.Status ?? FixtureStepStatus.NotBuilded);
                }

                Cursor = isBusy ? Cursors.WaitCursor : Cursors.Default;
            });
        }

        private void ShowErrorMessage(string message, string title = "Непредвиденная ошибка")
            => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ShowInfoMessage(string message)
            => MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void UpdateButtonsState(FixtureStepStatus status)
        {
            this.SafeInvoke(() =>
            {
                var isBuilding = status == FixtureStepStatus.Building;
                var isBuilt = status == FixtureStepStatus.Builded;
                var canBuild = !isBuilding && !isBuilt && !_isCreatingDocument;

                btnBuildStep.Enabled = canBuild;
                btnBuildStep.Text = GetButtonText(status);

                btnChangeStep.Enabled = isBuilt && !_isCreatingDocument;
                btnClearStep.Enabled = isBuilt && !_isCreatingDocument;
            });
        }

        #endregion

        #region Private Async Methods

        private async Task BuildStepAsync()
        {
            try
            {
                if (!await EnsureSwConnectionAsync())
                {
                    return;
                }

                if (!_fixtureManager.HasWorkingDocument)
                {
                    _isCreatingDocument = true;
                    SetUiState(isBusy: true, "Создание файла...");

                    Logger.LogInformation("FixtureManager не имеет рабочего файла, создадим его");

                    var createdDocument = await ModellicEnv.Application.CreatePartDocument();

                    Logger.LogInformation($"Создан документ модели \"{createdDocument.Name}\"");

                    _fixtureManager.WorkingDocument = createdDocument;
                    _isCreatingDocument = false;
                }

                SetUiState(true);

                await _fixtureManager.BuildStepAsync();
            }
            catch (OperationCanceledException)
            {
                ShowInfoMessage("Построение шага отменено");
            }
            catch (InvalidOperationException ex) when (AskYesNo(ex.Message) == DialogResult.Yes)
            {
                await HandleSwConnectionAsync();
            }
            catch (FixtureBuilderException ex)
            {
                ShowErrorMessage(ex.Message);
            }
            catch (SolidWorksException ex)
            {
                ShowErrorMessage(ex.Message);
            }
            finally
            {
                SetUiState(false);
                _isCreatingDocument = false;
            }
        }

        private async Task<bool> EnsureSwConnectionAsync()
        {
            if (VerifySwConnection()) return true;

            if (AskYesNo("Нет подключения к SolidWorks. Подключиться?") == DialogResult.Yes)
            {
                await HandleSwConnectionAsync();
                return VerifySwConnection();
            }

            Logger.LogInformation("Пользователь отказался подключаться к SolidWorks");
            return false;
        }

        private async Task HandleSwConnectionAsync()
        {
            try
            {
                SetUiState(true);

                await ModellicEnv.ApplicationManager.ConnectAsync();

                Logger.LogInformation("Подключение к SolidWorks успешно");
            }
            catch (SolidWorksException ex)
            {
                Logger.LogError($"Ошибка подключения: {ex.Details.ErrorMessage}");

                if (AskYesNo(ex.Details.ErrorMessage) == DialogResult.Yes)
                    await HandleSwConnectionAsync();
            }
            finally
            {
                SetUiState(false);
            }
        }

        private async Task OpenExampleAsync(ToolStripMenuItem menuItem, bool isAssembly)
        {
            try
            {
                SetUiState(true);

                if (!await EnsureSwConnectionAsync())
                {
                    return;
                }

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
            finally
            {
                SetUiState(false);
            }

        }

        private bool VerifySwConnection() => ModellicEnv.ApplicationManager.IsConnected;

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