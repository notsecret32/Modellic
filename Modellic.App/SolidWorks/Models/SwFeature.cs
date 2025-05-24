using Modellic.App.Enums;
using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;

namespace Modellic.App.SolidWorks.Models
{
    public class SwFeature : SwSharedObject<Feature>
    {
        #region Protected Members

        protected SwObject<object> _specificFeature;

        protected SwObject<object> _featureData;

        #endregion

        #region Public Properties

        public SwFeatureType FeatureType => this.GetFeatureType();

        public string FeatureTypeName => GetFeatureTypeName();

        public string FeatureName => BaseObject.Name;

        public object SpecificFeature => _specificFeature?.UnsafeObject;

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
            // Clean up feature and data
            _specificFeature?.Dispose();
            _specificFeature = null;

            _featureData?.Dispose();
            _featureData = null;

            base.Dispose();
        }

        #endregion
    }
}
