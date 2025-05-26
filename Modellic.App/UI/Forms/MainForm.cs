using Microsoft.Extensions.Logging;
using Modellic.App.Core.Services;
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

        private void BtnBuildStep_Click(object sender, EventArgs e)
        {
            _fixtureManager.BuildStep();
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