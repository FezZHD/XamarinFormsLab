using Newtonsoft.Json;

namespace XFLab.Model.Types
{
    public class JsonPeopleType:People
    {
        [JsonProperty(PropertyName = "image")]
        public string ImageLink { get; set; }
    }
}
