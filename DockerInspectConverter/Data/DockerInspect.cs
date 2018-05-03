using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data
{
    class DockerInspect
    {
        public string ID { get; set; }
        public Version Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Spec.Spec Spec { get; set; }
        public Spec.Spec PreviousSpec { get; set; }
        public Endpoint.Endpoint Endpoint { get; set; } 
    }
}
