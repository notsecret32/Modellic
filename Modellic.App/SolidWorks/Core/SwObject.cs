using System;
using System.Runtime.InteropServices;

namespace Modellic.App.SolidWorks.Core
{
    /// <summary>
    /// Базовый класс для работы с COM-объектами SolidWorks.
    /// Предоставляет базовую функциональность для хранения и доступа к COM-объектам.
    /// </summary>
    public class SwObject
    {
        #region Protected Members

        /// <summary>
        /// Базовый COM-объект, хранящийся как object.
        /// </summary>
        protected object _baseObject;

        #endregion

        #region Public Properties

        /// <summary>
        /// COM-объект без типизации.
        /// </summary>
        public object UnsafeObject => _baseObject;

        #endregion
    }

    /// <summary>
    /// Обобщённая версия SwObject с типизированным доступом к COM-объекту.
    /// Реализует IDisposable для корректного освобождения COM-ресурсов.
    /// </summary>
    /// <typeparam name="T">Тип COM-интерфейса SolidWorks.</typeparam>
    public class SwObject<T> : SwObject, IDisposable
    {
        #region Protected Properties

        /// <summary>
        /// COM-объект, который должен быть правильно очищен.
        /// </summary>
        protected T BaseObject
        {
            get => (T)_baseObject;
            set => _baseObject = value;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Исходный базовый COM-объект.
        /// ОСТОРОЖНО: при использовании этого свойства освобожнение ресурсов становится ручным.
        /// </summary>
        public new T UnsafeObject => BaseObject;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает обертку над COM-объектом для безопасной работы с ним.
        /// </summary>
        /// <param name="comObject">COM-объект, который необходимо обернуть.</param>
        public SwObject(T comObject)
        {
            BaseObject = comObject;
        }

        #endregion

        #region Public Overrided Methods

        /// <summary>
        /// Метод для правильного очищения ресурсов.
        /// </summary>
        public virtual void Dispose()
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
