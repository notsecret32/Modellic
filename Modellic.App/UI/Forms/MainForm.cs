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
        #region Private Readonly Members

        private readonly FixtureManager _fixtureManager;

        #endregion

        #region Constructors

        public MainForm()
        {
            Logger.LogInformation("Начало инициализации формы");

            // Инициализируем компоненты
            InitializeComponent();

            // Инициализируем менеджер сборки приспособления
            _fixtureManager = new FixtureManager(stepsGridView);

            // Подписываемся на событие
            _fixtureManager.CursorPositionChanged += OnCursorPositionChanged;
            _fixtureManager.FixtureStepStatusChanged += OnFixtureStepStatusChanged;

            // Инициализируем состояние элементов управления
            InitializeControls();

            Logger.LogInformation("Форма проинициализирована");
        }

        #endregion

        #region Form Event Handlers

        private async void MenuItemConnectToSw_Click(object sender, EventArgs e)
        {
            await HandleConnectToSw();
        }

        private async void BtnBuildStep_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsApplicationConnected())
                {
                    throw new InvalidOperationException("Нет подключения к SolidWorks. Подключить?");
                }

                // Проверяем наличие рабочего файла
                if (!HasActiveDocument())
                {
                    return;
                }

                UpdateButtonsState(FixtureStepStatus.Building);

                await _fixtureManager.BuildStepAsync();
            }
            catch (OperationCanceledException)
            {
                Logger.LogInformation("Построение шага было отменено пользователем");
                MessageBox.Show("Построение шага отменено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                if (MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await HandleConnectToSw();
                }
            }
            catch (FixtureBuilderException ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCursorUp_Click(object sender, EventArgs e)
        {
            _fixtureManager.CursorUp();
        }

        private void BtnCursorDown_Click(object sender, EventArgs e)
        {
            _fixtureManager.CursorDown();
        }

        private async void MenuItemOpenPartExample_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsApplicationConnected())
                {
                    if (MessageBox.Show("Приложение не подключено к SolidWorks. Подключиться?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    await HandleConnectToSw();
                }

                var menuItem = (ToolStripMenuItem)sender;
                var exampleName = GetPartExampleTypeByTag((string)menuItem.Tag);
                var fullPathToExample = ResourceManager.GetPartExampleFullPath(exampleName);

                Logger.LogInformation($"Пробуем открыть пример: {fullPathToExample}");

                var (_, Error, Warning) = await ModellicEnv.Application.OpenDocumentAsync(fullPathToExample, SwDocumentType.Part);

                Logger.LogInformation($"Операция завершена (Ошибка: {Error}; Предупреждение: {Warning})");
            }
            catch (ResourceManagerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void MenuItemOpenAssemblyExample_Click(object sender, EventArgs e)
        {
            try { 
                if (!IsApplicationConnected())
                {
                    if (MessageBox.Show("Приложение не подключено к SolidWorks. Подключиться?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    await HandleConnectToSw();
                }

                var menuItem = (ToolStripMenuItem)sender;
                var exampleName = GetAssemblyExampleTypeByTag((string)menuItem.Tag);
                var fullPathToExample = ResourceManager.GetAssemblyExampleFullPath(exampleName);

                Logger.LogInformation($"Пробуем открыть пример: {fullPathToExample}");

                var (_, Error, Warning) = await ModellicEnv.Application.OpenDocumentAsync(fullPathToExample, SwDocumentType.Assembly);

                Logger.LogInformation($"Операция завершена (Ошибка: {Error}; Предупреждение: {Warning})");
            }
            catch (ResourceManagerException ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        #endregion

        #region Private Event Handlers

        private void OnCursorPositionChanged(FixtureStep step, int cursorPosition)
        {
            UpdateButtonsState(step.Status);
        }

        private void OnFixtureStepStatusChanged(FixtureStep step, FixtureStepStatus status)
        {
            UpdateButtonsState(status);
        }

        #endregion

        #region Private Methods

        private void AttachDocumentToFixtureManager()
        {
            if (HasActiveDocument())
            {
                var activeDocument = ModellicEnv.Application.ActiveDocument;
                _fixtureManager.AttachDocument(activeDocument);
            }
        }

        private string GetBuildStepButtonText(FixtureStepStatus status) => status switch
        {
            FixtureStepStatus.NotBuilded => "Построить",
            FixtureStepStatus.Building => "В процессе",
            FixtureStepStatus.Builded => "Построено",
            FixtureStepStatus.Cancel => "Перестроить",
            FixtureStepStatus.Error => "Перестроить",
            FixtureStepStatus.ValidationFailed => "Перестроить",
            _ => throw new InvalidOperationException("Необработанный случай")
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

        private bool IsApplicationConnected()
        {
            bool isConnected = ModellicEnv.ApplicationManager.IsConnected;
            Logger.LogInformation($"SolidWorks {(isConnected ? "подключен" : "не подключен")}");
            return isConnected;
        }

        private bool HasActiveDocument()
        {
            bool hasDoc = ModellicEnv.Application.ActiveDocument != null;
            Logger.LogInformation($"{(hasDoc ? "Есть активный документ" : "Нет активного документа")}");
            return hasDoc;
        }

        private void UpdateButtonsState(FixtureStepStatus status)
        {
            this.SafeInvoke(() =>
            {
                Logger.LogInformation($"Обновляем кнопки, когда статус = {status}");

                if (status == FixtureStepStatus.Building)
                {
                    btnBuildStep.Enabled = false;
                    btnChangeStep.Enabled = false;
                    btnClearStep.Enabled = false;
                    btnBuildStep.Text = "В процессе";
                    return;
                }

                bool isBuilt = status == FixtureStepStatus.Builded;

                btnBuildStep.Enabled = !isBuilt;
                btnChangeStep.Enabled = isBuilt;
                btnClearStep.Enabled = isBuilt;

                btnBuildStep.Text = GetBuildStepButtonText(status);
            });
        }

        private void UpdateControls()
        {
            this.SafeInvoke(() =>
            {
                Logger.LogInformation("Обновляем элементы управления");

                bool isConnected = ModellicEnv.ApplicationManager.IsConnected;

                menuItemConnectToSw.Enabled = !isConnected;
                menuItemConnectToSw.CheckState = isConnected ? CheckState.Checked : CheckState.Unchecked;
                menuItemDisconnectFromSw.Enabled = isConnected;

                UpdateButtonsState(_fixtureManager.CurrentStep.Status);

                Logger.LogInformation("Элементы управления обновлены");
            });
        }

        private PartExampleType GetPartExampleTypeByTag(string tag)
        {
            return tag switch
            {
                "PartExample" => PartExampleType.Part,
                "FixtureExample" => PartExampleType.Fixture,
                "PlatformExample" => PartExampleType.Platform,
                _ => throw new ResourceManagerException($"Необработанный тэг {tag} примера детали.", ResourceManagerErrorCode.InvalidPartTag)
            };
        }

        private AssemblyExampleType GetAssemblyExampleTypeByTag(string tag)
        {
            return tag switch
            {
                "StopExample" => AssemblyExampleType.Stop,
                "AssemblyExample" => AssemblyExampleType.Assembly,
                _ => throw new ResourceManagerException($"Необработанный тэг {tag} примера сборки.", ResourceManagerErrorCode.InvalidAssemblyTag)
            };
        }

        #endregion

        #region Private Async Methods

        private async Task HandleConnectToSw()
        {
            try
            {
                Logger.LogInformation("Пробуем подключиться к SolidWorks");

                // Обновляем состояние UI элементов до подключения
                menuItemConnectToSw.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Подключаемся к SolidWorks
                await ModellicEnv.ApplicationManager.ConnectAsync();

                Logger.LogInformation("Подключено успешно");

                // Передаем активный документ
                AttachDocumentToFixtureManager();
            }
            catch (SolidWorksException ex)
            {
                Logger.LogError($"Ошибка подключения к SolidWorks. Подробности: {ex.Details.ErrorMessage}");

                var result = MessageBox.Show(
                    ex.Details.ErrorMessage,
                    "Ошибка подключения",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    await HandleConnectToSw();
                }
            }
            finally
            {
                // Обновляем состояние UI элементов после попытки подключиться
                UpdateControls();

                // Возвращаем курсор в дефолтное состояние
                Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}