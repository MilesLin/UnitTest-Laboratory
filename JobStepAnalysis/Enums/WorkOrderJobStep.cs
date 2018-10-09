using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStepAnalysis.Enums
{
    public enum WorkOrderJobStep
    {
        Assigned = 0,
        MovingToSource = 1,
        RequestingReservation = 2,
        Picking = 3,
        Picked = 4,
        ReleasingReservation = 5,
        MovingToTarget = 6,
        RequestingRCDesk = 7,
        Grounding = 8,
        Grounded = 9,
        ReportedToTW = 10,
        WorkOrderComplete = 11,
        RequestingRCDesk2 = 12,
        RequestingReservation2 = 13,
        ReleasingReservation2 = 14,
    }
}
