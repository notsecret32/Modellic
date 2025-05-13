using Modellic.Events;
using Modellic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modellic.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий сервис для построения приспособления.
    /// </summary>
    public interface IFixtureService
    {
        List<IFixtureStep> Steps { get; }

        int Count { get; }

        int CurrentStepIndex { get; }

        bool IsStart { get; }

        bool IsEnd { get; }

        bool HasNextStep { get; }

        bool HasPrevStep { get; }

        StepsGridViewService GridView { get; }

        event EventHandler<CurrentStepChangedEventArgs> CurrentStepChanged;

        void NextStep();

        void PrevStep();

        Task BuildAsync();

        T Find<T>() where T : IFixtureStep;

        IFixtureStep GetCurrentStep();

        T GetCurrentStep<T>() where T : IFixtureStep;
    }
}
