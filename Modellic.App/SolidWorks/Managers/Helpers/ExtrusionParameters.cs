using SolidWorks.Interop.swconst;

namespace Modellic.App.SolidWorks.Managers.Helpers
{
    public class StartExtrusionParameters
    {
        public swStartConditions_e StartCondition { get; set; }

        public double StartOffset { get; set; }

        public bool ReverseStartOffset { get; set; }

        public StartExtrusionParameters(swStartConditions_e startConditions, double startOffset, bool reverseStartOffset)
        {
            StartCondition = startConditions;
            StartOffset = startOffset;
            ReverseStartOffset = reverseStartOffset;
        }
    }

    public class EndExtrusionParameters
    {
        public swEndConditions_e EndCondition { get; set; }

        public double Depth { get; set; }
        
        public bool EnableDraft { get; set; }
        
        public double DraftAngle { get; set; }

        public bool IsDraftInward { get; set; }
        
        public bool ReverseOffset { get; set; }
        
        public bool TranslateSurface { get; set; }

        public EndExtrusionParameters(swEndConditions_e endConditions, double depth, bool enableDraft, double draftAngle, bool isDraftInward, bool reverseOffset, bool translateSurface)
        {
            EndCondition = endConditions;
            Depth = depth;
            EnableDraft = enableDraft;
            DraftAngle = draftAngle;
            IsDraftInward = isDraftInward;
            ReverseOffset = reverseOffset;
            TranslateSurface = translateSurface;
        }
    }
}
