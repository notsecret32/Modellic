using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Diagnostics;
using System.IO;

namespace Modellic.App.Logging
{
    /// <summary>
    /// Кастомный форматировщик вывода в консоль. Форматирует вывод в консоль.
    /// <para>
    /// Формат вывода в консоль: 
    /// <code>HH:mm:ss [LogLevel] ClassName::MethodName (FileName:LineNumber) - Message</code>
    /// </para>
    /// </summary>
    public class CustomConsoleFormatter : ConsoleFormatter
    {
        #region Constructors

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomConsoleFormatter"/>.
        /// </summary>
        public CustomConsoleFormatter() : base("CustomConsoleFormatter") { }

        #endregion

        #region Public Overrided Methods

        /// <summary>
        /// Форматирует и записывает лог-сообщение в указанный текст-райтер.
        /// </summary>
        /// <typeparam name="TState">Тип состояния лога.</typeparam>
        /// <param name="logEntry">Запись лога, содержащая информацию для логирования.</param>
        /// <param name="scopeProvider">Провайдер областей (scopes) для доступа к дополнительным данным лога.</param>
        /// <param name="textWriter">Объект для записи форматированного сообщения.</param>
        public override void Write<TState>(
            in LogEntry<TState> logEntry,
            IExternalScopeProvider scopeProvider,
            TextWriter textWriter)
        {
            var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);
            if (string.IsNullOrEmpty(message)) return;

            var callerInfo = GetCallerInfo();

            textWriter.Write($"{DateTime.Now:HH:mm:ss} ");
            textWriter.Write($"[{logEntry.LogLevel}] ");

            if (!string.IsNullOrEmpty(callerInfo))
            {
                textWriter.Write($"{callerInfo} - ");
            }

            textWriter.WriteLine(message);

            if (logEntry.Exception != null)
            {
                textWriter.WriteLine(logEntry.Exception.ToString());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Получает информацию о вызывающем методе из стека вызовов.
        /// </summary>
        /// <returns>
        /// Строка в формате: "ClassName::MethodName (FileName:LineNumber)".
        /// </returns>
        private string GetCallerInfo()
        {
            var stackTrace = new StackTrace(fNeedFileInfo: true);

            // Пропускаем кадры, связанные с системой логирования
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame?.GetMethod();
                var declaringType = method?.DeclaringType;

                if (declaringType == null) continue;

                // Пропускаем кадры из Microsoft.Extensions.Logging и нашего логгера
                if (declaringType.Namespace != null &&
                    (declaringType.Namespace.StartsWith("Microsoft.Extensions.Logging") ||
                     declaringType.Namespace.StartsWith("Modellic.App.Logging")))
                {
                    continue;
                }

                string className = declaringType.Name;
                string methodName = method.Name;

                // Обработка асинхронных методов (класс состояния имеет вид <MethodName>d__X)
                if (className.StartsWith("<") && className.Contains(">d__"))
                {
                    // Извлекаем исходное имя метода из имени класса
                    int start = className.IndexOf('<') + 1;
                    int end = className.IndexOf('>');
                    if (start > 0 && end > start)
                    {
                        // Берем имя метода
                        methodName = className.Substring(start, end - start);

                        // Берем имя родительского класса
                        className = declaringType.DeclaringType?.Name ?? className;
                    }
                }
                // Для конструкторов используем имя класса
                else if (methodName == ".ctor")
                {
                    methodName = className;
                }

                var fileName = Path.GetFileName(frame.GetFileName() ?? "UNKNOWN_FILE");
                var lineNumber = frame.GetFileLineNumber();

                return $"{className}::{methodName} ({fileName}:{lineNumber})";
            }

            return string.Empty;
        }

        #endregion
    }
}
