﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DockerInspectConverter.Data.Spec
{
    class EndpointSpec
    {
        public string Mode { get; set; }
        public List<Port> Ports { get; set; }
    }
}
