using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ML.ConfigSettings.Model.Settings
{
    public class SimpleParameter : ConfigurationElement
    {

        [ConfigurationProperty("value", IsRequired = true)]
        public double Value
        {
            get { return ((double)(this["value"])); }
            set { this["value"] = value; }
        }


    }
}
