using System;
using Tfl.RoadStatus.Core.ApplicationAccess;
using Tfl.RoadStatus.Core.RoadStatusQuery;

namespace Tfl.RoadStatus.Core.ConsoleHost
{
    public class RoadStatusConsoleClient
    {
        public RoadStatusConsoleResponse ProcessRequest(RoadStatusConsoleRequest roadStatusConsoleRequest)
        {
            var roadStatusQueryService = new RoadStatusQueryService(new RoadStatusUriBuilder(new ApplicationAccessDetailsRepository().LoadAccessDetails()));
            var roadStatusQueryRequest = new RoadStatusQueryRequest {RoadId = roadStatusConsoleRequest.RoadId};
            var roadStatusQueryResponse = roadStatusQueryService.ProcessRoadStatusRequest(roadStatusQueryRequest);

            var roadStatusConsoleResponseBuilder = new RoadStatusConsoleResponseBuilder();
            return roadStatusConsoleResponseBuilder.Build(roadStatusQueryRequest, roadStatusQueryResponse);
        }

        public void Run(string roadId)
        {
            try
            {
                var response = ProcessRequest(new RoadStatusConsoleRequest {RoadId = roadId});

                Console.WriteLine(response.StatusMessage);
                Environment.Exit(response.ExitCode);
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was an error processing this request - {0} ({1})", exception.Message, exception.StackTrace);
            }
        }
    }
}