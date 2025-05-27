using Microsoft.Extensions.Logging;
using Modellic.App.Core.Services;
using Modellic.App.Enums;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Documents;
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

        private readonly StepsGridViewService _stepsGridViewService;

        #endregion

        #region Constructors

        public MainForm()
        {
            Logger.LogInformation("Начало инициализации формы");

            // Инициализируем компоненты
            InitializeComponent();

            // Получаем FixtureBuilder
            FixtureBuilder fixtureBuilder = ModellicEnv.FixtureBuilder;

            // Инициализируем сервис по работе с StepsGridView
            _stepsGridViewService = new StepsGridViewService(fixtureBuilder, stepsGridView);

            // Инициализируем менеджер сборки приспособления
            _fixtureManager = new FixtureManager(fixtureBuilder, _stepsGridViewService);

            // Инициализируем состояние элементов управления
            InitializeControls();

            // Пробуем подписаться на события сразу
            SubscribeToSwEvents();

            Logger.LogInformation("Форма проинициализирована");
        }

        #endregion

        #region Destructor

        ~MainForm()
        {
            UnsubscribeFromSwEvents();
        }

        #endregion

        #region Form Event Handlers

        private async void MenuItemConnectToSw_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Попытка подключиться к SolidWorks");

            await HandleConnectToSw();
        }

        private async void BtnBuildStep_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogInformation("Проверяем подключение перед выполнением операции");

                if (!ModellicEnv.ApplicationManager.IsConnected)
                {
                    Logger.LogWarning("Приложение не подключено, выбрасываем ошибку");

                    throw new InvalidOperationException("Нет подключения к SolidWorks. Подключить?");
                }

                // Обновляем состояние кнопок
                UpdateControlsOnBuildStep(true);

                // Строим шаг
                await _fixtureManager.BuildStepAsync();

                Logger.LogInformation("Приложение подключено, выполняем операцию");
            }
            catch (InvalidOperationException ex)
            {
                if (MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await HandleConnectToSw();
                }
            }
            catch (FixtureBuilderException ex) when (ex.ErrorCode == FixtureBuilderErrorCode.PreviousStepNotBuilded || ex.ErrorCode == FixtureBuilderErrorCode.AlreadyBuilded)
            {
                MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FixtureBuilderException ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Возвращаем обратно
                UpdateControlsOnBuildStep(false);
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

        #endregion

        #region Application Event Handlers

        private void OnActiveDocumentChanged(SwModelDoc newActiveDoc)
        {
            Logger.LogInformation($"Новый активный документ: \"{newActiveDoc.Name}\"");
        }

        #endregion

        #region Application Event Helpers

        /// <summary>
        /// Метод для подписки к событиям приложения SolidWorks.
        /// </summary>
        private void SubscribeToSwEvents()
        {
            Logger.LogInformation("Пробуем подписаться на события приложения SolidWorks");

            if (ModellicEnv.Application == null || !ModellicEnv.ApplicationManager.IsConnected)
            {
                Logger.LogInformation("Приложение SolidWorks еще не проинициализировано, пропускаем");
                return;
            }

            Logger.LogInformation("Приложение SolidWorks проинициализировано, подписываемся на события");

            ModellicEnv.Application.ActiveDocumentChanged += OnActiveDocumentChanged;
        }

        /// <summary>
        /// Метод для отписки от событиий приложения SolidWorks.
        /// </summary>
        private void UnsubscribeFromSwEvents()
        {
            Logger.LogInformation("Пробуем отписаться на события приложения SolidWorks");

            if (ModellicEnv.Application == null || !ModellicEnv.ApplicationManager.IsConnected)
            {
                Logger.LogInformation("Приложение SolidWorks еще не проинициализировано, пропускаем");
                return;
            }

            Logger.LogInformation("Отписываемся от событий приложения SolidWorks");

            ModellicEnv.Application.ActiveDocumentChanged -= OnActiveDocumentChanged;
        }

        #endregion

        #region Private Methods

        private void InitializeControls()
        {
            Logger.LogInformation("Начало инициализации элементов управления");

            menuItemConnectToSw.Enabled = !ModellicEnv.ApplicationManager.IsConnected;
            menuItemDisconnectFromSw.Enabled = ModellicEnv.ApplicationManager.IsConnected;

            Logger.LogInformation("Элементы управления проинициализированы");
        }

        private void UpdateControls()
        {
            Logger.LogInformation("Обновлеям элементы управления");

            menuItemConnectToSw.Enabled = !ModellicEnv.ApplicationManager.IsConnected;
            menuItemConnectToSw.CheckState = ModellicEnv.ApplicationManager.IsConnected ? CheckState.Checked : CheckState.Unchecked;
            menuItemDisconnectFromSw.Enabled = ModellicEnv.ApplicationManager.IsConnected;

            Logger.LogInformation("Элементы управления обновлены");
        }

        private void UpdateControlsOnBuildStep(bool disable)
        {
            // Обновляем состояние курсора
            _fixtureManager.FreezeCursor = disable;

            // btnBuildStep
            btnBuildStep.Text = !disable ? "Построить" : "Отменить";

            // btnChangeStep
            btnChangeStep.Enabled = !disable;

            // btnClearStep
            btnClearStep.Enabled = !disable;

            // btnStartAssembly
            btnStartAssembly.Enabled = !disable;
        }

        private async Task HandleConnectToSw()
        {
            try
            {
                // Обновляем состояние UI элементов до подключения
                menuItemConnectToSw.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Подключаемся к SolidWorks
                await ModellicEnv.ApplicationManager.ConnectAsync();

                // Подписываемся на события
                SubscribeToSwEvents();

                Logger.LogInformation("Подключение к SolidWorks прошло успешно");
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