using DockerInspectConverter.Data.Spec;
using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Endpoint
{
    class Endpoint
    {
        public EndpointSpec Spec { get; set; }
        public List<VirtualIP> VirtualIPs { get; set; }
    }
}
