using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Объект представляющий выбранный элемент в приложении SolidWorks.
    /// Доступ к выбранному объекту происходит через <see cref="SwSelectionManager"/>.
    /// </summary>
    public class SwSelectedObject : SwObject<object>
    {
        #region Public Properties

        /// <summary>
        /// Тип выбранного элемента.
        /// </summary>
        public swSelectType_e ObjectType { get; set; }

        /// <summary>
        /// Флаг, указывающий является ли этот объект Feature.
        /// </summary>
        public bool IsFeature => ObjectType == swSelectType_e.swSelDATUMPLANES ||
            ObjectType == swSelectType_e.swSelDATUMAXES ||
            ObjectType == swSelectType_e.swSelDATUMPOINTS ||
            ObjectType == swSelectType_e.swSelATTRIBUTES ||
            ObjectType == swSelectType_e.swSelSKETCHES ||
            ObjectType == swSelectType_e.swSelSECTIONLINES ||
            ObjectType == swSelectType_e.swSelDETAILCIRCLES ||
            ObjectType == swSelectType_e.swSelMATES ||
            ObjectType == swSelectType_e.swSelBODYFEATURES ||
            ObjectType == swSelectType_e.swSelREFCURVES ||
            ObjectType == swSelectType_e.swSelREFERENCECURVES ||
            ObjectType == swSelectType_e.swSelCTHREADS ||
            ObjectType == swSelectType_e.swSelCONFIGURATIONS ||
            ObjectType == swSelectType_e.swSelREFSILHOUETTE ||
            ObjectType == swSelectType_e.swSelCAMERAS ||
            ObjectType == swSelectType_e.swSelSWIFTANNOTATIONS ||
            ObjectType == swSelectType_e.swSelSWIFTFEATURES;

        /// <summary>
        /// Флаг, указывающий является ли этот объект плоскостью.
        /// </summary>
        public bool IsDimension => ObjectType == swSelectType_e.swSelDIMENSIONS;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Создает выбранный элемент.
        /// </summary>
        /// <param name="model">Выбранный элемент.</param>
        public SwSelectedObject(object model) : base(model)
        {

        }

        #endregion

        #region Type Case

        /// <summary>
        /// Преобразует объект в тип <see cref="SwFeature"/>.
        /// </summary>
        /// <param name="action">Лямбда, принимающая преобразованный объект.</param>
        public void AsFeature(Action<SwFeature> action)
        {
            void CastToFeature()
            {
                using (var model = new SwFeature((Feature)BaseObject))
                {
                    action(model);
                }
            }

            SwObjectErrorManager.Wrap(
                CastToFeature,
                "Не удалось преобразовать выбранный элемент в Feature",
                SwObjectErrorType.SolidWorksModel,
                SwObjectErrorCode.SolidWorksModelSelectedObjectCastError
            );
        }

        #endregion
    }
}
