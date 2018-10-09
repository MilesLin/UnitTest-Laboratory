using JobStepAnalysis.Enums;
using System;

namespace JobStepAnalysis.Repositories
{
    public class RailWorkOrderRepository : IRailWorkOrderRepository
    {
        public RailMoveType GetRailMoveType(int workOrderId)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRailWorkOrderRepository
    {
        RailMoveType GetRailMoveType(int workOrderId);
    }
}