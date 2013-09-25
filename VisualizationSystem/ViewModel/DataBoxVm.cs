using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ML.DataExchange;
using VisualizationSystem.Model;
using VisualizationSystem.Services;

namespace VisualizationSystem.ViewModel
{
    class DataBoxVm
    {
        public DataBoxVm(Parameters parameter)
        {
            _parameters = parameter;
            DataBoxes = new List<String>();

            SolveDataBoxes();
        }

        private void SolveDataBoxes()
        {
            if (_parameters.v > ConfigParameters.MaxVofDopRule)
            {
                DataBoxes.Add(Convert.ToString(Math.Round(-_parameters.s, 0), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(-(ConfigParameters.Distance - _parameters.s), 0), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.v, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_anchor, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_excitation, 2), CultureInfo.GetCultureInfo("en-US")));
            }
            else
            {
                DataBoxes.Add(Convert.ToString(Math.Round(-_parameters.s, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(-(ConfigParameters.Distance - _parameters.s), 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.v, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_anchor, 2), CultureInfo.GetCultureInfo("en-US")));
                DataBoxes.Add(Convert.ToString(Math.Round(_parameters.tok_excitation, 2), CultureInfo.GetCultureInfo("en-US")));
            }
        }

        public List<String> GetDataBoxes()
        {
            return DataBoxes;
        }

        public List<String> DataBoxes { get; private set; }
        private Parameters _parameters;
    }
}
