using Modellic.Interfaces;
using Modellic.Models;
using Modellic.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modellic.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SwService _swService = new SwService();

        public MainForm()
        {
            InitializeComponent();
            SetupEventHandlers();
            UpdateUI();
        }

        #region Form Handlers
        
        private async void BtnConnectToSw_Click(object sender, EventArgs e)
        {
            await HandleSwConnection();
        }

        private void BtnNextStage_Click(object sender, EventArgs e)
        {
            using FixtureStepForm form = new FixtureStepForm(new FixtureStep1());

            form.FormClosed += OnFixtureStepFormClosed;

            form.ShowDialog();
        }

        #endregion

        #region Callbacks

        private void OnConnectionStatusChanged(object sender, EventArgs e)
        {
            this.Invoke((Action)UpdateUI);
        }

        private void OnFixtureStepFormClosed(object sender, FormClosedEventArgs e)
        {
            FixtureStepForm form = (FixtureStepForm)sender;

            IFixtureStep fixtureStep = (IFixtureStep)form.PropertyGrid.SelectedObject;

            MessageBox.Show($"Тип закрытия: {form.Result}\nНазвание шага: {fixtureStep.Title}", form.Text);
        }

        #endregion

        #region Private Methods

        private void SetupEventHandlers()
        {
            _swService.ConnectionStatusChanged += OnConnectionStatusChanged;
        }

        private async Task HandleSwConnection()
        {
            try
            {
                if (!_swService.IsConnected)
                {
                    await _swService.ConnectAsync();
                }
                else
                {
                    await _swService.DisconnectAsync();
                }
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(
                    ex.Message,
                    "Ошибка подключения",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.Retry)
                {
                    await HandleSwConnection();
                }
            }
            finally
            {
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            // Группа Приспособление
            groupFixture.Enabled = _swService.IsConnected;

            // Группа Solidworks
            labelConnectionState.Text = _swService.ToString();

            // Кнопка подключения
            btnConnectToSw.Enabled = !_swService.IsConnecting && !_swService.IsDisconnecting;
            btnConnectToSw.Text = _swService.IsConnected ? "Отключиться" : "Подключиться";
        }

        #endregion
    }
}
