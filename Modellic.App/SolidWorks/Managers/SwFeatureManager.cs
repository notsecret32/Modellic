using Microsoft.Extensions.Logging;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Managers.Helpers;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using static Modellic.App.Logging.LoggerService;

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

            Logger.LogInformation($"FeatureExtrusion3({isSingleDirection}, {flipDirection}, {reverseExtrudeSide}, {endExtrusionParameters1.EndCondition}, " +
                $"{endCondition2}, {endExtrusionParameters1.Depth}, {depth2}, {endExtrusionParameters1.EnableDraft}, {enableDraft2}, {endExtrusionParameters1.IsDraftInward}, " +
                $"{isDraftInward2}, {endExtrusionParameters1.DraftAngle}, {draftAngle2}, {endExtrusionParameters1.ReverseOffset}, {reverseOffset2}, {endExtrusionParameters1.TranslateSurface}, " +
                $"{translateSurface2}, {mergeResult}, {useFeatureScope}, {autoSelectBodies}, {startExtrusionParameters.StartCondition}, {startExtrusionParameters.StartOffset}, " +
                $"{startExtrusionParameters.ReverseStartOffset})");

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

        public SwFeature FeatureExtrusion(
            string name,
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
            SwFeature feature = FeatureExtrusion(
                startExtrusionParameters, 
                endExtrusionParameters1, 
                endExtrusionParameters2, 
                isSingleDirection, 
                flipDirection, 
                reverseExtrudeSide, 
                mergeResult, 
                useFeatureScope,
                autoSelectBodies
            );

            feature.Name = name;

            return feature;
        }

        public SwFeature FeatureCut(
            StartExtrusionParameters startExtrusionParameters,
            EndExtrusionParameters endExtrusionParameters1,
            EndExtrusionParameters endExtrusionParameters2 = null,
            bool isSingleDirection = true,
            bool flipDirection = false,
            bool reverseExtrudeSide = false,
            bool normalCut = false,
            bool useFeatureScope = true,
            bool autoSelectBodies = true,
            bool assemblyFeatureScope = true,
            bool autoSelectComponents = true,
            bool propagateFeatureToPart = false,
            bool optimizeGeometry = false)
        {
            if (startExtrusionParameters == null)
                throw new ArgumentNullException(nameof(startExtrusionParameters));

            if (endExtrusionParameters1 == null)
                throw new ArgumentNullException(nameof(endExtrusionParameters1));

            var endCondition2 = endExtrusionParameters2?.EndCondition ?? swEndConditions_e.swEndCondBlind;
            var depth2 = endExtrusionParameters2?.Depth ?? 0;
            var enableDraft2 = endExtrusionParameters2?.EnableDraft ?? false;
            var isDraftInward2 = endExtrusionParameters2?.IsDraftInward ?? false;
            var draftAngle2 = endExtrusionParameters2?.DraftAngle ?? 0;
            var reverseOffset2 = endExtrusionParameters2?.ReverseOffset ?? false;
            var translateSurface2 = endExtrusionParameters2?.TranslateSurface ?? false;

            Logger.LogInformation($"FeatureExtrusion3({isSingleDirection}, {flipDirection}, {reverseExtrudeSide}, {endExtrusionParameters1.EndCondition}, " +
                $"{endCondition2}, {endExtrusionParameters1.Depth}, {depth2}, {endExtrusionParameters1.EnableDraft}, {enableDraft2}, {endExtrusionParameters1.IsDraftInward}, " +
                $"{isDraftInward2}, {endExtrusionParameters1.DraftAngle}, {draftAngle2}, {endExtrusionParameters1.ReverseOffset}, {reverseOffset2}, {endExtrusionParameters1.TranslateSurface}, " +
                $"{translateSurface2}, {normalCut}, {useFeatureScope}, {autoSelectBodies}, {assemblyFeatureScope}, {autoSelectComponents}, {propagateFeatureToPart}, " +
                $"{startExtrusionParameters.StartCondition}, {startExtrusionParameters.StartOffset}, {startExtrusionParameters.ReverseStartOffset}, {optimizeGeometry})");

            var createdFeature = BaseObject.FeatureCut4(
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
                normalCut,
                useFeatureScope,
                autoSelectBodies,
                assemblyFeatureScope,
                autoSelectComponents,
                propagateFeatureToPart,
                (int)startExtrusionParameters.StartCondition,
                startExtrusionParameters.StartOffset,
                startExtrusionParameters.ReverseStartOffset,
                optimizeGeometry
            );

            return new SwFeature(createdFeature);
        }

        #endregion
    }
}
