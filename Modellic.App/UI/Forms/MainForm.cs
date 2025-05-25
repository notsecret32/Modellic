using Microsoft.Extensions.Logging;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Application;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App
{
    public partial class MainForm : Form
    {
        #region Private Members

        private readonly SwApplicationManager _applicationManager = SwApplicationManager.Instance;

        #endregion

        #region Constructors

        public MainForm()
        {
            Logger.LogInformation("Начало инициализации формы");

            InitializeComponent();
            InitializeControls();

            Logger.LogInformation("Форма проинициализирована");
        }

        #endregion

        #region Event Handlers

        private async void MenuItemConnectToSw_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("Попытка подключиться к SolidWorks");

            await HandleConnectToSw();
        }

        #endregion

        #region Helpers
       
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