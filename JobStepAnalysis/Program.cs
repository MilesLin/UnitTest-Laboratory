using JobStepAnalysis.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStepAnalysis
{
    public class Program
    {
        private static ConcurrentDictionary<int, JobStepInfoDTOModel> _stepInfos = new ConcurrentDictionary<int, JobStepInfoDTOModel>();

        private static void Main(string[] args)
        {
            // 建立 Comsumer, 去訂閱 Crane 的訊息通知
            var comsumer = new JmsConsumer();
            comsumer.StartConsumer(new JmsParametersDTOModel
            {
                JmsURI = "10.1.1.1",
                JmsDestinationName = "Crane",
            });
            
            // 收到訊息後會執行的方法
            comsumer.MessageReporter += JmsConsumerOnMessageReporterEvent;
        }

        private static void JmsConsumerOnMessageReporterEvent(object sender, OnJmsMessageReporter args)
        {
            // 取得 XML 訊息
            string xml = args.Message;
            IAnalysis analysis = null;

            // new 處理訊息的實體類別
            switch (args.TagName)
            {
                case "ROCReport":
                    analysis = new ROCReportAnalysis(new XMLConvertHelper(), new JobStepRepository());
                    break;

                case "CCSWorkOrderStatusUpdateNotification":
                    //
                    analysis = new CCSWorkOrderStatusUpdateNotificationAnalysis(new XMLConvertHelper(), new JobStepRepository());
                    break;
            }

            analysis?.AnalysisMessage(xml, _stepInfos);
        }
    }

    internal class JmsParametersDTOModel
    {
        public object JmsURI { get; set; }
        public object JmsDestinationName { get; set; }
        public object UserName { get; set; }
        public object Password { get; set; }
        public string JmsClientId { get; set; }
        public bool IsAutoAck { get; set; }
    }

    internal class JmsConsumer
    {
        public event EventHandler<OnJmsMessageReporter> MessageReporter;

        public JmsConsumer()
        {
        }

        internal void StartConsumer(JmsParametersDTOModel jmsParametersDTOModel)
        {
            throw new NotImplementedException();
        }
    }

    public class OnJmsMessageReporter
    {
        public string Message { get; set; }

        public string TagName { get; set; }
    }
}
