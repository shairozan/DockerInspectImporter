using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class Spec
    {
        public string Name { get; set; }
        public Labels Labels { get; set; }
        public TaskTemplate TaskTemplate { get; set; }
        public Mode Mode { get; set; }
        public UpdateConfig UpdateConfig {get; set;}
        public UpdateConfig RollbackConfig { get; set; }
        public EndpointSpec EndpointSpec { get; set; }
    }
}
