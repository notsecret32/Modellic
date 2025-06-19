using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using Modellic.App.SolidWorks.Documents;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Conductor
{
    public abstract class ConductorBaseStep
    {
        #region Private Members

        /// <summary>
        /// Статус построения шага. Подробнее в <see cref="ConductorStepStatus"/>.
        /// </summary>
        private ConductorStepStatus _status = ConductorStepStatus.NotBuilded;

        #endregion

        #region Protectede Members

        /// <summary>
        /// Название шага.
        /// </summary>
        protected string _stepName = "Название шага не переопределено";

        /// <summary>
        /// Ссылка на сборщик.
        /// </summary>
        protected ConductorBuilder _builder;

        #endregion

        #region Public Properties

        public ConductorBaseParams Parameters { get; set; }

        /// <summary>
        /// Название шага.
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Статус построения шага. Подробнее в <see cref="ConductorStepStatus"/>.
        /// </summary>
        public ConductorStepStatus Status
        {
            get { return _status; }
            private set
            {
                if (_status != value)
                {
                    _status = value;
                    StatusChanged?.Invoke(this, _status);
                }
            }
        }

        /// <summary>
        /// Файл в котором строится шаг приспособления.
        /// </summary>
        public SwPartDoc Document { get; set; } = null;

        #endregion

        #region Public Events

        /// <summary>
        /// Событие, вызывается каждый раз при изменении статуса постройки шага.
        /// </summary>
        public event Action<ConductorBaseStep, ConductorStepStatus> StatusChanged;

        #endregion

        #region Constructor

        public ConductorBaseStep(ConductorBuilder builder, SwPartDoc partDoc = null)
        {
            _builder = builder;
            Document = partDoc;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод для построения шага. Валидирует параметры и обновляет состояние.
        /// </summary>
        public void Build()
        {
            // Проверяем наличие файла
            if (Document == null)
            {
                Status = ConductorStepStatus.Error;
                Logger.LogWarning($"[FixtureStep] Ссылка на документ равна null");
                throw new Exception("Нет файла для построения приспособления.");
            }

            // Проверяем валидацию
            if (!Validate())
            {
                Status = ConductorStepStatus.ValidationFailed;
                Logger.LogWarning($"[FixtureStep] Шаг \"{Title}\" не прошел валидацию");
                return;
            }

            // Если шаг уже строиться, выходим
            if (Status == ConductorStepStatus.Building)
                return; 

            try
            {
                Status = ConductorStepStatus.Building;
                Logger.LogInformation($"[FixtureStep] Начинаем построение шага: \"{Title}\"");

                BuildStep();

                Status = ConductorStepStatus.Builded;
                Logger.LogInformation($"[FixtureStep] Шаг \"{Title}\" успешно построен");
            }
            catch (Exception ex)
            {
                Status = ConductorStepStatus.Error;
                Logger.LogError(ex, $"[FixtureStep] Ошибка при построении шага \"{Title}\"");
                throw ex; // Пробрасываем исключение дальше
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
                    Status = ConductorStepStatus.Cancel;

                    Logger.LogInformation($"[Отменено] Построение шага \"{Title}\" было отменено");

                    // Пробрасываем исключение дальше
                    throw; 
                }

            }, cancellationToken);
        }

        #endregion
    }
}
