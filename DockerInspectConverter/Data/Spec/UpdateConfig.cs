using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class UpdateConfig
    {
        public int Parallelism { get; set; }
        public string gFailureAction { get; set; }
        public ulong Monitor { get; set; }
        public int MaxFailureRatio { get; set; }
        public string Order { get; set; }
    }
}
