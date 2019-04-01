using NUnit.Framework;
using Tfl.RoadStatus.Core.ApplicationAccess;
using Tfl.RoadStatus.Core.ConsoleHost;
using Tfl.RoadStatus.Core.RoadStatusQuery;

namespace Tfl.RoadStatus.Core.Tests.IntegrationTests
{
    [TestFixture]
    public class RoadStatusConsoleClientTests
    {
        private readonly RoadStatusConsoleClient _roadStatusConsoleClient = new RoadStatusConsoleClient();

        [Test]
        public void ProcessValidRoadId()
        {
            //Given valid road Id
            const string roadId = "a2";

            //When the console client is run
            var roadStatusQueryService = new RoadStatusQueryService(new RoadStatusUriBuilder(new ApplicationAccessDetailsRepository().LoadAccessDetails()));
            var roadStatusQueryResponse = roadStatusQueryService.ProcessRoadStatusRequest(new RoadStatusQueryRequest { RoadId = roadId });
            var roadStatusConsoleResponse = _roadStatusConsoleClient.ProcessRequest(new RoadStatusConsoleRequest { RoadId = roadId });

            //Then the road 'displayName' should be displayed
            Assert.That(roadStatusConsoleResponse.StatusMessage.Contains(string.Format("The status of the {0} is as follows", roadStatusQueryResponse.RoadStatusDetails.DisplayName)), Is.True);

            //Then the road 'statusSeverity' should be displayed as 'Road Status'
            Assert.That(roadStatusConsoleResponse.StatusMessage.Contains(string.Format("Road Status is {0}", roadStatusQueryResponse.RoadStatusDetails.StatusSeverity)), Is.True);

            //Then the road 'statusSeverityDescription' should be displayed as 'Road Status Description'
            Assert.That(roadStatusConsoleResponse.StatusMessage.Contains(string.Format("Road Status Description is {0}", roadStatusQueryResponse.RoadStatusDetails.StatusSeverityDescription)), Is.True);

            //Then the console app exit code is 0
            Assert.That(roadStatusConsoleResponse.ExitCode, Is.EqualTo(0));
        }

        [Test]
        public void ProcessInvalidRoadId()
        {
            //Given an invalid road Id
            const string roadId = "A233";

            //When the console client is run
            var roadStatusConsoleResponse = _roadStatusConsoleClient.ProcessRequest(new RoadStatusConsoleRequest { RoadId = roadId });

            //Then the application should return an informative error
            Assert.That(roadStatusConsoleResponse.StatusMessage, Is.EqualTo(string.Format("{0} is not a valid road", roadId)));

            //Then the application should exit with a non zero System Error Code
            Assert.That(roadStatusConsoleResponse.ExitCode, Is.EqualTo(roadStatusConsoleResponse.ExitCode));
        }
    }
}