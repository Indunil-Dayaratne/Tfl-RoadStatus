namespace Tfl.RoadStatus.Core.ApplicationAccess
{
    public class ApplicationAccessDetails
    {
        public ApplicationAccessDetails(string appId, string appKey, string roadStatusBaseUri)
        {
            AppId = appId;
            AppKey = appKey;
            RoadStatusBaseUri = roadStatusBaseUri;
        }

        public string AppId { get; private set; }
        public string AppKey { get; private set; }
        public string RoadStatusBaseUri { get; private set; }
    }
}