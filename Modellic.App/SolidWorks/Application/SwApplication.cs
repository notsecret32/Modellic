using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Documents;
using SolidWorks.Interop.sldworks;

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

        public SwApplication(ISldWorks solidWorks) : base(solidWorks) { }

        #endregion

        #region Dispose

        public override void Dispose()
        {
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
