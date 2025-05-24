using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Application;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modellic.App
{
    public partial class MainForm : Form
    {
        private readonly SwApplicationManager _applicationManager = SwApplicationManager.Instance;

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private async void MenuItemConnectToSw_Click(object sender, EventArgs e)
        {
            await HandleConnectToSw();
        }

        private async Task HandleConnectToSw()
        {
            try
            {
                // Подключаемся к SolidWorks
                await _applicationManager.ConnectAsync();

                // Обновляем состояние UI элементов
                menuItemConnectToSw.Enabled = false;
                menuItemConnectToSw.CheckState = CheckState.Checked;
                menuItemDisconnectFromSw.Enabled = true;
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
        }

        private void InitializeControls()
        {
            menuItemConnectToSw.Enabled = !_applicationManager.IsConnected;
            menuItemDisconnectFromSw.Enabled = _applicationManager.IsConnected;
        }
    }
}