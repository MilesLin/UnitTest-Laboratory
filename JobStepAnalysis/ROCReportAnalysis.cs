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
    class ROCReportAnalysis : IAnalysis
    {
        private readonly IXMLConvertHelper _XMLConvertHelper;
        private readonly IJobStepRepository _jobStepRepository;

        public ROCReportAnalysis(
            IXMLConvertHelper XMLConvertHelper,
            IJobStepRepository jobStepRepository
            )
        {
            this._XMLConvertHelper = XMLConvertHelper;
            this._jobStepRepository = jobStepRepository;
        }

        public void AnalysisMessage(string xml, ConcurrentDictionary<int, JobStepInfoDTOModel> currentStepInfo)
        {
            var ccs = _XMLConvertHelper.Deserialize<ROCReport>(xml);

            int.TryParse(ccs.WorkOrder, out int workOrderId);
            int.TryParse(ccs.Crane, out int craneId);

            if (ccs.Status == "ASSIGNED")
            {
                this._jobStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.Assigned, WorkOrderJobStepStatus.Start);
            }
            else if (ccs.Status == "PICKED")
            {
                this._jobStepRepository.SetStepInfo(workOrderId, xml, WorkOrderJobStep.Picked, WorkOrderJobStepStatus.End);
            }
        }
    }

    internal class ROCReport
    {
        public string WorkOrder { get; internal set; }
        public string Crane { get; internal set; }
        public string Status { get; internal set; }
    }
}
