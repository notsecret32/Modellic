﻿namespace Modellic.App.Enums
{
    /// <summary>
    /// Список ошибок возникающий при постройке приспособления.
    /// </summary>
    public enum FixtureBuilderErrorCode
    {
        /// <summary>
        /// Возникает, когда пользователь пытается создать шаг, когда предыдущий еще не построен.
        /// </summary>
        PreviousStepNotBuilded = 1000,

        /// <summary>
        /// Возникает, когда пользователь пытается построить шаг, когда он уже построен.
        /// </summary>
        AlreadyBuilded = 1001,

        /// <summary>
        /// Нет рабочего документа, в котором будет строиться приспособление.
        /// </summary>
        NoActiveDocument = 1002,

        /// <summary>
        /// Возникает, когда пользователь пытается построить шаг, но все они уже построены.
        /// </summary>
        AllStepsAlreadyBuilded = 1003,
    }
}
