using Tfl.RoadStatus.Core.ApplicationAccess;

namespace Tfl.RoadStatus.Core.Tests
{
    public class TestApplicationAccessDetailsStore
    {
        public ApplicationAccessDetails GetAccessDetails()
        {
            var applicationAccessDetails = new ApplicationAccessDetails("c3aaffd1", 
                "972a6acfeb3599644fc366e79010189e","https://api.tfl.gov.uk/Road/");
            return applicationAccessDetails;
        }
    }
}