using Microsoft.Extensions.Logging;
using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Application
{
    /// <summary>
    /// Представляет собой приложение SolidWorks.
    /// </summary>
    public class SwApplication : SwSharedObject<ISldWorks>
    {
        #region Protected Members

        /// <summary>
        /// Активный документ.
        /// </summary>
        protected SwModelDoc _activeDocument;

        #endregion

        #region Private Members

        /// <summary>
        /// Объект заглушка для удаления данных объекта в lock.
        /// </summary>
        private readonly object _disposingLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// Активный документ. Может быть null если нет открытого документа.
        /// </summary>
        public SwModelDoc ActiveDocument => _activeDocument;

        public bool Disposing { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Создает приложение SolidWorks и хранит информацию о нем.
        /// </summary>
        /// <param name="solidWorks">Объект приложения SolidWorks.</param>
        public SwApplication(ISldWorks solidWorks) : base(solidWorks)
        {
            Logger.LogInformation($"Создаем экземпляр класса SwApplication (PID: {solidWorks.GetProcessID()})");
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Правильно очищает данные объекта.
        /// </summary>
        public override void Dispose()
        {
            Logger.LogInformation($"Запущено удаление (PID: {BaseObject.GetProcessID()})");

            lock (_disposingLock)
            {
                // Устанавливаем флаг, что идет процесс очистки
                Disposing = true;

                // Очищаем текущий документ
                ActiveDocument?.Dispose();

                // ПОМЕТКА: Не очищать приложение, SolidWorks делает это сам
                //base.Dispose();
            }
        }

        #endregion
    }
}
