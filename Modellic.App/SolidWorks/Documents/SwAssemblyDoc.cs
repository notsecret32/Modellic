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
    /// Представляет собой документ сборки. Предоставляет интерфейс для работы с документом сборки.
    /// </summary>
    public class SwAssemblyDoc : SwModelDoc
    {
        #region Private Members

        private AssemblyDoc _comObject;

        #endregion

        #region Public Properties

        public AssemblyDoc ComObject => _comObject;

        #endregion

        #region Constructors

        public SwAssemblyDoc(AssemblyDoc assemblyDoc) : base((ModelDoc2)assemblyDoc)
        {
            Logger.LogInformation("Создаем файл типа Assembly");

            _comObject = assemblyDoc;
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
