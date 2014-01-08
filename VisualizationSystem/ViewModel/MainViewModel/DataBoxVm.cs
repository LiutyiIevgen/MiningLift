using System;
using System.Collections.Generic;
using System.Globalization;
using ML.ConfigSettings.Services;
using ML.DataExchange.Model;
using VisualizationSystem.Model;

namespace VisualizationSystem.ViewModel.MainViewModel
{
    class DataBoxVm
    {
        public DataBoxVm(Parameters parameter)
        {
            _parameters = parameter;
            DataBoxes = new List<string>();

            SolveDataBoxes();
        }

        private void SolveDataBoxes()
        {
            if (_parameters.v > IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value)
            {
                DataBoxes.Add(Convert.ToString(Math.Round(-_parameters.s, 0), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(-(_parameters.s_two), 0), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.v, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_anchor, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_excitation, 2), CultureInfo.GetCultureInfo("en-US")));
            }
            else
            {
                DataBoxes.Add(Convert.ToString(Math.Round(-_parameters.s, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(-(_parameters.s_two), 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.v, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_anchor, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_excitation, 2), CultureInfo.GetCultureInfo("en-US")));
            }
        }

        public List<string> GetDataBoxes()
        {
            return DataBoxes;
        }

        public List<string> DataBoxes { get; private set; }
        private Parameters _parameters;
    }
}
