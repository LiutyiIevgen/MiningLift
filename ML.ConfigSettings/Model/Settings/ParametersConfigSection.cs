using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ML.ConfigSettings.Model.Settings
{
    public class ParametersConfigSection : ConfigurationSection
    {
        private string _variableParametersName = null;
        private string _variableParametersValue = null;
        private string _variableParametersType = null;
        private string _readonlyParametersName = null;
        private string _readonlyParametersValue = null;

        [ConfigurationProperty("variableParametersName")]
        private string variableParametersName
        {
            get
            {
                return _variableParametersName = _variableParametersName ?? this["variableParametersName"].ToString();
            }
            set
            {
                this["variableParametersName"] = value;
                _variableParametersName = value;
            }
        }
        public string[] VariableParametersName
        {
            get
            {
                return variableParametersName.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                variableParametersName = s;
            }
        }

        [ConfigurationProperty("variableParametersValue")]
        private string variableParametersValue
        {
            get
            {
                return _variableParametersValue = _variableParametersValue ?? this["variableParametersValue"].ToString();
            }
            set
            {
                this["variableParametersValue"] = value;
                _variableParametersValue = value;
            }
        }
        public string[] VariableParametersValue
        {
            get
            {
                return variableParametersValue.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                variableParametersValue = s;
            }
        }

        [ConfigurationProperty("variableParametersType")]
        private string variableParametersType
        {
            get
            {
                return _variableParametersType = _variableParametersType ?? this["variableParametersType"].ToString();
            }
            set
            {
                this["variableParametersType"] = value;
                _variableParametersType = value;
            }
        }
        public string[] VariableParametersType
        {
            get
            {
                return variableParametersType.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                variableParametersType = s;
            }
        }

        [ConfigurationProperty("readonlyParametersName")]
        private string readonlyParametersName
        {
            get
            {
                return _readonlyParametersName = _readonlyParametersName ?? this["readonlyParametersName"].ToString();
            }
            set
            {
                this["readonlyParametersName"] = value;
                _readonlyParametersName = value;
            }
        }
        public string[] ReadonlyParametersName
        {
            get
            {
                return readonlyParametersName.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                readonlyParametersName = s;
            }
        }

        [ConfigurationProperty("readonlyParametersValue")]
        private string readonlyParametersValue
        {
            get
            {
                return _readonlyParametersValue = _readonlyParametersValue ?? this["readonlyParametersValue"].ToString();
            }
            set
            {
                this["readonlyParametersValue"] = value;
                _readonlyParametersValue = value;
            }
        }
        public string[] ReadonlyParametersValue
        {
            get
            {
                return readonlyParametersValue.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                readonlyParametersValue = s;
            }
        }
    }
}
