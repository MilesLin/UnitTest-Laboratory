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
    public class CCSWorkOrderStatusUpdateNotificationAnalysis: BaseAnalysis, IAnalysis
    {
        private readonly IXMLConvertHelper _XMLConvertHelper;
        private readonly IRailWorkOrderRepository _railWorkOrderRepository;
        private readonly IJobStepRepository _jobStepRepository;

        public CCSWorkOrderStatusUpdateNotificationAnalysis(
            IXMLConvertHelper XMLConvertHelper,
            IRailWorkOrderRepository railWorkOrderRepository,
            IJobStepRepository jobStepRepository
            )
        {
            this._XMLConvertHelper = XMLConvertHelper;
            this._railWorkOrderRepository = railWorkOrderRepository;
            this._jobStepRepository = jobStepRepository;
        }

        public void AnalysisMessage(string xml, ConcurrentDictionary<int, JobStepInfoDTOModel> currentStepInfo)
        {
            var ccs = _XMLConvertHelper.Deserialize<CCSWorkOrderStatusUpdateNotification>(xml);

            int.TryParse(ccs.WorkOrder, out int workOrderId);
            int.TryParse(ccs.Crane, out int craneId);

            if (ccs.Status == "ASSIGNED")
            {
                RailMoveType railMoveType = this._railWorkOrderRepository.GetRailMoveType(workOrderId);

                this._jobStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.Assigned, WorkOrderJobStepStatus.Start);

                this.UpdateCurrentStepInfo(currentStepInfo, workOrderId, craneId, railMoveType);
            }
            else if (ccs.Status == "PICKED")
            {
                this._jobStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.Picked, WorkOrderJobStepStatus.End);

                // 客戶要求，收到 Pick 後，要把前面的狀態也設定會結束
                // Train to Buffer 結束 Requesting RC
                // Buffer to Buffer 結束 Requesting Res
                //this._jobStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.RequestingRCDesk, WorkOrderJobStepStatus.End);
            }
        }
    }
}
