namespace Modellic.App.Enums
{
    /// <summary>
    /// Список конкретных ошибок, возникающие во время выполнения каких-то операций.
    /// </summary>
    public enum SwObjectErrorCode
    {
        #region SolidWorks Application (1,000)

        /// <summary>
        /// Ошибка при попытке подключиться к SolidWorks
        /// </summary>
        ConnectionFailed = 1000,

        #endregion

        #region File Open / Save (2,000)

        /// <summary>
        /// Возникает при неудачной попытке создать документ модели.
        /// </summary>
        PartDocumentCreationFailed = 2000,

        #endregion

        #region Document (3,000)

        #endregion

        #region Part Document (4,000)

        #endregion

        #region Assembly Document (5,000)

        #endregion

        #region Extension (10,000)

        #endregion

        #region Feature Manager (11,000)

        #endregion

        #region Selection Manager (12,000)

        /// <summary>
        /// Ошибка при попытке преобразовать выбранный элемент.
        /// </summary>
        SelectedObjectCaseFailed = 12000,

        #endregion

        #region Sketch Manager (13,000)

        /// <summary>
        /// Ошибка при попытке переименовать эскиз.
        /// </summary>
        SketchRenameFailed = 13000,

        /// <summary>
        /// Ошибка при работе с эскизом.
        /// </summary>
        SketchCreationFailed = 13001,

        #endregion

        #region Feature (20,000)

        /// <summary>
        /// Ошибка при попытке получить Feature по имени.
        /// </summary>
        GetFeatureByNameError = 20000,

        #endregion
    }
}
