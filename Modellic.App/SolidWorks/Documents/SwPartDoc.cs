using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using System;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Documents
{
    /// <summary>
    /// Представляет собой документ модели. Предоставляет интерфейс для работы с документом модели.
    /// </summary>
    public class SwPartDoc : SwModelDoc
    {
        #region Private Members

        private PartDoc _comObject;

        #endregion

        #region Public Properties

        public PartDoc ComObject => _comObject;

        #endregion

        #region Constructors

        public SwPartDoc(PartDoc partDoc) : base((ModelDoc2)partDoc) 
        {
            Logger.LogInformation("Создаем файл типа Part");

            _comObject = partDoc;
        }

        #endregion

        #region Feature Methods

        public void GetFeatureByName(string featureName, Action<SwFeature> action)
        {
            SwObjectErrorManager.Wrap(() =>
            {
                using (var model = new SwFeature((Feature)ComObject.FeatureByName(featureName)))
                {
                    action(model);
                }
            },
            $"Не удалось получить feature по имени {featureName}",
            SwObjectErrorCode.GetFeatureByNameError
            );
        }

        #endregion
    }
}
