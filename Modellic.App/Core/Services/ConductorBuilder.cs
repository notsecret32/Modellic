using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor;
using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Enums;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Documents;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Класс управляющий созданием кондуктора. В его задачи входит управление шагами, их постройка, изменение, очищение и т.д.
    /// Логика заключается в том, чтобы описать кондуктор и уже под него сделать приспособление.
    /// </summary>
    public class ConductorBuilder
    {
        #region Private Members

        /// <summary>
        /// Индекс последнего собранного шага. -1 означает, что ни один шаг еще не построен.
        /// </summary>
        private int _lastBuiltStepIndex = -1;

        #endregion

        #region Private Readonly Members

        /// <summary>
        /// Массив, хранящий шаги построения приспособления.
        /// </summary>
        private readonly List<ConductorBaseStep> _steps;

        #endregion

        #region Public Properties

        /// <summary>
        /// Массив со всеми шагами построения приспособления.
        /// </summary>
        public List<ConductorBaseStep> FixtureSteps => _steps;

        /// <summary>
        /// Количество шагов.
        /// </summary>
        public int StepCount => _steps.Count;

        /// <summary>
        /// Индекс последнего собранного шага. -1 означает, что ни один шаг еще не построен.
        /// </summary>
        public int LastBuiltStepIndex => _lastBuiltStepIndex;

        #endregion

        #region Public Events

        /// <summary>
        /// Событие, вызывается каждый раз, когда изменяется статус построения шага.
        /// </summary>
        public event Action<ConductorBaseStep, ConductorStepStatus> FixtureStepStatusChanged;

        #endregion

        #region Constructors

        public ConductorBuilder()
        {
            Logger.LogInformation("Создаем FixtureBuilder");

            // Инициализируем шаги сборки
            _steps = new List<ConductorBaseStep>()
            {
                new ConductorStep1(this),
                new ConductorStep2(this),
                new ConductorStep3(this),
                new ConductorStep4(this),
            };

            foreach (ConductorBaseStep step in _steps)
            {
                step.StatusChanged += OnFixtureStepStatusChanged;
            }

            Logger.LogInformation($"FixtureBuilder создан ({_steps.Count} шага)");
        }

        #endregion

        #region Public Methods

        public void AttachDocument(SwPartDoc document)
        {
            foreach (ConductorBaseStep step in _steps)
            {
                step.SetWorkingDoc(document);
            }
        }

        public ConductorBaseStep GetStepByIndex(int index)
        {
            return _steps[index];
        }

        public T GetStep<T>() where T : ConductorBaseStep
        {
            foreach (var step in _steps)
            {
                if (step is T)
                {
                    return (T)step;
                }
            }

            throw new InvalidOperationException($"Класса {nameof(T)} не существует в массиве шагов.");
        }

        public T GetParameters<T>() where T : ConductorBaseParams
        {
            foreach (var step in _steps)
            {
                if (step.Parameters is T parameters)
                {
                    return parameters;
                }
            }

            throw new InvalidOperationException($"Параметры типа {nameof(T)} не найдены в массиве шагов.");
        }

        public bool IsPreviousStepBuilded(int cursorPosition) => !(cursorPosition != _lastBuiltStepIndex + 1);
        
        public bool IsSelectedStepBuilded(int cursorPosition) => _steps[cursorPosition].Status == ConductorStepStatus.Builded;

        #endregion

        #region Public Async Methods

        /// <summary>
        /// <para>Строит текущий шаг на который указывает курсор.</para>
        /// <para>Шаг не может быть построен в следующий случаях:</para>
        /// <list type="bullet">
        /// <item>Если предыдущий шаг, относительно курсора, не построен;</item>
        /// <item>Если текущий шаг, на который указывает курсор, уже построен;</item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken">Уведовление об остановке построения шага.</param>
        /// <exception cref="FixtureBuilderException">Если какое-то из условий не удовлетворено.</exception>
        public async Task BuildSelectedStepAsync(int cursorPosition, CancellationToken cancellationToken = default)
        {
            // Проверяем отмену в начале
            cancellationToken.ThrowIfCancellationRequested();

            // Проверяем, что выбранный шаг еще не построен
            if (IsSelectedStepBuilded(cursorPosition))
            {
                Logger.LogWarning("Выбранный шаг уже построен");

                throw new FixtureBuilderException(
                    "Выбранный шаг уже построен, выберите другой.",
                    FixtureBuilderErrorCode.AlreadyBuilded
                );
            }

            // Проверяем, что предыдущий шаг был построен
            if (!IsPreviousStepBuilded(cursorPosition))
            {
                Logger.LogWarning("Предыдущий шаг не построен");

                throw new FixtureBuilderException(
                    "Предыдущий шаг не построен. Постройте его и повторите попытку.",
                    FixtureBuilderErrorCode.PreviousStepNotBuilded
                );
            }

            try
            {
                // Строим шаг с передачей токена
                await FixtureSteps[cursorPosition].BuildStepAsync(cancellationToken);

                // Обновляем счетчик
                _lastBuiltStepIndex = cursorPosition;
            }
            catch (OperationCanceledException ex)
            {
                Logger.LogInformation("Построение шага было отменено");

                // Пробрасываем исключение дальше
                throw ex;
            }
        }

        #endregion

        #region Private Event Handlers

        private void OnFixtureStepStatusChanged(ConductorBaseStep step, ConductorStepStatus status)
        {
            FixtureStepStatusChanged?.Invoke(step, status);
        }

        #endregion
    }
}
