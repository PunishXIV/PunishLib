using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunishLib.Configuration
{
    public class SharedConfigStorage : IEzConfig
    {
        public Dictionary<SharedConfigKey, string> Strings = new();
        public Dictionary<SharedConfigKey, bool> Bools = new();
    }
}
