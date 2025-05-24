using SolidWorks.Interop.sldworks;

namespace Modellic.App.Enums
{
    /// <summary>
    /// Общие ошибки, которые могут произойти во время работы.
    /// </summary>
    public enum SwObjectErrorType
    {
        /// <summary>
        /// Неивестная ошибка, возникающая при работе с API SolidWorks.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Ошибка, которая была поймана, но не была ожидаема.
        /// </summary>
        Unexpected = 1,

        /// <summary>
        /// Ошибка, возникающая при работе с файлом в файловой системе.
        /// </summary>
        File = 2,

        /// <summary>
        /// Ошибка, возникающая при попытке выполнить методы вырхнего уровня API SolidWorks.
        /// </summary>
        SolidWorksApplication = 11,

        /// <summary>
        /// Ошибка, возникающая при попытке выполнить вызов API SolidWorks в модели (<see cref="IModelDoc2"/>).
        /// </summary>
        SolidWorksModel = 12,

        /// <summary>
        /// Ошибка при попытке экспорта данных используя API SolidWorks.
        /// </summary>
        ExportData = 14,
    }
}
