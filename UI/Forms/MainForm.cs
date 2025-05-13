using Modellic.Enums;
using Modellic.Events;
using Modellic.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modellic.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SwService _swService;

        private readonly FixtureService _fixtureService;

        public MainForm()
        {
            InitializeComponent();

            _swService = new SwService();
            _fixtureService = new FixtureService(stepsGridView);

            SetupEventHandlers();
            UpdateUI();
        }

        #region Form Handlers

        private async void BtnConnectToSw_Click(object sender, EventArgs e)
        {
            await HandleSwConnection();
        }

        private void BtnNextStep_Click(object sender, EventArgs e)
        {
            using FixtureStepForm form = new FixtureStepForm(_fixtureService.GetCurrentStep());

            form.FormClosed += OnFixtureStepFormClosed;

            form.ShowDialog();
        }

        #endregion

        #region Callbacks

        private void OnConnectionStatusChanged(object sender, EventArgs e)
        {
            this.Invoke((Action)UpdateUI);
        }

        private async void OnFixtureStepFormClosed(object sender, FormClosedEventArgs e)
        {
            FixtureStepForm form = (FixtureStepForm)sender;

            if (form.Result == FixtureStepFormResult.Continue)
            {
                try
                {
                    await _fixtureService.BuildAsync();
                    _fixtureService.NextStep();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnCurrentStepChanged(object sender, CurrentStepChangedEventArgs e)
        {
            UpdateUI();
        }

        #endregion

        #region Private Methods

        private void SetupEventHandlers()
        {
            _swService.ConnectionStatusChanged += OnConnectionStatusChanged;
            _fixtureService.CurrentStepChanged += OnCurrentStepChanged;
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

            btnNextStep.Enabled = !_fixtureService.IsCompleted;
            btnNextStep.Text = _fixtureService.IsCompleted ? "Завершено"
                                 : _fixtureService.IsLastStep ? "Завершить"
                                 : _fixtureService.IsStart ? "Начать" : "Продолжить";

            btnAssembly.Enabled = _fixtureService.IsCompleted;

            // Группа Solidworks
            labelConnectionStatus.Text = _swService.ToString();

            // Кнопка подключения
            btnConnectToSw.Enabled = !_swService.IsConnecting && !_swService.IsDisconnecting;
            btnConnectToSw.Text = _swService.IsConnected ? "Отключиться" : "Подключиться";

            _fixtureService.GridView.Update();
        }

        #endregion
    }
}
