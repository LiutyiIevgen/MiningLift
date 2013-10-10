using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ML.ConfigSettings.Model.Settings
{
    public class AuziDSignalsConfigSection : ConfigurationSection
    {
        private string _addedSignals = null;
        private string _signalsNames = null;

        [ConfigurationProperty("addedSignals")]
        private string addedSignals
        {
            get
            {
                return _addedSignals = _addedSignals ?? this["addedSignals"].ToString();
            }
            set
            {
                this["addedSignals"] = value;
                _addedSignals = value;
            }
        }
        public string[] AddedSignals
        {
            get
            {
                return addedSignals.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                addedSignals = s;
            }
        }

        [ConfigurationProperty("signalsNames")]
        private string signalsNames
        {
            get
            {
                return _signalsNames = _signalsNames ?? this["signalsNames"].ToString();
            }
            set
            {
                this["signalsNames"] = value;
                _signalsNames = value;
            }
        }
        public string[] SignalsNames
        {
            get
            {
                return signalsNames.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                signalsNames = s;
            }
        }
    }
}
