using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using System;

namespace Modellic.App.SolidWorks.Documents
{
    /// <summary>
    /// Представляет собой документ сборки. Предоставляет интерфейс для работы с документом сборки.
    /// </summary>
    public class SwAssemblyDoc
    {
        #region Protected Members

        /// <summary>
        /// Документ базовой сборки, удаляемый родителем <see cref="SwModelDoc"/>.
        /// </summary>
        protected AssemblyDoc _baseObject;

        #endregion

        #region Public Properties

        //// <summary>
        /// Исходный базовый COM-объект.
        /// ОСТОРОЖНО: при использовании этого свойства освобожнение ресурсов становится ручным.
        /// </summary>
        public AssemblyDoc UnsafeObject => _baseObject;

        #endregion

        #region Constructors

        public SwAssemblyDoc(AssemblyDoc assemblyDoc)
        {
            _baseObject = assemblyDoc;
        }

        #endregion

        #region Feature Methods

        public void GetFeatureByName(string featureName, Action<SwFeature> action)
        {
            void GetFeatureNameAction()
            {
                using (var model = new SwFeature((Feature)_baseObject.FeatureByName(featureName)))
                {
                    action(model);
                }
            }

            SwObjectErrorManager.Wrap(
                GetFeatureNameAction,
                $"Не удалось получить feature по имени {featureName}",
                SwObjectErrorCode.GetFeatureByNameError
            );
        }

        #endregion
    }
}
