using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class Port
    {
        public string Protocol { get; set; }
        public int TargetPort { get; set; }
        public int PublishedPort { get; set; }
        public string PublishedMode { get; set; }
    }
}
