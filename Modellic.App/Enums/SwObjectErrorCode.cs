namespace Modellic.App.Enums
{
    /// <summary>
    /// Список конкретных ошибок, возникающие во время выполнения каких-то операций.
    /// </summary>
    public enum SwObjectErrorCode
    {
        #region File (1,000)

        /// <summary>
        /// Неизвестная ошибка, которая произошла во время работы с файлом.
        /// </summary>
        FileUnexpectedError = 1000,

        #endregion

        #region SolidWorks Application (9,000)

        /// <summary>
        /// Ошибка при вызове API приложения.
        /// </summary>
        SolidWorksApplicationError = 9000,

        /// <summary>
        /// Ошибка, возникающая в событии до открытия файла.
        /// </summary>
        SolidWorksApplicationFilePreOpenError = 9002,

        /// <summary>
        /// Ошибка, возникающая в событии после открытия файла.
        /// </summary>
        SolidWorksApplicationFilePostOpenError = 9003,

        /// <summary>
        /// Ошибка, возникающая при изменении активного документа.
        /// </summary>
        SolidWorksApplicationActiveModelChangedError = 9004,

        /// <summary>
        /// Ошибка, возникающая при попытке получить версию SolidWorks.
        /// </summary>
        SolidWorksApplicationVersionError = 9005,

        /// <summary>
        /// Ошибка, возникающая при неудачной попытке подключиться к SolidWorks либо создать новый экземпляр.
        /// </summary>
        SolidWorksApplicationFailedToConnect = 9006,

        #endregion

        #region SolidWorks Model (11,000)

        /// <summary>
        /// Ошибка, возникающая при вызове API для документа SolidWorks.
        /// </summary>
        SolidWorksModelError = 11000,

        /// <summary>
        /// Ошибка, возникающая при неправильном преобразовании выбранного объекта в определенный тип.
        /// </summary>
        SolidWorksModelSelectedObjectCastError = 11001,

        /// <summary>
        /// Ошибка сохранения документа при вызове SaveAs (Сохранить как).
        /// </summary>
        SolidWorksModelSaveAsError = 11002,

        /// <summary>
        /// Ошибка при попытке получить модель по имени в файле сборки.
        /// </summary>
        SolidWorksModelAssemblyGetFeatureByNameError = 11003,

        /// <summary>
        /// Ошибка при попытке получить модель по имени в файле модели.
        /// </summary>
        SolidWorksModelPartGetFeatureByNameError = 11004,

        /// <summary>
        /// Ошибка при попытке сохранить документ.
        /// </summary>
        SolidWorksModelSaveError = 11005,

        /// <summary>
        /// Ошибка при попытке открыть документ.
        /// </summary>
        SolidWorksModelOpenError = 11006,

        /// <summary>
        /// Ошибка при попытке закрыть документ.
        /// </summary>
        SolidWorksModelCloseError = 11007,

        #endregion

        #region Export Data (13,000)

        /// <summary>
        /// Ошибка, возникающая при попытке вызова API SolidWorks для экспорта данных.
        /// </summary>
        SolidWorksExportDataError = 13000,

        #endregion
    }
}
