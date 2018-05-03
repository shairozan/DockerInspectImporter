using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class ContainerSpec
    {
        public string Image { get; set; }
        public List<string> Args { get; set; }
        public List<string> Env { get; set; }
        public ulong StopGracePeriod { get; set; }
        public string Isolation { get; set; }
    }
}
