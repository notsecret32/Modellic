namespace Modellic.App.Enums
{
    /// <summary>
    /// Варианты действий при уничтожении документа.
    /// </summary>
    public enum SwDestroyNotifyType
    {
        /// <summary>
        /// Документ будет полностью уничтожен. Используется, когда файл хранится в памяти.
        /// </summary>
        Destroy = 0,

        /// <summary>
        /// Документ будет скрыт. Используется, когда документ сохранен.
        /// </summary>
        Hidden = 1
    }
}
