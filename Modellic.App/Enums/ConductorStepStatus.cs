namespace Modellic.App.Core.Models.Conductor
{
    /// <summary>
    /// Статус построения шага приспособления.
    /// </summary>
    public enum ConductorStepStatus
    {
        /// <summary>
        /// Шаг приспособления еще не построен. 
        /// </summary>
        NotBuilded,

        /// <summary>
        /// Шаг приспособления в процессе построения.
        /// </summary>
        Building,

        /// <summary>
        /// Шаг приспособления простроен.
        /// </summary>
        Builded,

        /// <summary>
        /// Построение шага было отменено.
        /// </summary>
        Cancel,

        /// <summary>
        /// Ошибка при построении шага приспособления.
        /// </summary>
        Error,

        /// <summary>
        /// Шаг не прошел валидацию.
        /// </summary>
        ValidationFailed
    }
}
