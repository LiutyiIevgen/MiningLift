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
        private string _variableParametersType = null;
        private string _coordinatePeople = null;
        private string _speedPeople = null;
        private string _coordinateVeight = null;
        private string _speedVeight = null;
        private string _coordinateEquipment = null;
        private string _speedEquipment = null;
        private string _coordinateRevision = null;
        private string _speedRevision = null;
        private string _speedRevisionV = null;
        private string _speedRevisionN = null;
        private string _speedVeightV = null;
        private string _speedVeightN = null;
        private string _speedPeopleV= null;
        private string _speedPeopleN = null;
        private string _speedEquipmentV = null;
        private string _speedEquipmentN = null;
        private string _coordinateRevisionV = null;
        private string _coordinateRevisionN = null;
        private string _coordinateVeightV = null;
        private string _coordinateVeightN = null;
        private string _coordinatePeopleV = null;
        private string _coordinatePeopleN = null;
        private string _coordinateEquipmentV = null;
        private string _coordinateEquipmentN = null;

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

        [ConfigurationProperty("speedRevisionV")]
        private string speedRevisionV
        {
            get
            {
                return _speedRevisionV = _speedRevisionV ?? this["speedRevisionV"].ToString();
            }
            set
            {
                this["speedRevisionV"] = value;
                _speedRevisionV = value;
            }
        }
        public string[] SpeedRevisionV
        {
            get
            {
                return speedRevisionV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedRevisionV = s;
            }
        }

        [ConfigurationProperty("speedRevisionN")]
        private string speedRevisionN
        {
            get
            {
                return _speedRevisionN = _speedRevisionN ?? this["speedRevisionN"].ToString();
            }
            set
            {
                this["speedRevisionN"] = value;
                _speedRevisionN = value;
            }
        }
        public string[] SpeedRevisionN
        {
            get
            {
                return speedRevisionV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedRevisionN = s;
            }
        }

        [ConfigurationProperty("speedPeopleV")]
        private string speedPeopleV
        {
            get
            {
                return _speedPeopleV = _speedPeopleV ?? this["speedPeopleV"].ToString();
            }
            set
            {
                this["speedPeopleV"] = value;
                _speedPeopleV = value;
            }
        }
        public string[] SpeedPeopleV
        {
            get
            {
                return speedPeopleV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedPeopleV = s;
            }
        }

        [ConfigurationProperty("speedPeopleN")]
        private string speedPeopleN
        {
            get
            {
                return _speedPeopleN = _speedPeopleN ?? this["speedPeopleN"].ToString();
            }
            set
            {
                this["speedPeopleN"] = value;
                _speedPeopleN = value;
            }
        }
        public string[] SpeedPeopleN
        {
            get
            {
                return speedPeopleN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedPeopleN = s;
            }
        }

        [ConfigurationProperty("speedEquipmentV")]
        private string speedEquipmentV
        {
            get
            {
                return _speedEquipmentV = _speedEquipmentV ?? this["speedEquipmentV"].ToString();
            }
            set
            {
                this["speedEquipmentV"] = value;
                _speedEquipmentV = value;
            }
        }
        public string[] SpeedEquipmentV
        {
            get
            {
                return speedEquipmentN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedEquipmentV = s;
            }
        }

        [ConfigurationProperty("speedEquipmentN")]
        private string speedEquipmentN
        {
            get
            {
                return _speedEquipmentN = _speedEquipmentN ?? this["speedEquipmentN"].ToString();
            }
            set
            {
                this["speedEquipmentN"] = value;
                _speedEquipmentN = value;
            }
        }
        public string[] SpeedEquipmentN
        {
            get
            {
                return speedEquipmentN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedEquipmentN = s;
            }
        }

        [ConfigurationProperty("speedVeightV")]
        private string speedVeightV
        {
            get
            {
                return _speedVeightV = _speedVeightV ?? this["speedVeightV"].ToString();
            }
            set
            {
                this["speedVeightV"] = value;
                _speedVeightV = value;
            }
        }
        public string[] SpeedVeightV
        {
            get
            {
                return speedVeightN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedVeightV = s;
            }
        }

        [ConfigurationProperty("speedVeightN")]
        private string speedVeightN
        {
            get
            {
                return _speedVeightN = _speedVeightN ?? this["speedVeightN"].ToString();
            }
            set
            {
                this["speedVeightN"] = value;
                _speedVeightN = value;
            }
        }
        public string[] SpeedVeightN
        {
            get
            {
                return speedVeightN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                speedVeightN = s;
            }
        }

        [ConfigurationProperty("coordinateRevisionV")]
        private string coordinateRevisionV
        {
            get
            {
                return _coordinateRevisionV = _coordinateRevisionV ?? this["coordinateRevisionV"].ToString();
            }
            set
            {
                this["coordinateRevisionV"] = value;
                _coordinateRevisionV = value;
            }
        }
        public string[] CoordinateRevisionV
        {
            get
            {
                return coordinateRevisionV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateRevisionV = s;
            }
        }

        [ConfigurationProperty("coordinateRevisionN")]
        private string coordinateRevisionN
        {
            get
            {
                return _coordinateRevisionN = _coordinateRevisionN ?? this["coordinateRevisionN"].ToString();
            }
            set
            {
                this["coordinateRevisionN"] = value;
                _coordinateRevisionN = value;
            }
        }
        public string[] CoordinateRevisionN
        {
            get
            {
                return coordinateRevisionN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateRevisionN = s;
            }
        }

        [ConfigurationProperty("coordinatePeopleV")]
        private string coordinatePeopleV
        {
            get
            {
                return _coordinatePeopleV = _coordinatePeopleV ?? this["coordinatePeopleV"].ToString();
            }
            set
            {
                this["coordinatePeopleV"] = value;
                _coordinatePeopleV = value;
            }
        }
        public string[] CoordinatePeopleV
        {
            get
            {
                return coordinatePeopleV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinatePeopleV = s;
            }
        }

        [ConfigurationProperty("coordinatePeopleN")]
        private string coordinatePeopleN
        {
            get
            {
                return _coordinatePeopleN = _coordinatePeopleN ?? this["coordinatePeopleN"].ToString();
            }
            set
            {
                this["coordinatePeopleN"] = value;
                _coordinatePeopleN = value;
            }
        }
        public string[] CoordinatePeopleN
        {
            get
            {
                return coordinatePeopleN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinatePeopleN = s;
            }
        }

        [ConfigurationProperty("coordinateEquipmentV")]
        private string coordinateEquipmentV
        {
            get
            {
                return _coordinateEquipmentV = _coordinateEquipmentV ?? this["coordinateEquipmentV"].ToString();
            }
            set
            {
                this["coordinateEquipmentV"] = value;
                _coordinateEquipmentV = value;
            }
        }
        public string[] CoordinateEquipmentV
        {
            get
            {
                return coordinateEquipmentV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateEquipmentV = s;
            }
        }

        [ConfigurationProperty("coordinateEquipmentN")]
        private string coordinateEquipmentN
        {
            get
            {
                return _coordinateEquipmentN = _coordinateEquipmentN ?? this["coordinateEquipmentN"].ToString();
            }
            set
            {
                this["coordinateEquipmentN"] = value;
                _coordinateEquipmentN = value;
            }
        }
        public string[] CoordinateEquipmentN
        {
            get
            {
                return coordinateEquipmentN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateEquipmentV = s;
            }
        }

        [ConfigurationProperty("coordinateVeightV")]
        private string coordinateVeightV
        {
            get
            {
                return _coordinateVeightV = _coordinateVeightV ?? this["coordinateVeightV"].ToString();
            }
            set
            {
                this["coordinateVeightV"] = value;
                _coordinateVeightV = value;
            }
        }
        public string[] CoordinateVeightV
        {
            get
            {
                return coordinateVeightV.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateVeightV = s;
            }
        }

        [ConfigurationProperty("coordinateVeightN")]
        private string coordinateVeightN
        {
            get
            {
                return _coordinateVeightN = _coordinateVeightN ?? this["coordinateVeightN"].ToString();
            }
            set
            {
                this["coordinateVeightN"] = value;
                _coordinateVeightN = value;
            }
        }
        public string[] CoordinateVeightN
        {
            get
            {
                return coordinateVeightN.Split('/');
            }
            set
            {
                string s = "";
                value.ToList().ForEach(f => s += f + '/');
                s = s.Substring(0, s.Length - 1);
                coordinateVeightN = s;
            }
        }
        */
    }
}
