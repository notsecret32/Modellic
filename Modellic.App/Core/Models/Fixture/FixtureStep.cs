using Microsoft.Extensions.Logging;
using Modellic.App.SolidWorks.Documents;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public abstract class FixtureStep
    {
        #region Private Members

        private FixtureStepStatus _status = FixtureStepStatus.NotBuilded;

        #endregion

        #region Protectede Members

        /// <summary>
        /// Файл в котором строиться шаг.
        /// </summary>
        protected SwPartDoc _document;

        protected string _stepName = "Название шага не переопределено";

        #endregion

        #region Public Properties

        public abstract string Title { get; }

        public FixtureStepStatus Status
        {
            get { return _status; }
            protected set
            {
                if (_status != value)
                {
                    _status = value;
                    StatusChanged?.Invoke(this, _status);
                }
            }
        }

        #endregion

        #region Public Events

        public event Action<FixtureStep, FixtureStepStatus> StatusChanged;

        #endregion

        #region Public Methods

        public void AttachToDocument(SwPartDoc partDoc)
        {
            _document = partDoc ?? throw new ArgumentNullException(nameof(partDoc), "Ошибка загрузки файла модели");
        }

        /// <summary>
        /// Метод для построения шага. Валидирует параметры и обновляет состояние.
        /// </summary>
        public void Build()
        {
            // Проверяем валидацию
            if (!Validate())
            {
                Status = FixtureStepStatus.ValidationFailed;
                Logger.LogWarning($"[FixtureStep | {Status}] Шаг \"{Title}\" не прошел валидацию");
                return;
            }

            // Если шаг уже строиться, выходим
            if (Status == FixtureStepStatus.Building)
                return; 

            try
            {
                Status = FixtureStepStatus.Building;
                Logger.LogInformation($"[FixtureStep | {Status}] Начинаем построение шага: \"{Title}\"");

                BuildStep();

                Status = FixtureStepStatus.Builded;
                Logger.LogInformation($"[FixtureStep | {Status}] Шаг \"{Title}\" успешно построен");
            }
            catch (Exception ex)
            {
                Status = FixtureStepStatus.Error;
                Logger.LogError(ex, $"[FixtureStep | {Status}] Ошибка при построении шага \"{Title}\"");
                throw; // Пробрасываем исключение дальше
            }
        }

        #endregion

        #region Protected Abstract Methods

        /// <summary>
        /// Метод для построения шага.
        /// </summary>
        protected abstract void BuildStep();

        /// <summary>
        /// Метод для валидации параметров шага.
        /// </summary>
        /// <returns>True - Строим шаг; False - Отменяем построение шага.</returns>
        protected abstract bool Validate();

        #endregion

        #region Public Virtual Methods

        public virtual Task BuildStepAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                // Проверяем отмену перед началом
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    Build();
                }
                catch (OperationCanceledException)
                {
                    // Устанавливаем статус при отмене
                    Status = FixtureStepStatus.Cancel;

                    Logger.LogInformation($"[Отменено] Построение шага \"{Title}\" было отменено");

                    // Пробрасываем исключение дальше
                    throw; 
                }

            }, cancellationToken);
        }

        #endregion
    }
}
