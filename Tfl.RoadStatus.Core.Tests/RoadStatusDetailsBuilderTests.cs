using NUnit.Framework;
using Tfl.RoadStatus.Core.RoadStatusQuery;

namespace Tfl.RoadStatus.Core.Tests
{
    [TestFixture]
    public class RoadStatusDetailsBuilderTests
    {
        private readonly RoadStatusDetailsBuilder _roadStatusDetailsBuilder = new RoadStatusDetailsBuilder();

        [Test]
        public void BuildProcessesValidJsonPayloadSuccessfully()
        {
            const string validPayload = @"[{""$type"":""Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities"",""id"":""a2"",""displayName"":""A2"",""statusSeverity"":""Closure"",""statusSeverityDescription"":""Closure"",""bounds"":""[[-0.0857, 51.44091],[0.17118,51.49438]]"",""envelope"":""[[-0.0857,51.44091],[-0.0857,51.49438],[0.17118,51.49438],[0.17118,51.44091],[-0.0857,51.44091]]"",""url"":""/Road/a2""}]";
            const string expectedRoadId = "a2";
            const string expectedDisplayName = "A2";
            const string expectedStatusSeverity = "Closure";
            const string expectedStatusSeverityDescription = "Closure";

            var roadStatusDetails = _roadStatusDetailsBuilder.Build(validPayload);

            Assert.That(roadStatusDetails, Is.Not.Null);
            Assert.That(roadStatusDetails.Id, Is.EqualTo(expectedRoadId));
            Assert.That(roadStatusDetails.DisplayName, Is.EqualTo(expectedDisplayName));
            Assert.That(roadStatusDetails.StatusSeverity, Is.EqualTo(expectedStatusSeverity));
            Assert.That(roadStatusDetails.StatusSeverityDescription, Is.EqualTo(expectedStatusSeverityDescription));
        }

        [Test]
        public void BuildProcessesEmptyJsonPayload()
        {
            const string emptyPayload = "[{}]";

            var roadStatusDetails = _roadStatusDetailsBuilder.Build(emptyPayload);

            Assert.That(roadStatusDetails, Is.Not.Null);
            Assert.That(roadStatusDetails.Id, Is.EqualTo(string.Empty));
            Assert.That(roadStatusDetails.DisplayName, Is.EqualTo(string.Empty));
            Assert.That(roadStatusDetails.StatusSeverity, Is.EqualTo(string.Empty));
            Assert.That(roadStatusDetails.StatusSeverityDescription, Is.EqualTo(string.Empty));
        }

        [Test]
        public void BuildDoesNotProcessMalformedJsonPayload()
        {
            const string invalidPayload = "[{ZZ";

            var roadStatusDetails = _roadStatusDetailsBuilder.Build(invalidPayload);

            Assert.That(roadStatusDetails, Is.Null);
        }
    }
}