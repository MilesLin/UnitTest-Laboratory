﻿using JobStepAnalysis.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStepAnalysis
{
    public class BaseAnalysis
    {
        protected void UpdateCurrentStepInfo(ConcurrentDictionary<int, JobStepInfoDTOModel> stepInfos, int workOrderId, int craneId, RailMoveType moveType)
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
