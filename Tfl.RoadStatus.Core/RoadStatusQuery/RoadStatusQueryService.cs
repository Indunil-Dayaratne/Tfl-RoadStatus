using System.Net;
using System.Net.Http;
using Tfl.RoadStatus.Core.ApplicationAccess;

namespace Tfl.RoadStatus.Core.RoadStatusQuery
{
    public class RoadStatusQueryService
    {
        private readonly IRoadStatusUriBuilder _roadStatusUriBuilder;

        public RoadStatusQueryService(IRoadStatusUriBuilder roadStatusUriBuilder)
        {
            _roadStatusUriBuilder = roadStatusUriBuilder;
        }

        public RoadStatusQueryResponse ProcessRoadStatusRequest(RoadStatusQueryRequest request)
        {
            var roadStatusQueryResponse = new RoadStatusQueryResponse();

            using (var httpClient = new HttpClientFactory().BuildClient())
            {
                var response = httpClient.GetAsync(_roadStatusUriBuilder.BuildQueryUri(request.RoadId));
                var payload = response.Result.Content.ReadAsStringAsync().Result;
                roadStatusQueryResponse.ApiPayload = payload;

                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    roadStatusQueryResponse.RoadIdIsValid = true;
                    roadStatusQueryResponse.RoadStatusDetails = new RoadStatusDetailsBuilder().Build(payload);
                }
            }

            return roadStatusQueryResponse;
        }
    }
}