﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunishLib.Configuration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)
]
    public class IgnoreDefaultValueAttribute : Attribute
    {
    }  
}
