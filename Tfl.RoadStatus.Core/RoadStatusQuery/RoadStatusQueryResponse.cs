namespace Tfl.RoadStatus.Core.RoadStatusQuery
{
    public class RoadStatusQueryResponse
    {
        public bool RoadIdIsValid { get; set; }
        public RoadStatusDetails RoadStatusDetails { get; set; }
        public string ApiPayload { get; set; }
    }
}