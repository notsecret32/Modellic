using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Core.Services;
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

        /// <summary>
        /// Статус построения шага. Подробнее в <see cref="FixtureStepStatus"/>.
        /// </summary>
        private FixtureStepStatus _status = FixtureStepStatus.NotBuilded;

        #endregion

        #region Protectede Members

        /// <summary>
        /// Название шага.
        /// </summary>
        protected string _stepName = "Название шага не переопределено";

        /// <summary>
        /// Ссылка на сборщик.
        /// </summary>
        protected FixtureBuilder _builder;

        #endregion

        #region Public Properties

        public FixtureStepParameters Parameters { get; set; }

        /// <summary>
        /// Название шага.
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Статус построения шага. Подробнее в <see cref="FixtureStepStatus"/>.
        /// </summary>
        public FixtureStepStatus Status
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
        public event Action<FixtureStep, FixtureStepStatus> StatusChanged;

        #endregion

        #region Constructor

        public FixtureStep(FixtureBuilder builder, SwPartDoc partDoc = null)
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
                Status = FixtureStepStatus.Error;
                Logger.LogWarning($"[FixtureStep] Ссылка на документ равна null");
                throw new Exception("Нет файла для построения приспособления.");
            }

            // Проверяем валидацию
            if (!Validate())
            {
                Status = FixtureStepStatus.ValidationFailed;
                Logger.LogWarning($"[FixtureStep] Шаг \"{Title}\" не прошел валидацию");
                return;
            }

            // Если шаг уже строиться, выходим
            if (Status == FixtureStepStatus.Building)
                return; 

            try
            {
                Status = FixtureStepStatus.Building;
                Logger.LogInformation($"[FixtureStep] Начинаем построение шага: \"{Title}\"");

                BuildStep();

                Status = FixtureStepStatus.Builded;
                Logger.LogInformation($"[FixtureStep] Шаг \"{Title}\" успешно построен");
            }
            catch (Exception ex)
            {
                Status = FixtureStepStatus.Error;
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
