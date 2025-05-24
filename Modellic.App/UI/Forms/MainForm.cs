using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Application;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            InitializeComponent();
            InitializeControls();
        }
        
        #endregion

        #region Event Handlers

        private async void MenuItemConnectToSw_Click(object sender, EventArgs e)
        {
            await HandleConnectToSw();
        }

        #endregion

        #region Helpers
       
        private void InitializeControls()
        {
            menuItemConnectToSw.Enabled = !_applicationManager.IsConnected;
            menuItemDisconnectFromSw.Enabled = _applicationManager.IsConnected;
        }

        private void UpdateControls()
        {
            menuItemConnectToSw.Enabled = !_applicationManager.IsConnected;
            menuItemConnectToSw.CheckState = _applicationManager.IsConnected ? CheckState.Checked : CheckState.Unchecked;
            menuItemDisconnectFromSw.Enabled = _applicationManager.IsConnected;
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
            }
            catch (SolidWorksException ex)
            {
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