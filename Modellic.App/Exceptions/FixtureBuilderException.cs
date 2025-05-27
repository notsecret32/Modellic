using Modellic.App.Core.Services;
using Modellic.App.Enums;
using System;

namespace Modellic.App.Exceptions
{
    /// <summary>
    /// Представляет ошибки, возникающие в <see cref="FixtureBuilder"/>.
    /// </summary>
    public class FixtureBuilderException : Exception
    {
        public FixtureBuilderErrorCode ErrorCode { get; protected set; }

        public FixtureBuilderException(string message, FixtureBuilderErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
