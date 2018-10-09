using JobStepAnalysis.Enums;

namespace JobStepAnalysis
{
    public class JobStepInfoDTOModel
    {
        public int RailWorkOrderId { get; internal set; }
        public int CraneId { get; internal set; }
        public RailMoveType RailMoveType { get; internal set; }
    }
}