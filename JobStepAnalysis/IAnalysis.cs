using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStepAnalysis
{
    public interface IAnalysis
    {
        void AnalysisMessage(string xmlModel, ConcurrentDictionary<int, JobStepInfoDTOModel> currentStepInfo);
    }
}
