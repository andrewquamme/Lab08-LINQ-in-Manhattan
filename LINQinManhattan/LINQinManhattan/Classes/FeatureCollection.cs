﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LINQinManhattan.Classes
{
    public partial class FeatureCollection
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}
