namespace Modellic.Enums
{
    /// <summary>
    /// Состояние подключения к приложению Solidworks.
    /// </summary>
    public enum SwConnectionStatus
    {
        /// <summary>
        /// Не подключено к приложению.
        /// </summary>
        Disconnected,

        /// <summary>
        /// Отключение от приложения.
        /// </summary>
        Disconnecting,

        /// <summary>
        /// Подключение к приложению.
        /// </summary>
        Connecting,

        /// <summary>
        /// Подключено к приложению.
        /// </summary>
        Connected
    }
}
