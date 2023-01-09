using Dalamud.Plugin;
using ECommons;
using PunishLib.Sponsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunishLib
{
    public class PunishLibMain
    {
        public static void Init(DalamudPluginInterface pluginInterface, IDalamudPlugin instance, params Module[] modules)
        {
            ECommonsMain.Init(pluginInterface, instance, modules);
        }

        public static void Dispose()
        {
            ECommonsMain.Dispose();
        }
    }
}
