using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobStepAnalysis
{
    [XmlRoot(ElementName = "CCSWorkOrderStatusUpdateNotification", Namespace = "http://www.syncrotess.com/terminal/ccs")]
    public class CCSWorkOrderStatusUpdateNotification
    {
        [XmlElement(ElementName = "sessionInfo", Namespace = "http://www.syncrotess.com/common")]
        public SessionInfo SessionInfo { get; set; }

        [XmlElement(ElementName = "workOrder", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string WorkOrder { get; set; }

        [XmlElement(ElementName = "workOrderInfo", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public WorkOrderInfo WorkOrderInfo { get; set; }

        [XmlElement(ElementName = "status", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string Status { get; set; }

        [XmlElement(ElementName = "crane", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string Crane { get; set; }

        [XmlElement(ElementName = "craneStates", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public CraneStates CraneStates { get; set; }

        [XmlElement(ElementName = "containerWeight", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string ContainerWeight { get; set; }

        [XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns2 { get; set; }

        [XmlAttribute(AttributeName = "ns4", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns4 { get; set; }

        [XmlAttribute(AttributeName = "ns3", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Ns3 { get; set; }
    }

    [XmlRoot(ElementName = "sessionInfo", Namespace = "http://www.syncrotess.com/common")]
    public class SessionInfo
    {
        [XmlElement(ElementName = "timeStamp", Namespace = "http://www.syncrotess.com/common")]
        public string TimeStamp { get; set; }

        [XmlElement(ElementName = "version", Namespace = "http://www.syncrotess.com/common")]
        public string Version { get; set; }

        [XmlElement(ElementName = "sessionId", Namespace = "http://www.syncrotess.com/common")]
        public string SessionId { get; set; }
    }

    [XmlRoot(ElementName = "workOrderInfo", Namespace = "http://www.syncrotess.com/terminal/ccs")]
    public class WorkOrderInfo
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "craneState", Namespace = "http://www.syncrotess.com/terminal/ccs")]
    public class CraneState
    {
        [XmlElement(ElementName = "crane", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string Crane { get; set; }

        [XmlElement(ElementName = "x", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string X { get; set; }

        [XmlElement(ElementName = "y", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string Y { get; set; }

        [XmlElement(ElementName = "z", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string Z { get; set; }

        [XmlElement(ElementName = "twlClosed", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string TwlClosed { get; set; }

        [XmlElement(ElementName = "spreaderTwin", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string SpreaderTwin { get; set; }

        [XmlElement(ElementName = "spreaderLength", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string SpreaderLength { get; set; }

        [XmlElement(ElementName = "controlStatus", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public string ControlStatus { get; set; }
    }

    [XmlRoot(ElementName = "craneStates", Namespace = "http://www.syncrotess.com/terminal/ccs")]
    public class CraneStates
    {
        [XmlElement(ElementName = "craneState", Namespace = "http://www.syncrotess.com/terminal/ccs")]
        public List<CraneState> CraneState { get; set; }
    }
}
