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
        private SwService _swService;

        private FixtureService _fixtureService;

        public MainForm()
        {
            InitializeComponent();
            InitializeServices();
            SetupEventHandlers();
            UpdateUI();
        }

        #region Initialization

        private void InitializeServices()
        {
            _swService = new SwService();
            _fixtureService = new FixtureService(stepsGridView);
        }

        private void SetupEventHandlers()
        {
            _swService.ConnectionStatusChanged += OnConnectionStatusChanged;
            _fixtureService.CurrentStepChanged += OnCurrentStepChanged;
            _fixtureService.BuildStatusChanged += OnBuildStatusChanged;
        }

        #endregion

        #region Event Handlers

        private async void BtnConnectToSw_Click(object sender, EventArgs e)
        {
            await HandleSwConnectionAsync().ConfigureAwait(false);
        }

        private void BtnNextStep_Click(object sender, EventArgs e)
        {
            ShowFixtureStepForm();
        }

        #endregion

        #region Callbacks

        private void OnConnectionStatusChanged(object sender, EventArgs e)
        {
            this.SafeInvoke(UpdateUI);
        }

        private void OnBuildStatusChanged(object sender, FixtureStepBuildStatusChangedEventArgs e)
        {
            this.SafeInvoke(() =>
            {
                var isInProgress = e.BuildStatus == FixtureStepBuildStatus.InProgress;
                btnNextStep.Enabled = !isInProgress;
                btnNextStep.Text = isInProgress ? "В процессе..." : GetNextStepButtonText();
                btnConnectToSw.Enabled = !isInProgress && !_swService.IsConnecting && !_swService.IsDisconnecting;
            });
        }

        private async void OnFixtureStepFormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is FixtureStepForm form && form.Result == FixtureStepFormResult.Continue)
            {
                await ProcessCurrentStepAsync();
            }
        }

        private void OnCurrentStepChanged(object sender, CurrentStepChangedEventArgs e)
        {
            this.SafeInvoke(UpdateUI);
        }

        #endregion

        #region Private Methods

        private async Task HandleSwConnectionAsync()
        {
            try
            {
                if (!_swService.IsConnected)
                {
                    await _swService.ConnectAsync().ConfigureAwait(false);
                }
                else
                {
                    await _swService.DisconnectAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                await HandleConnectionErrorAsync(ex);
            }
            finally
            {
                this.SafeInvoke(UpdateUI);
            }
        }

        private async Task HandleConnectionErrorAsync(Exception ex)
        {
            var result = MessageBox.Show(
                ex.Message,
                "Ошибка подключения",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error
            );

            if (result == DialogResult.Retry)
            {
                await HandleSwConnectionAsync().ConfigureAwait(false);
            }
        }

        private void ShowFixtureStepForm()
        {
            using var form = new FixtureStepForm(_fixtureService.GetCurrentStep());
            form.FormClosed += OnFixtureStepFormClosed;
            form.ShowDialog(this);
        }

        private async Task ProcessCurrentStepAsync()
        {
            try
            {
                await _fixtureService.BuildAsync().ConfigureAwait(false);
                _fixtureService.NextStep();
            }
            catch (Exception ex)
            {
                this.SafeInvoke(() =>
                {
                    // Обновляем статус ошибки
                    _fixtureService.GridView.Update();
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            finally
            {
                this.SafeInvoke(UpdateUI);
            }
        }

        private void UpdateUI()
        {
            // Группа Приспособление
            groupFixture.Enabled = _swService.IsConnected;

            btnNextStep.Enabled = !_fixtureService.IsCompleted;
            btnNextStep.Text = GetNextStepButtonText();

            btnAssembly.Enabled = _swService.IsConnected && _fixtureService.IsCompleted;

            // Группа Solidworks
            labelConnectionStatus.Text = _swService.ToString();

            // Кнопка подключения
            btnConnectToSw.Enabled = !_swService.IsConnecting && !_swService.IsDisconnecting;
            btnConnectToSw.Text = _swService.IsConnected ? "Отключиться" : "Подключиться";

            _fixtureService.GridView.Update();
        }

        private string GetNextStepButtonText()
        {
            if (_fixtureService.IsCompleted) return "Завершено";
            if (_fixtureService.IsLastStep) return "Завершить";
            return _fixtureService.IsStart ? "Начать" : "Продолжить";
        }

        #endregion
    }

    public static class ControlExtensions
    {
        public static void SafeInvoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}