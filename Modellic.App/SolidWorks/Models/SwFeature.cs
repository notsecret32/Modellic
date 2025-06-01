using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Models
{
    /// <summary>
    /// Представляет собой Feature любого типа.
    /// ВАЖНО: Это <see cref="SwSharedObject{T}"/>, который должен быть очищен в <see cref="SwSelectedObject"/>.
    /// </summary>
    public class SwFeature : SwSharedObject<Feature>
    {
        #region Protected Members

        /// <summary>
        /// Конкретная Feature для данной Feature, если таковая имеется.
        /// </summary>
        protected SwObject<object> _specificFeature;

        /// <summary>
        /// Данные Feature для данной Feature, если таковая имеется.
        /// </summary>
        protected SwObject<object> _featureData;

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                return BaseObject.Name;
            }
            set
            {
                if (value != BaseObject.Name)
                {
                    BaseObject.Name = value;
                }
            }
        }

        /// <summary>
        /// Конкретный тип Feature.
        /// </summary>
        public SwFeatureType FeatureType => this.GetFeatureType();

        /// <summary>
        /// Возвращает имя типа элемента SolidWorks. 
        /// </summary>
        public string FeatureTypeName => GetFeatureTypeName();

        /// <summary>
        /// Возвращает имя элемента SolidWorks.
        /// </summary>
        public string FeatureName => BaseObject.Name;

        /// <summary>
        /// Конкретная Feature для данной Feature, если таковая имеется.
        /// ПРИМЕЧАНИЕ: Это COM-объект. После этого необходимо установить для всех переменных экземпляра значение null, если было установлено какое-либо.
        /// </summary>
        public object SpecificFeature => _specificFeature?.UnsafeObject;

        /// <summary>
        /// Данные Feature для данной Feature, если таковая имеется.
        /// ПРИМЕЧАНИЕ: Это COM-объект. После этого необходимо установить для всех переменных экземпляра значение null, если было установлено какое-либо.
        /// </summary>
        public object FeatureData => _featureData?.UnsafeObject;

        #endregion

        #region Constructor

        public SwFeature(Feature feature) : base(feature)
        {
            // Get the specific feature
            _specificFeature = new SwObject<object>(feature?.GetSpecificFeature2());

            // Get the definition
            _featureData = new SwObject<object>(feature?.GetDefinition());
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Возвращает тип Feature.
        /// </summary>
        /// <returns>Тип <see cref="SwFeatureType"/> для данной Feature.</returns>
        public SwFeatureType GetFeatureType()
        {
            // Проверяем, что feature не пустой
            if (FeatureTypeName == null || string.IsNullOrEmpty(FeatureTypeName))
            {
                return SwFeatureType.None;
            }

            return FeatureTypeName switch
            {
                _ => SwFeatureType.None,
            };
        }

        #endregion

        #region Protected Helpers

        /// <summary>
        /// Возвращает имя типа Feature.
        /// </summary>
        /// <returns>Имя типа Feature.</returns>
        protected string GetFeatureTypeName()
        {
            return BaseObject.GetTypeName2();
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return $"Название: {FeatureName}. Тип: {FeatureTypeName}";
        }

        #endregion

        #region Dispose

        public override void Dispose()
        {
            // Очищаем Feature и данные
            _specificFeature?.Dispose();
            _specificFeature = null;

            _featureData?.Dispose();
            _featureData = null;

            base.Dispose();
        }

        #endregion
    }
}
