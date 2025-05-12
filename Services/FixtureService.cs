using Modellic.Enums;
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
    internal class FixtureService : IFixtureService
    {
        /// <summary>
        /// Индекс текущего шага.
        /// </summary>
        private int _currentStep = 0;

        /// <summary>
        /// Объект на котором будет отображаться подробности построения.
        /// </summary>
        private StepsGridViewService _stepsGridViewService;

        /// <summary>
        /// Массив шагов, необходимых для создания приспособления.
        /// </summary>
        private readonly List<IFixtureStep> _steps;

        /// <summary>
        /// Массив шагов необходимых для создания приспособления.
        /// </summary>
        public List<IFixtureStep> Steps => _steps;

        /// <summary>
        /// Кол-во шагов необходимых для создания приспособления.
        /// </summary>
        public int Count => _steps.Count;

        /// <summary>
        /// Индекс текущего шага.
        /// </summary>
        public int CurrentStep => _currentStep;

        /// <summary>
        /// Возвращает true, если текущий индекс шага равен 0.
        /// </summary>
        public bool IsStart => _currentStep == 0;

        /// <summary>
        /// Возвращает true, если текущий индекс указывает на последний шаг.
        /// </summary>
        public bool IsEnd => _currentStep >= _steps.Count;

        /// <summary>
        /// Возвращает true, если существует следующий шаг после текущего.
        /// </summary>
        /// <value>
        /// true - можно перейти к следующему шагу через метод NextStep();
        /// false - текущий шаг последний в коллекции.
        /// </value>
        public bool HasNextStep => _currentStep <= _steps.Count - 1;

        /// <summary>
        /// Возвращает true, если существует предыдущий шаг перед текущим.
        /// </summary>
        /// <value>
        /// true - можно перейти к предыдущему шагу через метод PrevStep();
        /// false - текущий шаг первый в коллекции.
        /// </value>
        public bool HasPrevStep => _currentStep > 0;

        /// <summary>
        /// Объект на котором будет отображаться подробности построения.
        /// </summary>
        public StepsGridViewService GridView => _stepsGridViewService;

        /// <summary>
        /// Событие, которое вызывается каждый раз, когда меняется текущий индекс шага.
        /// </summary>
        public event EventHandler<CurrentStepChangedEventArgs> CurrentStepChanged;

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

        /// <summary>
        /// Метод для перехода на следующий этап.
        /// </summary>
        public void NextStep()
        {
            if (HasNextStep)
            {
                _currentStep++;
                CurrentStepChanged?.Invoke(this, new CurrentStepChangedEventArgs(this));
            }
        }

        /// <summary>
        /// Метод для перехода на предыдущий этап.
        /// </summary>
        public void PrevStep()
        {
            if (HasPrevStep) 
            {
                _currentStep--;
                CurrentStepChanged?.Invoke(this, new CurrentStepChangedEventArgs(this));
            }
        }

        public async Task BuildAsync()
        {
            await Task.Run(() =>
            {
                this._steps[this._currentStep].Build();
            });
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
        /// <returns>Объект текущего шага.</returns>
        /// <exception cref="IndexOutOfRangeException">Выбрасывает ошибку, если текущий индекс шага выходит за рамки длины массива.</exception>
        public IFixtureStep GetCurrentStep()
        {
            if (!this.IsCurrentIndexValid())
            {
                throw new IndexOutOfRangeException(
                    $"Текущий индекс шага {_currentStep} выходит за рамки массива. Кол-во шагов: {_steps.Count}");
            }

            return _steps[_currentStep];
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
        /// Проверяет, находится ли текущий индекс шага в допустимых границах.
        /// </summary>
        /// <returns>
        /// <c>true</c> - индекс корректен.
        /// <c>false</c> - индекс выходит за границы коллекции шагов.
        /// </returns>
        private bool IsCurrentIndexValid() => _currentStep >= 0 && _currentStep <= _steps.Count - 1;
    }
}
