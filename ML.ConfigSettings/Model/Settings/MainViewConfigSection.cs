using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ML.ConfigSettings.Model.Settings
{
    public class MainViewConfigSection : ConfigurationSection
    {
        private SimpleParameter _maxSpeed = null;
        private SimpleParameter _maxDopRuleSpeed = null;
        private SimpleParameter _maxTokAnchor = null;
        private SimpleParameter _maxTokExcitation = null;
        private SimpleParameter _distance = null;
        private SimpleParameter _borderRed = null;
        private SimpleParameter _upZeroZone = null;
        private SimpleParameter _borderZero = null;
        private SimpleParameter _border = null;
        private SimpleParameter _leftSosud = null;
        private SimpleParameter _rightSosud = null;

        [ConfigurationProperty("maxSpeed")]
        public SimpleParameter MaxSpeed
        {
            get
            {
                return _maxSpeed = _maxSpeed ?? (SimpleParameter) this["maxSpeed"];
            }
            set
            {
                this["maxSpeed"] = value;
                _maxSpeed = value;
            }
        }

        [ConfigurationProperty("maxDopRuleSpeed")]
        public SimpleParameter MaxDopRuleSpeed
        {
            get
            {
                return _maxDopRuleSpeed = _maxDopRuleSpeed ?? (SimpleParameter)this["maxDopRuleSpeed"];
            }
            set
            {
                this["maxDopRuleSpeed"] = value;
                _maxDopRuleSpeed = value;
            }
        }

        [ConfigurationProperty("maxTokAnchor")]
        public SimpleParameter MaxTokAnchor
        {
            get
            {
                return _maxTokAnchor = _maxTokAnchor ?? (SimpleParameter)this["maxTokAnchor"];
            }
            set
            {
                this["maxTokAnchor"] = value;
                _maxTokAnchor = value;
            }
        }

        [ConfigurationProperty("maxTokExcitation")]
        public SimpleParameter MaxTokExcitation
        {
            get
            {
                return _maxTokExcitation = _maxTokExcitation ?? (SimpleParameter)this["maxTokExcitation"];
            }
            set
            {
                this["maxTokExcitation"] = value;
                _maxTokExcitation = value;
            }
        }

        [ConfigurationProperty("distance")]
        public SimpleParameter Distance
        {
            get
            {
                return _distance = _distance ?? (SimpleParameter)this["distance"];
            }
            set
            {
                this["distance"] = value;
                _distance = value;
            }
        }

        [ConfigurationProperty("borderRed")]
        public SimpleParameter BorderRed
        {
            get
            {
                return _borderRed = _borderRed ?? (SimpleParameter)this["borderRed"];
            }
            set
            {
                this["borderRed"] = value;
                _borderRed = value;
            }
        }

        [ConfigurationProperty("upZeroZone")]
        public SimpleParameter UpZeroZone
        {
            get
            {
                return _upZeroZone = _upZeroZone ?? (SimpleParameter)this["upZeroZone"];
            }
            set
            {
                this["upZeroZone"] = value;
                _upZeroZone = value;
            }
        }

        [ConfigurationProperty("borderZero")]
        public SimpleParameter BorderZero
        {
            get
            {
                return _borderZero = _borderZero ?? (SimpleParameter)this["borderZero"];
            }
            set
            {
                this["borderZero"] = value;
                _borderZero = value;
            }
        }

        [ConfigurationProperty("border")]
        public SimpleParameter Border
        {
            get
            {
                return _border = _border ?? (SimpleParameter)this["border"];
            }
            set
            {
                this["border"] = value;
                _border = value;
            }
        }

        [ConfigurationProperty("leftSosud")]
        private SimpleParameter leftSosud
        {
            get
            {
                return _leftSosud = _leftSosud ?? (SimpleParameter)this["leftSosud"];
            }
            set
            {
                this["leftSosud"] = value;
                _leftSosud = value;
            }
        }
        public SosudType LeftSosud {
            get { return (SosudType)leftSosud.Value; }
            set { leftSosud.Value = (double) value; }
        }
        [ConfigurationProperty("rightSosud")]
        private SimpleParameter rightSosud
        {
            get
            {
                return _rightSosud = _rightSosud ?? (SimpleParameter)this["rightSosud"];
            }
            set
            {
                this["rightSosud"] = value;
                _rightSosud = value;
            }
        }
        public SosudType RightSosud
        {
            get { return (SosudType)rightSosud.Value; }
            set { rightSosud.Value = (double)value; }
        }
    }
}
