using Modellic.App.Errors;
using System;

namespace Modellic.App.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при неправильной работе с SolidWorks.
    /// </summary>
    public class SolidWorksException : Exception
    {
        #region Public Properties

        /// <summary>
        /// Детали ошибки.
        /// </summary>
        public SwObjectError Details { get; set; }

        /// <summary>
        /// Данные оригинальной ошибки.
        /// </summary>
        public new Exception InnerException { get; set; }

        #endregion

        #region Constructors

        public SolidWorksException(SwObjectError details)
        {
            Details = details;
            InnerException = default;
        }

        public SolidWorksException(SwObjectError details, Exception innerException)
        {
            Details = details;
            InnerException = innerException;
        }

        #endregion
    }
}
