using JobStepAnalysis.Enums;
using JobStepAnalysis.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStepAnalysis
{
    public class CCSWorkOrderStatusUpdateNotificationAnalysis : IAnalysis
    {
        private readonly IXMLConvertHelper _XMLConvertHelper;
        private readonly IRailWorkOrderRepository _railWorkOrderRepository;
        private readonly IJopStepRepository _jopStepRepository;

        public CCSWorkOrderStatusUpdateNotificationAnalysis(
            IXMLConvertHelper XMLConvertHelper,
            IRailWorkOrderRepository railWorkOrderRepository,
            IJopStepRepository jopStepRepository
            )
        {
            this._XMLConvertHelper = XMLConvertHelper;
            this._railWorkOrderRepository = railWorkOrderRepository;
            this._jopStepRepository = jopStepRepository;
        }

        public void AnalysisMessage(string xml, ConcurrentDictionary<int, JobStepInfoDTOModel> currentStepInfo)
        {
            var ccs = _XMLConvertHelper.Deserialize<CCSWorkOrderStatusUpdateNotification>(xml);

            int.TryParse(ccs.WorkOrder, out int workOrderId);
            int.TryParse(ccs.Crane, out int craneId);

            if (ccs.Status == "ASSIGNED")
            {
                RailMoveType railMoveType = this._railWorkOrderRepository.GetRailMoveType(workOrderId);

                this._jopStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.Assigned, WorkOrderJobStepStatus.Start);

                this.UpdateCurrentStepInfo(currentStepInfo, workOrderId, craneId, railMoveType);
            }
            else if (ccs.Status == "PICKED")
            {
                this._jopStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.Picked, WorkOrderJobStepStatus.End);

                // 客戶想要 Picked 結束後，直接開始 Moving to target
                this._jopStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.MovingToTarget, WorkOrderJobStepStatus.Start);
            }
        }

        private void UpdateCurrentStepInfo(ConcurrentDictionary<int, JobStepInfoDTOModel> stepInfos, int workOrderId, int craneId, RailMoveType moveType)
        {
            var newValue = new JobStepInfoDTOModel()
            {
                RailWorkOrderId = workOrderId,
                CraneId = craneId,
                RailMoveType = moveType
            };

            stepInfos.AddOrUpdate(craneId, newValue, (key, oldValue) => newValue);
        }
    }
}
