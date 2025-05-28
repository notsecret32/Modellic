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

        /// <summary>
        /// Сообщение ошибки.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Детали ошибки.
        /// </summary>
        public string ErrorDetails { get; set; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        public SwObjectErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Фукнция, в которой произошла ошибка.
        /// </summary>
        public string CallerMemberName { get; set; }

        /// <summary>
        /// Файл, в котором произошла ошибка.
        /// </summary>
        public string CallerFilePath { get; set; }

        /// <summary>
        /// Номер строки в которой произошла ошибка.
        /// </summary>
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
            ErrorCode = swObjectError.ErrorCode;
            CallerMemberName = swObjectError.CallerMemberName;
            CallerFilePath = swObjectError.CallerFilePath;
            CallerLineNumber = swObjectError.CallerLineNumber;
        }

        #endregion
    }
}
