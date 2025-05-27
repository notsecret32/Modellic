namespace Modellic.App.Enums
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
    }
}
