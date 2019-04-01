using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tfl.RoadStatus.Core.ApplicationAccess;
using Tfl.RoadStatus.Core.RoadStatusQuery;

namespace Tfl.RoadStatus.Core.Tests
{
    [TestFixture]
    public class RoadStatusUriBuilderTests
    {
        private readonly ApplicationAccessDetails _testApplicationAccessDetails;

        public RoadStatusUriBuilderTests()
        {
            _testApplicationAccessDetails = new TestApplicationAccessDetailsStore().GetAccessDetails();
        }

        [Test]
        public void EnsureQueryUriIsBuiltCorrectly()
        {
            const string expectedUri =
                "https://api.tfl.gov.uk/Road/A2?app_id=c3aaffd1&app_key=972a6acfeb3599644fc366e79010189e";

            var roadStatusUriBuilder = new RoadStatusUriBuilder(_testApplicationAccessDetails);
            var queryUri = roadStatusUriBuilder.BuildQueryUri("A2");

            Assert.That(queryUri, Is.EqualTo(expectedUri));
        }
    }
}
