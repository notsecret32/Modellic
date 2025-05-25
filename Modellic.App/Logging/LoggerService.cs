using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Modellic.App.Logging
{
    /// <summary>
    /// Сервис логирования. Предоставляет методы для логированния всему приложению без необходимости передавать его через параметры.
    /// </summary>
    public static class LoggerService
    {
        #region Private Members

        /// <summary>
        /// Объект настройки логирования.
        /// </summary>
        private static readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Объект логирования.
        /// </summary>
        private static readonly ILogger _logger;

        #endregion

        #region Public Properties

        /// <summary>
        /// Объект логирования.
        /// </summary>
        public static ILogger Logger => _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Статический дефотлный конструктор.
        /// </summary>
        static LoggerService()
        {
            // Создаем сервис-провайдер
            var serviceCollection = new ServiceCollection();

            // Настраиваем логгирование
            ConfigureServices(serviceCollection);

            // Создаем провайдер сервисов
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Получаем фабрику логгеров
            _loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            // Создаем логгер для текущего класса (можно указать любой другой тип)
            _logger = _loggerFactory.CreateLogger("Application");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Настраивает сервисы.
        /// </summary>
        /// <param name="services">Контейнер с сервисами.</param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                // Очищаем стандартные провайдеры
                configure.ClearProviders();

                // Настройка консольного вывода
                configure.AddConsole(options =>
                {
                    options.FormatterName = "CustomConsoleFormatter";
                })
                .AddConsoleFormatter<CustomConsoleFormatter, ConsoleFormatterOptions>();

                // Глобальный минимальный уровень (переопределяется фильтрами ниже)
                configure.SetMinimumLevel(LogLevel.Trace);

                // Фильтры для системных пространств имен
                configure.AddFilter("Microsoft", LogLevel.Warning);
                configure.AddFilter("System", LogLevel.Warning);

                // Фильтр для всего вашего приложения
                configure.AddFilter("Modellic.App", LogLevel.Debug);
            });
        }

        #endregion
    }
}
