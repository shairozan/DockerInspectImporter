using Newtonsoft.Json;

namespace DockerInspectConverter.Data.Spec
{
    class LogDriverOptions
    {
        [JsonProperty(PropertyName = "syslog-address")]
        public string syslogaddress {get; set;}
        public string tag { get; set; }
    }
}
