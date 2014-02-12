﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataExchange.Model;
using Ninject.Parameters;

namespace VisualizationSystem.ViewModel.MainViewModel
{
    class AuziDControllerParametersVm
    {
        public AuziDControllerParametersVm()
        {

        }

        public List<string[]> GetDataList(List<Parameters> parametersList)
        {
            var pdataList = new List<string[]>();
            const int parametersCount = 3;
            for(int i=0;i<parametersCount;i++)
                pdataList.Add(new string[2]);
            int j = 0;
            foreach (var parameters in parametersList)
            {
                pdataList[0][j] = (-parameters.s).ToString();
                pdataList[1][j] = parameters.v.ToString();
                pdataList[2][j] = parameters.a.ToString();
                j++;
            }
            return pdataList;
        }
    }
}
