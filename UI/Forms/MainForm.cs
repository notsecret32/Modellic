using Modellic.Events;
using Modellic.Interfaces;
using Modellic.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modellic.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SwService _swService = new SwService();

        private readonly FixtureService _fixtureService = new FixtureService();

        public MainForm()
        {
            InitializeComponent();
            SetupEventHandlers();
            UpdateUI();
            UpdateDataGrid();
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

        private void OnFixtureStepFormClosed(object sender, FormClosedEventArgs e)
        {
            FixtureStepForm form = (FixtureStepForm)sender;

            if (form.Result == Enums.FixtureStepFormResult.Continue)
            {
                _fixtureService.NextStep();
            }

            IFixtureStep fixtureStep = (IFixtureStep)form.PropertyGrid.SelectedObject;

            MessageBox.Show($"Тип закрытия: {form.Result}\nНазвание шага: {fixtureStep.Title}", form.Text);
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

            string btnNextStepText = _fixtureService.IsStart ? "Начать" : !_fixtureService.IsEnd ? "Продолжить" : "Завершено";
            btnNextStep.Text = btnNextStepText;
            btnNextStep.Enabled = !_fixtureService.IsEnd;

            btnAssembly.Enabled = _fixtureService.IsEnd;

            // Группа Solidworks
            labelConnectionStatus.Text = _swService.ToString();

            // Кнопка подключения
            btnConnectToSw.Enabled = !_swService.IsConnecting && !_swService.IsDisconnecting;
            btnConnectToSw.Text = _swService.IsConnected ? "Отключиться" : "Подключиться";

            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            dataGridSteps.Rows.Clear();

            for (int i = 0; i < _fixtureService.Count; i++)
            {
                dataGridSteps.Rows.Add(
                    _fixtureService.CurrentStep == i ? "➤" : "",
                    i + 1,
                    "Не построен"
                );
            }
        }

        #endregion
    }
}
