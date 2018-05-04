using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class LogDriver
    {
        public string Name { get; set; }
        public LogDriverOptions Options { get; set; }
    }
}
