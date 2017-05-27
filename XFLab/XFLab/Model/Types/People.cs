using Newtonsoft.Json;

namespace XFLab.Model.Types
{
    public abstract class People
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "prof")]
        public string Profession { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }
    }
}
