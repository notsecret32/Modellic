using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Managers.Helpers;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Предоставляет доступ к менеджеру выбранных элементов.
    /// </summary>
    public class SwFeatureManager : SwObject<FeatureManager>
    {
        #region Constructors

        public SwFeatureManager(FeatureManager featureManager) : base(featureManager)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Создает операцию выдавливания в SOLIDWORKS с указанными параметрами.
        /// </summary>
        /// <returns>Созданная операция выдавливания.</returns>
        public SwFeature FeatureExtrusion(
            StartExtrusionParameters startExtrusionParameters,
            EndExtrusionParameters endExtrusionParameters1,
            EndExtrusionParameters endExtrusionParameters2 = null,
            bool isSingleDirection = true,
            bool flipDirection = false,
            bool reverseExtrudeSide = false,
            bool mergeResult = true,
            bool useFeatureScope = false,
            bool autoSelectBodies = true)
        {
            if (startExtrusionParameters == null)
                throw new ArgumentNullException(nameof(startExtrusionParameters));

            if (endExtrusionParameters1 == null)
                throw new ArgumentNullException(nameof(endExtrusionParameters1));

            var endCondition2 = endExtrusionParameters2?.EndCondition ?? 0;
            var depth2 = endExtrusionParameters2?.Depth ?? 0;
            var enableDraft2 = endExtrusionParameters2?.EnableDraft ?? false;
            var isDraftInward2 = endExtrusionParameters2?.IsDraftInward ?? false;
            var draftAngle2 = endExtrusionParameters2?.DraftAngle ?? 0;
            var reverseOffset2 = endExtrusionParameters2?.ReverseOffset ?? false;
            var translateSurface2 = endExtrusionParameters2?.TranslateSurface ?? false;

            Feature createdFeature = BaseObject.FeatureExtrusion3(
                isSingleDirection,
                flipDirection,
                reverseExtrudeSide,
                (int)endExtrusionParameters1.EndCondition,
                (int)endCondition2,
                endExtrusionParameters1.Depth,
                depth2,
                endExtrusionParameters1.EnableDraft,
                enableDraft2,
                endExtrusionParameters1.IsDraftInward,
                isDraftInward2,
                endExtrusionParameters1.DraftAngle,
                draftAngle2,
                endExtrusionParameters1.ReverseOffset,
                reverseOffset2,
                endExtrusionParameters1.TranslateSurface,
                translateSurface2,
                mergeResult,
                useFeatureScope,
                autoSelectBodies,
                (int)startExtrusionParameters.StartCondition,
                startExtrusionParameters.StartOffset,
                startExtrusionParameters.ReverseStartOffset);

            return new SwFeature(createdFeature);
        }

        #endregion
    }
}
