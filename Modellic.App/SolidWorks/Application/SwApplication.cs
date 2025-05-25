using Microsoft.Extensions.Logging;
using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Application
{
    public class SwApplication : SwSharedObject<ISldWorks>
    {
        #region Protected Members

        protected SwModelDoc _activeDocument;

        #endregion

        #region Private Members

        private readonly object _disposingLock = new object();

        #endregion

        #region Public Properties

        public SwModelDoc ActiveDocument => _activeDocument;

        public bool Disposing { get; private set; }

        #endregion

        #region Constructors

        public SwApplication(ISldWorks solidWorks) : base(solidWorks)
        {
            Logger.LogInformation($"Создаем экземпляр класса SwApplication (PID: {solidWorks.GetProcessID()})");
        }

        #endregion

        #region Dispose

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
