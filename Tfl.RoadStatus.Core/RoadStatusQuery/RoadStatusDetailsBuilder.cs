using System.Linq;
using Newtonsoft.Json.Linq;

namespace Tfl.RoadStatus.Core.RoadStatusQuery
{
    public class RoadStatusDetailsBuilder
    {
        public RoadStatusDetails Build(string payload)
        {
            var json = string.Empty;

            if (payload.StartsWith("[{") && payload.EndsWith("}]"))
            {
                json = payload.Substring(1, payload.Length - 2);
            }

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            var roadStatusDetails = new RoadStatusDetails();
            var results = JObject.Parse(json);
            var properties = results.Properties().ToList();

            var idProperty = properties.FirstOrDefault(x => x.Name == "id");
            var displayNameProperty = properties.FirstOrDefault(x => x.Name == "displayName");
            var statusSeverityProperty = properties.FirstOrDefault(x => x.Name == "statusSeverity");
            var statusSeverityDescriptionProperty = properties.FirstOrDefault(x => x.Name == "statusSeverityDescription");

            roadStatusDetails.Id = (idProperty != null)? idProperty.Value.ToString(): string.Empty;
            roadStatusDetails.DisplayName = (displayNameProperty != null) ? displayNameProperty.Value.ToString() : string.Empty;
            roadStatusDetails.StatusSeverity = (statusSeverityProperty != null) ? statusSeverityProperty.Value.ToString() : string.Empty;
            roadStatusDetails.StatusSeverityDescription = (statusSeverityDescriptionProperty != null) ? statusSeverityDescriptionProperty.Value.ToString() : string.Empty;

            return roadStatusDetails;
        }
    }
}