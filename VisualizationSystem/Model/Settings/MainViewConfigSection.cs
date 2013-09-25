using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace VisualizationSystem.Model.Settings
{
    class MainViewConfigSection : ConfigurationSection 
    {
        [ConfigurationProperty("maxSpeed")]
        public SimpleParameter MaxSpeed
        {
            get { return (SimpleParameter )this["maxSpeed"]; }
            set { this["maxSpeed"] = value; }
        }

        [ConfigurationProperty("maxDopRuleSpeed")]
        public SimpleParameter MaxDopRuleSpeed
        {
            get { return (SimpleParameter)this["maxDopRuleSpeed"]; }
            set { this["maxDopRuleSpeed"] = value; }
        }

        [ConfigurationProperty("maxTokAnchor")]
        public SimpleParameter MaxTokAnchor
        {
            get { return (SimpleParameter)this["maxTokAnchor"]; }
            set { this["maxTokAnchor"] = value; }
        }

        [ConfigurationProperty("maxTokExcitation")]
        public SimpleParameter MaxTokExcitation
        {
            get { return (SimpleParameter)this["maxTokExcitation"]; }
            set { this["maxTokExcitation"] = value; }
        }

        [ConfigurationProperty("distance")]
        public SimpleParameter Distance
        {
            get { return (SimpleParameter)this["distance"]; }
            set { this["distance"] = value; }
        }

        [ConfigurationProperty("borderRed")]
        public SimpleParameter BorderRed
        {
            get { return (SimpleParameter)this["borderRed"]; }
            set { this["borderRed"] = value; }
        }

        [ConfigurationProperty("upZeroZone")]
        public SimpleParameter UpZeroZone
        {
            get { return (SimpleParameter)this["upZeroZone"]; }
            set { this["upZeroZone"] = value; }
        }
    }
}
