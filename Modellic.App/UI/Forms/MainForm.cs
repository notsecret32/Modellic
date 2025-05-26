using Microsoft.Extensions.Logging;
using Modellic.App.Core.Services;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Application;
using Modellic.App.SolidWorks.Documents;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App
{
    public partial class MainForm : Form
    {
        #region Private Members

        private readonly AssemblyManager _assemblyManager = AssemblyManager.Instance;

        private readonly SwApplicationManager _applicationManager = SwApplicationManager.Instance;

        #endregion

        #region Constructors

        public MainForm()
        {
            Logger.LogInformation("Начало инициализации формы");

            // Инициализируем компоненты
            InitializeComponent();

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

        private void BtnStartAssembly_Click(object sender, EventArgs e)
        {
            _assemblyManager.Build();
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

            if (_applicationManager.Application == null || !_applicationManager.IsConnected)
            {
                Logger.LogInformation("Приложение SolidWorks еще не проинициализировано, пропускаем");
                return;
            }

            Logger.LogInformation("Приложение SolidWorks проинициализировано, подписываемся на события");

            _applicationManager.Application.ActiveDocumentChanged += OnActiveDocumentChanged;
        }

        /// <summary>
        /// Метод для отписки от событиий приложения SolidWorks.
        /// </summary>
        private void UnsubscribeFromSwEvents()
        {
            Logger.LogInformation("Пробуем отписаться на события приложения SolidWorks");

            if (_applicationManager.Application == null || !_applicationManager.IsConnected)
            {
                Logger.LogInformation("Приложение SolidWorks еще не проинициализировано, пропускаем");
                return;
            }

            Logger.LogInformation("Отписываемся от событий приложения SolidWorks");

            _applicationManager.Application.ActiveDocumentChanged -= OnActiveDocumentChanged;
        }

        #endregion

        #region Private Methods

        private void InitializeControls()
        {
            Logger.LogInformation("Начало инициализации элементов управления");

            menuItemConnectToSw.Enabled = !_applicationManager.IsConnected;
            menuItemDisconnectFromSw.Enabled = _applicationManager.IsConnected;

            Logger.LogInformation("Элементы управления проинициализированы");
        }

        private void UpdateControls()
        {
            Logger.LogInformation("Обновлеям элементы управления");

            menuItemConnectToSw.Enabled = !_applicationManager.IsConnected;
            menuItemConnectToSw.CheckState = _applicationManager.IsConnected ? CheckState.Checked : CheckState.Unchecked;
            menuItemDisconnectFromSw.Enabled = _applicationManager.IsConnected;

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
                await _applicationManager.ConnectAsync();

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