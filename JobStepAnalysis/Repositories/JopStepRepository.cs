﻿using JobStepAnalysis.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStepAnalysis.Repositories
{
    public class JopStepRepository : IJopStepRepository
    {
        public void SetStepInfo(int workOrderId, string message, WorkOrderJobStep jobStep, WorkOrderJobStepStatus jopStepStatus)
        {
            throw new NotImplementedException();
        }
    }

    public interface IJopStepRepository
    {
        void SetStepInfo(int workOrderId, string message, WorkOrderJobStep jobStep, WorkOrderJobStepStatus jopStepStatus);
    }
}
