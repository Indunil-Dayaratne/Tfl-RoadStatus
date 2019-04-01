using NUnit.Framework;
using Tfl.RoadStatus.Core.ApplicationAccess;
using Tfl.RoadStatus.Core.RoadStatusQuery;

namespace Tfl.RoadStatus.Core.Tests.IntegrationTests
{
    [TestFixture]
    public class RoadStatusQueryServiceTests
    {
        private readonly RoadStatusUriBuilder roadStatusUriBuilder;

        public RoadStatusQueryServiceTests()
        {
            roadStatusUriBuilder = new RoadStatusUriBuilder(new ApplicationAccessDetailsRepository().LoadAccessDetails());
        }

        [Test]
        public void ProcessValidRoadStatusRequest()
        {
            const string roadId = "a2";
            const string roadDisplayName = "A2";

            var roadStatusQueryService = new RoadStatusQueryService(roadStatusUriBuilder);
            var roadStatusQueryResponse = roadStatusQueryService.ProcessRoadStatusRequest(new RoadStatusQueryRequest {RoadId = roadId});

            Assert.That(roadStatusQueryResponse, Is.Not.Null);
            Assert.That(roadStatusQueryResponse.RoadIdIsValid, Is.True);
            Assert.That(roadStatusQueryResponse.RoadStatusDetails, Is.Not.Null);
            Assert.That(roadStatusQueryResponse.RoadStatusDetails.Id, Is.EqualTo(roadId));
            Assert.That(roadStatusQueryResponse.RoadStatusDetails.DisplayName, Is.EqualTo(roadDisplayName));
        }

        [Test]
        public void ProcessInvalidRoadStatusRequest()
        {
            var roadStatusQueryService = new RoadStatusQueryService(roadStatusUriBuilder);
            var roadStatusQueryResponse = roadStatusQueryService.ProcessRoadStatusRequest(new RoadStatusQueryRequest { RoadId = "A223" });

            Assert.That(roadStatusQueryResponse, Is.Not.Null);
            Assert.That(roadStatusQueryResponse.RoadIdIsValid, Is.False);
            Assert.That(roadStatusQueryResponse.RoadStatusDetails, Is.Null);
        }
    }
}