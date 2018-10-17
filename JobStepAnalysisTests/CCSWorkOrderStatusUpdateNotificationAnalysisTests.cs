using JobStepAnalysis.Enums;
using JobStepAnalysis.Repositories;
using NSubstitute;
using System.Collections.Concurrent;
using Xunit;

namespace JobStepAnalysis.Tests
{
    public class CCSWorkOrderStatusUpdateNotificationAnalysisTests
    {
        [Fact()]
        public void AnalysisMessage_With_Assigned_Test()
        {
            // Arrange
            var ccs = new CCSWorkOrderStatusUpdateNotification
            {
                Crane = "1",
                WorkOrder = "1234",
                Status = "ASSIGNED"
            };

            string xml = "<?xml>";
            var moveType = RailMoveType.BufferToTrain;
            
            var jobStepRepository = Substitute.For<IJobStepRepository>();
            var converter = Substitute.For<IXMLConvertHelper>();
            converter.Deserialize<CCSWorkOrderStatusUpdateNotification>(xml).
                ReturnsForAnyArgs(ccs);

            var currentStepInfo = new ConcurrentDictionary<int, JobStepInfoDTOModel>();

            var sut = new CCSWorkOrderStatusUpdateNotificationAnalysis(
                converter,
                jobStepRepository);

            // Act
            sut.AnalysisMessage(xml, currentStepInfo);

            // Assert
            jobStepRepository.Received(1).SetStepInfo(
                1234,
                xml,
                WorkOrderJobStep.Assigned,
                WorkOrderJobStepStatus.Start
            );
            Assert.NotNull(currentStepInfo[1]);
            Assert.Equal(1234, currentStepInfo[1].RailWorkOrderId);
            Assert.Equal(1, currentStepInfo[1].CraneId);
        }

        [Fact()]
        public void AnalysisMessage_With_Picked_Test()
        {
            // Arrange
            var ccs = new CCSWorkOrderStatusUpdateNotification
            {
                Crane = "1",
                WorkOrder = "1234",
                Status = "PICKED"
            };

            string xml = "<?xml>";

            var jobStepRepository = Substitute.For<IJobStepRepository>();
            var converter = Substitute.For<IXMLConvertHelper>();
            converter.Deserialize<CCSWorkOrderStatusUpdateNotification>(xml).
                ReturnsForAnyArgs(ccs);

            var currentStepInfo = new ConcurrentDictionary<int, JobStepInfoDTOModel>();

            var sut = new CCSWorkOrderStatusUpdateNotificationAnalysis(
                converter,
                jobStepRepository);

            // Act
            sut.AnalysisMessage(xml, currentStepInfo);

            // Assert
            jobStepRepository.Received(1).SetStepInfo(
                1234,
                xml,
                WorkOrderJobStep.Picked,
                WorkOrderJobStepStatus.End
            );
        }
    }
}