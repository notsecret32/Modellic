using Modellic.App.Enums;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Core;
using System;
using System.Threading.Tasks;

namespace Modellic.App.Errors
{
    /// <summary>
    /// Менеджер по созданию и управлению ошибками, произошедшие при работе с <see cref="SwObject"/>.
    /// </summary>
    public static class SwObjectErrorManager
    {
        #region Public Methods

        public static SwObjectError CreateError(string message, SwObjectErrorType errorType, SwObjectErrorCode errorCode, Exception innerException = null)
        {
            SwObjectError error = new SwObjectError
            {
                ErrorMessage = message,
                ErrorType = errorType,
                ErrorCode = errorCode
            };

            if (innerException != null)
            {
                error.ErrorDetails = $"{error.ErrorDetails}. Исключение ({innerException.GetType()}: {innerException.Message}";
            }

            return error;
        }

        public static void Wrap(Action action, string message, SwObjectErrorType errorType, SwObjectErrorCode errorCode)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                SolidWorksException error = new SolidWorksException(
                    SwObjectErrorManager.CreateError(message, errorType, errorCode),
                    ex
                );

                throw error;
            }
        }

        public static T Wrap<T>(Func<T> callback, string message, SwObjectErrorType errorType, SwObjectErrorCode errorCode)
        {
            try
            {
                return callback();
            }
            catch (Exception ex)
            {
                SolidWorksException error = new SolidWorksException(
                    SwObjectErrorManager.CreateError(message, errorType, errorCode),
                    ex
                );

                throw error;
            }
        }

        public static async Task WrapAsync(Func<Task> callback, string message, SwObjectErrorType errorType, SwObjectErrorCode errorCode)
        {
            try
            {
                await callback();
            }
            catch (Exception ex)
            {
                SolidWorksException error = new SolidWorksException(
                    SwObjectErrorManager.CreateError(message, errorType, errorCode),
                    ex
                );

                throw error;
            }
        }

        public static async Task<T> WrapAsync<T>(Func<Task<T>> callback, string message, SwObjectErrorType errorType, SwObjectErrorCode errorCode)
        {
            try
            {
                return await callback();
            }
            catch (Exception ex)
            {
                SolidWorksException error = new SolidWorksException(
                    SwObjectErrorManager.CreateError(message, errorType, errorCode),
                    ex
                );

                throw error;
            }
        }

        #endregion
    }
}
