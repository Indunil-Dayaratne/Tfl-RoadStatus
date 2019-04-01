using System.Text;
using Tfl.RoadStatus.Core.RoadStatusQuery;

namespace Tfl.RoadStatus.Core.ConsoleHost
{
    public class RoadStatusConsoleResponseBuilder
    {
        public RoadStatusConsoleResponse Build(RoadStatusQueryRequest queryRequest, RoadStatusQueryResponse queryResponse)
        {
            var roadStatusConsoleResponse = new RoadStatusConsoleResponse();

            if (queryResponse.RoadIdIsValid)
            {
                 var statusMessageBuilder = new StringBuilder();
                 statusMessageBuilder.AppendLine(string.Format("The status of the {0} is as follows", queryResponse.RoadStatusDetails.DisplayName));
                 statusMessageBuilder.AppendLine(string.Format("Road Status is {0}", queryResponse.RoadStatusDetails.StatusSeverity));
                 statusMessageBuilder.AppendLine(string.Format("Road Status Description is {0}", queryResponse.RoadStatusDetails.StatusSeverityDescription));

                 roadStatusConsoleResponse.StatusMessage = statusMessageBuilder.ToString();
                 roadStatusConsoleResponse.ExitCode = 0;
            }
            else
            {
                roadStatusConsoleResponse.StatusMessage = string.Format("{0} is not a valid road", queryRequest.RoadId);
                roadStatusConsoleResponse.ExitCode = -1;
            }

            return roadStatusConsoleResponse;
        }
    }
}