using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using System.Runtime.CompilerServices;

namespace Modellic.App.Errors
{
    /// <summary>
    /// Детали ошибки произошедшие в <see cref="SwObject"/>.
    /// </summary>
    public class SwObjectError
    {
        #region Public Properties

        public string ErrorMessage { get; set; }

        public string ErrorDetails { get; set; }

        public SwObjectErrorType ErrorType { get; set; }

        public SwObjectErrorCode ErrorCode { get; set; }

        public string CallerMemberName { get; set; }

        public string CallerFilePath { get; set; }

        public int CallerLineNumber { get; set; }

        #endregion

        #region Constructors

        public SwObjectError([CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            CallerMemberName = callerMemberName;
            CallerFilePath = callerFilePath;
            CallerLineNumber = callerLineNumber;
        }

        public SwObjectError(SwObjectError swObjectError)
        {
            ErrorMessage = swObjectError.ErrorMessage;
            ErrorDetails = swObjectError.ErrorDetails;
            ErrorType = swObjectError.ErrorType;
            ErrorCode = swObjectError.ErrorCode;
            CallerMemberName = swObjectError.CallerMemberName;
            CallerFilePath = swObjectError.CallerFilePath;
            CallerLineNumber = swObjectError.CallerLineNumber;
        }

        #endregion
    }
}
