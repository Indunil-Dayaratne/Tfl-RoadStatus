using System.Configuration;

namespace Tfl.RoadStatus.Core.ApplicationAccess
{
    public interface IApplicationAccessDetailsRepository
    {
        ApplicationAccessDetails LoadAccessDetails();
    }

    public class ApplicationAccessDetailsRepository : IApplicationAccessDetailsRepository
    {
        public ApplicationAccessDetails LoadAccessDetails()
        {
            var appId = ConfigurationManager.AppSettings["AppId"];
            var appKey = ConfigurationManager.AppSettings["AppKey"];
            var roadStatusBaseUri = ConfigurationManager.AppSettings["RoadStatusBaseUri"];

            var applicationAccessDetails = new ApplicationAccessDetails(appId, appKey, roadStatusBaseUri);
            return applicationAccessDetails;
        }
    }
}