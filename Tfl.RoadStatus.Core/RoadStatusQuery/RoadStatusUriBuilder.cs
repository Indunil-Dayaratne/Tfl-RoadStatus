using Tfl.RoadStatus.Core.ApplicationAccess;

namespace Tfl.RoadStatus.Core.RoadStatusQuery
{
    public interface IRoadStatusUriBuilder
    {
        string BuildQueryUri(string roadId);
    }

    public class RoadStatusUriBuilder : IRoadStatusUriBuilder
    {
        private readonly ApplicationAccessDetails _applicationAccessDetails;

        public RoadStatusUriBuilder(ApplicationAccessDetails applicationAccessDetails)
        {
            _applicationAccessDetails = applicationAccessDetails;
        }

        public string BuildQueryUri(string roadId)
        {
            var queryUri = string.Format("{0}{1}?app_id={2}&app_key={3}", 
                _applicationAccessDetails.RoadStatusBaseUri, roadId, _applicationAccessDetails.AppId, _applicationAccessDetails.AppKey);
            return queryUri;
        }
    }
}
