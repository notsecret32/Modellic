using Modellic.Events;
using System;
using System.Collections.Generic;

namespace Modellic.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий сервис для построения приспособления.
    /// </summary>
    public interface IFixtureService
    {
        List<IFixtureStep> Steps { get; }

        int Count { get; }

        int CurrentStep { get; }

        bool IsStart { get; }

        bool IsEnd { get; }

        bool HasNextStep { get; }

        bool HasPrevStep { get; }

        event EventHandler<CurrentStepChangedEventArgs> CurrentStepChanged;

        void NextStep();

        void PrevStep();

        T Find<T>() where T : IFixtureStep;

        IFixtureStep GetCurrentStep();

        T GetCurrentStep<T>() where T : IFixtureStep;
    }
}
