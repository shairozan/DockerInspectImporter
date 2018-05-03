using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class RestartPolicy
    {
        public string Condition { get; set; }
        public ulong Delay { get; set; }
        public int MaxAttempts { get; set; }
    }
}
