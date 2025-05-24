using Modellic.App.Errors;
using System;

namespace Modellic.App.Exceptions
{
    public class SolidWorksException : Exception
    {
        #region Public Properties

        public SwObjectError Details { get; set; }

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
