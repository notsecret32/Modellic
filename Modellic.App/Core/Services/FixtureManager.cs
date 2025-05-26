using Microsoft.Extensions.Logging;
using System;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Связующее звено между формой и классом сборки приспособления.
    /// </summary>
    public class FixtureManager
    {
        #region Private Readonly Members

        /// <summary>
        /// Сборщик приспособления.
        /// </summary>
        private readonly FixtureBuilder _fixtureBuilder;

        /// <summary>
        /// Сервис по управлению StepsGridView.
        /// </summary>
        private readonly StepsGridViewService _stepsGridViewService;

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Ссылка на единственный экземпляр класс <see cref="FixtureManager"/>.
        /// </summary>
        public static FixtureManager Instance;

        #endregion

        #region Constructors

        public FixtureManager(FixtureBuilder fixtureBuilder, StepsGridViewService stepsGridViewService)
        {
            // Проверяем, есть ли объект этого класса
            if (Instance != null)
            {
                Logger.LogCritical("Замечена попытка создать новый экземпляр");

                throw new Exception("Замечена попытка создать новый экземпляр");
            }

            // Инициализируем сборщик приспособления
            _fixtureBuilder = fixtureBuilder;

            // Инициализируем сервис по работе с StepsGridView
            _stepsGridViewService = stepsGridViewService;

            // Инициализируем сам StepsGridView
            _stepsGridViewService.Initialize();

            // Устанавливаем ссылку на этот объект
            Instance = this;

            Logger.LogInformation("FixtureManager создан");
        }

        #endregion
    }
}