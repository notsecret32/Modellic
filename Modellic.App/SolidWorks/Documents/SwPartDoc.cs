using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using System;

namespace Modellic.App.SolidWorks.Documents
{
    /// <summary>
    /// Представляет собой документ модели. Предоставляет интерфейс для работы с документом модели.
    /// </summary>
    public class SwPartDoc
    {
        #region Protected Members

        /// <summary>
        /// Документ базовой модели, удаляемый родителем <see cref="SwModelDoc"/>.
        /// </summary>
        protected PartDoc _baseObject;

        #endregion

        #region Public Properties

        //// <summary>
        /// Исходный базовый COM-объект.
        /// ОСТОРОЖНО: при использовании этого свойства освобожнение ресурсов становится ручным.
        /// </summary>
        public PartDoc UnsafeObject => _baseObject;

        #endregion

        #region Constructors

        public SwPartDoc(PartDoc partDoc)
        {
            _baseObject = partDoc;
        }

        #endregion

        #region Feature Methods

        public void GetFeatureByName(string featureName, Action<SwFeature> action)
        {
            SwObjectErrorManager.Wrap(() =>
            {
                using (var model = new SwFeature((Feature)_baseObject.FeatureByName(featureName)))
                {
                    action(model);
                }
            },
            $"Не удалось получить feature по имени {featureName}",
            SwObjectErrorType.SolidWorksModel,
            SwObjectErrorCode.SolidWorksModelPartGetFeatureByNameError
            );
        }

        #endregion
    }
}
