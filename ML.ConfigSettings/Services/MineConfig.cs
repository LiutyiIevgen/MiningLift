using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ML.ConfigSettings.Model.Settings;

namespace ML.ConfigSettings.Services
{
    public class MineConfig
    {
        private readonly Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public string CanName
        {
            get { return _config.AppSettings.Settings["CanName"].Value; }
            set
            {
               _config.AppSettings.Settings["CanName"].Value = value; 
                _config.Save(ConfigurationSaveMode.Modified);
            }
        }
        public int CanSpeed
        {
            get { return int.Parse(_config.AppSettings.Settings["CanSpeed"].Value); }
            set
            {
                _config.AppSettings.Settings["CanSpeed"].Value = value.ToString();
                _config.Save(ConfigurationSaveMode.Modified);
            }
        }
        public int LeadingController
        {
            get { return int.Parse(_config.AppSettings.Settings["LeadingController"].Value); }
            set
            {
                _config.AppSettings.Settings["LeadingController"].Value = value.ToString();
                _config.Save(ConfigurationSaveMode.Modified);
            }
        }
        private MainViewConfigSection _mainViewConfig;
        public MainViewConfigSection MainViewConfig
        {
            get { return _mainViewConfig ?? (_mainViewConfig = (MainViewConfigSection)_config.GetSection("MainView")); }
        }
        private AuziDSignalsConfigSection _auziDSignalsConfig;
        public AuziDSignalsConfigSection AuziDSignalsConfig
        {
            get { return _auziDSignalsConfig ?? (_auziDSignalsConfig = (AuziDSignalsConfigSection)_config.GetSection("AuziDSignals")); }
        }
        private ParametersConfigSection _parametersConfig;
        public ParametersConfigSection ParametersConfig
        {
            get { return _parametersConfig ?? (_parametersConfig = (ParametersConfigSection)_config.GetSection("Parameters")); }
        }
        ~MineConfig()
        {
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
