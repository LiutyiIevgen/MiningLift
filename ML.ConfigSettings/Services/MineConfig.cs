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
        ~MineConfig()
        {
            _config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
