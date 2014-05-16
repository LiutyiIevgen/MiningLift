using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.ConfigSettings.Model.Settings
{
    public class BrakeSystemConfigSection
    {
        public SimpleParameter GreenZoneRabCyl1 { get; set; }
        public SimpleParameter GreenZoneRabCyl2 { get; set; }
        public SimpleParameter GreenZonePredCyl1 { get; set; }
        public SimpleParameter GreenZonePredCyl2 { get; set; }
    }
}
