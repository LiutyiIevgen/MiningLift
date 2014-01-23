using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using ML.ConfigSettings.Services;
using ML.DataExchange.Model;
using VisualizationSystem.Model;

namespace VisualizationSystem.ViewModel.MainViewModel
{
    class DataBoxVm
    {
        public DataBoxVm()
        {
            DataBoxes = new List<string>();
            _mineConfig = IoC.Resolve<MineConfig>();
        }

        public void SolveDataBoxes(Parameters parameters)
        {
            DataBoxes.Clear();
            if (parameters.v > _mineConfig.MainViewConfig.MaxDopRuleSpeed.Value)
            {
                DataBoxes.Add(Convert.ToString(Math.Round(-parameters.s, 0), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(-(parameters.s_two), 0), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(parameters.v, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(parameters.tok_anchor, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(parameters.tok_excitation, 2), CultureInfo.GetCultureInfo("en-US")));
            }
            else
            {
                DataBoxes.Add(Convert.ToString(Math.Round(-parameters.s, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(-(parameters.s_two), 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(parameters.v, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(parameters.tok_anchor, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(parameters.tok_excitation, 2), CultureInfo.GetCultureInfo("en-US")));
            }
            CanStateValue = _mineConfig.CanName;
            CanStateColor = Color.LimeGreen;
        }

        public List<string> GetDataBoxes()
        {
            return DataBoxes;
        }

        public List<string> DataBoxes { get; private set; }
        public string CanStateValue { get; private set; }
        public Color CanStateColor { get; private set; }
        private MineConfig _mineConfig;
    }
}
