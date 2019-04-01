using System.Configuration;
using NUnit.Framework;
using Tfl.RoadStatus.Core.ApplicationAccess;

namespace Tfl.RoadStatus.Core.Tests
{
    [TestFixture]
    public class ApplicationAccessDetailsRepositoryTests
    {
        [Test]
        public void ApplicationAccessDetailsIsLoadedFromAppConfig()
        {
            var applicationAccessDetailsRepository = new ApplicationAccessDetailsRepository();
            var applicationAccessDetails = applicationAccessDetailsRepository.LoadAccessDetails();

            var expectedRoadStatusBaseUri = ConfigurationManager.AppSettings["RoadStatusBaseUri"];
            var expectedAppId = ConfigurationManager.AppSettings["AppId"];
            var expectedAppKey = ConfigurationManager.AppSettings["AppKey"];

            Assert.That(applicationAccessDetails.RoadStatusBaseUri, Is.EqualTo(expectedRoadStatusBaseUri));
            Assert.That(applicationAccessDetails.AppId, Is.EqualTo(expectedAppId));
            Assert.That(applicationAccessDetails.AppKey, Is.EqualTo(expectedAppKey));
        }
    }
}