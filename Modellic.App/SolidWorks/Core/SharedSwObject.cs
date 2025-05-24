using System.Runtime.InteropServices;

namespace Modellic.App.SolidWorks.Core
{
    /// <summary>
    /// Обобщённая версия SwObject с типизированным доступом к COM-объекту.
    /// Реализует IDisposable для корректного освобождения COM-ресурсов.
    /// 
    /// ПРИМЕЧАНИЕ: Используйте этот общий тип, если другая часть приложения может иметь доступ к тому же COM-объекту, и жизненный цикл для каждой ссылки управляется независимо.
    /// </summary>
    /// <typeparam name="T">Тип COM-интерфейса SolidWorks.</typeparam>
    public class SharedSwObject<T> : SwObject<T>
    {
        #region Constructors

        /// <summary>
        /// Создает обертку над COM-объектом для безопасной работы с ним.
        /// </summary>
        /// <param name="comObject">COM-объект, который необходимо обернуть.</param>
        public SharedSwObject(T comObject) : base(comObject) { }

        #endregion

        #region Public Overrided Methods

        /// <summary>
        /// Метод для правильного очищения ресурсов.
        /// </summary>
        public override void Dispose()
        {
            if (BaseObject == null)
            {
                return;
            }

            Marshal.ReleaseComObject(BaseObject);

            BaseObject = default;
        }

        #endregion
    }
}
