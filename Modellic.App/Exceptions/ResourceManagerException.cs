using Modellic.App.Enums;
using System;

namespace Modellic.App.Exceptions
{
    public class ResourceManagerException : Exception
    {
        private readonly ResourceManagerErrorCode _errorCode;

        public ResourceManagerErrorCode ErrorCode => _errorCode;

        public ResourceManagerException(string message,  ResourceManagerErrorCode errorCode) : base(message)
        {
            _errorCode = errorCode;
        }
    }
}
