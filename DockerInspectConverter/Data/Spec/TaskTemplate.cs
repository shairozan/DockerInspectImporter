using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class TaskTemplate
    {
        public ContainerSpec ContainerSpec { get; set; }
        public RestartPolicy RestartPolicy { get; set; }
        public List<Network> Networks { get; set; }
        
    }
}
