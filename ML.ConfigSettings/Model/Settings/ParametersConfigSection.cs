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
        private string _coordinatePeople = null;
        private string _speedPeople = null;
        private string _coordinateVeight = null;
        private string _speedVeight = null;
        private string _coordinateEquipment = null;
        private string _speedEquipment = null;
        private string _coordinateRevision = null;
        private string _speedRevision = null;

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

        [ConfigurationProperty("coordinatePeople")]
        private string coordinatePeople
        {
            get
            {
                return _coordinatePeople = _coordinatePeople ?? this["coordinatePeople"].ToString();
            }
            set
            {
                this["coordinatePeople"] = value;
                _coordinatePeople = value;
            }
        }
        public string[] CoordinatePeople
        {
            get
            {
                return coordinatePeople.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinatePeople = s;
            }
        }

        [ConfigurationProperty("speedPeople")]
        private string speedPeople
        {
            get
            {
                return _speedPeople = _speedPeople ?? this["speedPeople"].ToString();
            }
            set
            {
                this["speedPeople"] = value;
                _speedPeople = value;
            }
        }
        public string[] SpeedPeople
        {
            get
            {
                return speedPeople.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedPeople = s;
            }
        }

        [ConfigurationProperty("coordinateVeight")]
        private string coordinateVeight
        {
            get
            {
                return _coordinateVeight = _coordinateVeight ?? this["coordinateVeight"].ToString();
            }
            set
            {
                this["coordinateVeight"] = value;
                _coordinateVeight = value;
            }
        }
        public string[] CoordinateVeight
        {
            get
            {
                return coordinateVeight.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateVeight = s;
            }
        }

        [ConfigurationProperty("speedVeight")]
        private string speedVeight
        {
            get
            {
                return _speedVeight = _speedVeight ?? this["speedVeight"].ToString();
            }
            set
            {
                this["speedVeight"] = value;
                _speedVeight = value;
            }
        }
        public string[] SpeedVeight
        {
            get
            {
                return speedVeight.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedVeight = s;
            }
        }

        [ConfigurationProperty("coordinateEquipment")]
        private string coordinateEquipment
        {
            get
            {
                return _coordinateEquipment = _coordinateEquipment ?? this["coordinateEquipment"].ToString();
            }
            set
            {
                this["coordinateEquipment"] = value;
                _coordinateEquipment = value;
            }
        }
        public string[] CoordinateEquipment
        {
            get
            {
                return coordinateEquipment.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateEquipment = s;
            }
        }

        [ConfigurationProperty("speedEquipment")]
        private string speedEquipment
        {
            get
            {
                return _speedEquipment = _speedEquipment ?? this["speedEquipment"].ToString();
            }
            set
            {
                this["speedEquipment"] = value;
                _speedEquipment = value;
            }
        }
        public string[] SpeedEquipment
        {
            get
            {
                return speedEquipment.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedEquipment = s;
            }
        }

        [ConfigurationProperty("coordinateRevision")]
        private string coordinateRevision
        {
            get
            {
                return _coordinateRevision = _coordinateRevision ?? this["coordinateRevision"].ToString();
            }
            set
            {
                this["coordinateRevision"] = value;
                _coordinateRevision = value;
            }
        }
        public string[] CoordinateRevision
        {
            get
            {
                return coordinateRevision.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateRevision = s;
            }
        }

        [ConfigurationProperty("speedRevision")]
        private string speedRevision
        {
            get
            {
                return _speedRevision = _speedRevision ?? this["speedRevision"].ToString();
            }
            set
            {
                this["speedRevision"] = value;
                _speedRevision = value;
            }
        }
        public string[] SpeedRevision
        {
            get
            {
                return speedRevision.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedRevision = s;
            }
        }
    }
}
