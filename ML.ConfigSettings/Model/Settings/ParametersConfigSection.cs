using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ML.ConfigSettings.Model.Settings
{
    public class ParametersConfigSection : ConfigurationSection
    {
        private string _parametersFileName = null;

        [ConfigurationProperty("parametersFileName")]
        public string ParametersFileName
        {
            get
            {
                return _parametersFileName = _parametersFileName ?? (string)this["parametersFileName"];
            }
            set
            {
                this["parametersFileName"] = value;
                _parametersFileName = value;
            }
        }

       /* private string _variableParametersName = null;
        private string _variableParametersValue = null;

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
        }*/

    }
}
