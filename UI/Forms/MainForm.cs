using Modellic.Services;
using System;
using System.Windows.Forms;

namespace Modellic.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SwService _swService = new SwService();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Update();
        }

        private void BtnConnectToSw_Click(object sender, EventArgs e)
        {
            HandleSwConnection();
        }

        private new void Update()
        {
            // Fixture Group
            groupFixture.Enabled = _swService.IsConnected;

            // Solidworks Group
            labelConnectionState.Text = _swService.ToString();
            btnConnectToSw.Text = !_swService.IsConnected ? "Подключиться" : "Отключиться";
        }

        private void HandleSwConnection(bool isRetry = false)
        {
            try
            {
                if (!_swService.IsConnected)
                {
                    _swService.Connect();
                }
                else
                {
                    _swService.Disconnect();
                }
            }
            catch (Exception ex)
            {
                string message = isRetry
                    ? $"Повторная попытка не удалась:\n{ex.Message}"
                    : ex.Message;

                DialogResult result = MessageBox.Show(
                    message,
                    "Ошибка подключения к SolidWorks",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.Retry)
                {
                    HandleSwConnection(true);
                }
            }
            finally
            {
                Update();
            }
        }
    }
}
