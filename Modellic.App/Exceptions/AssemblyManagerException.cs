using Modellic.App.Enums;
using System;

namespace Modellic.App.Exceptions
{
    public class AssemblyManagerException : Exception
    {
        private readonly AssemblyManagerErrorCode _errorCode;

        public AssemblyManagerErrorCode ErrorCode => _errorCode;

        public AssemblyManagerException(string message, AssemblyManagerErrorCode errorCode) : base(message)
        {
            _errorCode = errorCode;
        }
    }
}
