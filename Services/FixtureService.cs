using Modellic.Events;
using Modellic.Interfaces;
using Modellic.Models;
using Modellic.UI.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modellic.Services
{
    /// <summary>
    /// Сервис, контролирующий процесс создания приспособления.
    /// </summary>
    public class FixtureService : IFixtureService
    {
        #region Private Members

        /// <summary>
        /// Индекс текущего шага.
        /// </summary>
        private int _currentStepIndex = 0;

        /// <summary>
        /// Массив шагов, необходимых для создания приспособления.
        /// </summary>
        private readonly List<IFixtureStep> _steps;

        /// <summary>
        /// Объект на котором будет отображаться подробности построения.
        /// </summary>
        private StepsGridViewService _stepsGridViewService;

        #endregion

        #region Properties

        /// <summary>
        /// Список всех шагов построения приспособления.
        /// </summary>
        public List<IFixtureStep> Steps => _steps;

        /// <summary>
        /// Общее количество шагов.
        /// </summary>
        public int Count => _steps.Count;

        /// <summary>
        /// Текущий индекс активного шага.
        /// </summary>
        public int CurrentStepIndex => _currentStepIndex;

        /// <summary>
        /// Флаг, указывающий что текущий шаг первый в последовательности.
        /// </summary>
        public bool IsStart => _currentStepIndex == 0;

        /// <summary>
        /// Флаг, указывающий что текущий шаг последний в последовательности.
        /// </summary>
        public bool IsLastStep => _currentStepIndex == _steps.Count - 1;

        /// <summary>
        /// Флаг, указывающий что все шаги завершены.
        /// </summary>
        public bool IsCompleted => _currentStepIndex >= _steps.Count;

        /// <summary>
        /// Флаг, указывающий что существует следующий шаг после текущего.
        /// </summary>
        public bool HasNextStep => _currentStepIndex < _steps.Count - 1;

        /// <summary>
        /// Флаг, указывающий что существует предыдущий шаг перед текущим.
        /// </summary>
        public bool HasPrevStep => _currentStepIndex > 0;

        /// <summary>
        /// Объект на котором будет отображаться подробности построения.
        /// </summary>
        public StepsGridViewService GridView => _stepsGridViewService;

        #endregion

        #region Events

        /// <summary>
        /// Событие, которое вызывается каждый раз, когда меняется текущий индекс шага.
        /// </summary>
        public event EventHandler<CurrentStepChangedEventArgs> CurrentStepChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Стандартный конструктор в котором уже определено нужное кол-во шагов.
        /// </summary>
        /// <param name="gridView">Объект, который будет отображать детали построения приспособления.</param>
        public FixtureService(StepsGridView gridView)
        {
            _stepsGridViewService = new StepsGridViewService(gridView, this);
            _steps = new List<IFixtureStep>
            {
                new FixtureStep1(),
                new FixtureStep2()
            };
        }

        /// <summary>
        /// Конструктор, принимающий массив шагов необходимых для создания приспособления.
        /// </summary>
        /// <param name="steps">Массив шагов.</param>
        /// <param name="gridView">Объект, который будет отображать детали построения приспособления.</param>
        public FixtureService(List<IFixtureStep> steps, StepsGridView gridView)
        {
            _steps = steps;
            _stepsGridViewService = new StepsGridViewService(gridView, this);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод для перехода на следующий этап.
        /// </summary>
        public void NextStep()
        {
            if (IsCompleted)
            {
                return;
            }

            _currentStepIndex++;
            CurrentStepChanged?.Invoke(this, new CurrentStepChangedEventArgs(this));
        }

        /// <summary>
        /// Метод для перехода на предыдущий этап.
        /// </summary>
        public void PrevStep()
        {
            if (!HasPrevStep)
            {
                return;
            }

            _currentStepIndex--;
            CurrentStepChanged?.Invoke(this, new CurrentStepChangedEventArgs(this));
        }

        /// <summary>
        /// Метод для поиска шага по его типу.
        /// </summary>
        /// <typeparam name="T">Класс, который нужно найти.</typeparam>
        /// <returns>Объект с указанным типом.</returns>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывает ошибку, если указанный тип не соответствует ни одному элементу массива.
        /// </exception>
        public T Find<T>() where T : IFixtureStep
        {
            foreach (var step in _steps)
            {
                if (step is T result)
                {
                    return result;
                }
            }

            throw new InvalidOperationException($"Шаг с типом {typeof(T).Name} не найден в массиве шагов.");
        }

        /// <summary>
        /// Метод для получения объекта текущего шага.
        /// </summary>
        /// <typeparam name="T">Тип, к которому нужно привести текущий шаг.</typeparam>
        /// <returns>Объект текущего шага с указанным типом.</returns>
        /// <exception cref="InvalidCastException">Выбрасывает ошибку, если объект текущий шаг является экземпляром другого класса.</exception>
        public T GetCurrentStep<T>() where T : IFixtureStep
        {
            var step = GetCurrentStep();

            if (step is T typedStep)
            {
                return typedStep;
            }

            throw new InvalidCastException($"Текущий шаг не является типом {typeof(T).Name}");
        }

        /// <summary>
        /// Метод для получения объекта текущего шага.
        /// </summary>
        /// <returns>Объект текущего шага либо null, если все шаги завершены.</returns>
        /// <exception cref="IndexOutOfRangeException">Выбрасывает ошибку, если текущий индекс шага выходит за рамки длины массива.</exception>
        public IFixtureStep GetCurrentStep()
        {
            // Если все шаги завершены - возвращаем null
            if (IsCompleted)
            {
                return null;
            }

            // Проверяем на выход за границы
            if (_currentStepIndex < 0 || _currentStepIndex >= _steps.Count)
            {
                throw new IndexOutOfRangeException(
                    $"Текущий индекс шага {_currentStepIndex} выходит за рамки массива. Кол-во шагов: {_steps.Count}");
            }

            return _steps[_currentStepIndex];
        }

        #endregion

        #region Public Async Methods

        public async Task BuildAsync()
        {
            await Task.Run(() =>
            {
                this._steps[this._currentStepIndex].Build();
            });
        }

        #endregion
    }
}
