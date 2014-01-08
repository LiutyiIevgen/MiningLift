using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using VisualizationSystem.Model;
using VisualizationSystem.Model.GraphicData;

namespace VisualizationSystem.ViewModel
{
    class DefenceDiagramSettingsVm
    {
        //public DefenceDiagramSettingsVm()
        //{
       //     //_parameters = parameter;
       //     variableParametersValueStr = IoC.Resolve<MineConfig>().ParametersConfig.VariableParametersValue;
       //     variableParametersValue = new double[variableParametersValueStr.Count()];
       //     for (int i = 0; i < variableParametersValueStr.Count(); i++)
       //     {
       //         variableParametersValue[i] = Convert.ToDouble(variableParametersValueStr[i], CultureInfo.GetCultureInfo("en-US"));
       //     }
       //     _points = 20;
       //     HzCrossHkDown = 0;
       //     HzCrossHkUp = 0;
       //     vVeight = new double[_points];
       //     vPeople = new double[_points];
       //     vEquipment = new double[_points];
       //     vRevision = new double[_points];
       //     hzVeightDown = new double[_points];
       //     hzPeopleDown = new double[_points];
       //     hzEquipmentDown = new double[_points];
       //     hzRevision = new double[_points];
       //     hzVeightUp = new double[_points];
       //     hzPeopleUp = new double[_points];
       //     hzEquipmentUp = new double[_points];
       //     hkVeightDown = new double[_points];
       //     hkPeopleDown = new double[_points];
       //     hkEquipmentDown = new double[_points];
       //     hkRevision = new double[_points];
       //     hkVeightUp = new double[_points];
       //     hkPeopleUp = new double[_points];
       //     hkEquipmentUp = new double[_points];
       //     DiagramVeight = new GraphicData[(2*_points + 2)];
       //     for (int i = 0; i < (2*_points + 2); i++)
       //         DiagramVeight[i] = new GraphicData();
       //     DiagramPeople = new GraphicData[(2*_points + 2)];
       //     for (int i = 0; i < (2*_points + 2); i++)
       //         DiagramPeople[i] = new GraphicData();
       //     DiagramEquipment = new GraphicData[(2*_points + 2)];
       //     for (int i = 0; i < (2*_points + 2); i++)
       //         DiagramEquipment[i] = new GraphicData();
       //     DiagramRevision = new GraphicData[_points];
       //     for (int i = 0; i < _points; i++)
       //         DiagramRevision[i] = new GraphicData();

       //     InitV();
       //     SolveHz();
       //     SolveHk();
       //     CheckHz();
       //     SolveDiagramData();
       // }

       // private void InitV()
       // {
       //     double shag;
       //     shag = (1.15 * variableParametersValue[0] - variableParametersValue[4]) / _points;
       //     vVeight[0] = variableParametersValue[4];
       //     for (int i = 1; i < _points; i++)
       //     {
       //         vVeight[i] = vVeight[i - 1] + shag;
       //     }
       //     if (vVeight[_points - 1] != 1.15 * variableParametersValue[0])
       //     {
       //         vVeight[_points - 1] = 1.15 * variableParametersValue[0];
       //     }
       //     shag = (1.15 * variableParametersValue[1] - variableParametersValue[5]) / _points;
       //     vPeople[0] = variableParametersValue[5];
       //     for (int i = 1; i < _points; i++)
       //     {
       //         vPeople[i] = vPeople[i - 1] + shag;
       //     }
       //     if (vPeople[_points - 1] != 1.15 * variableParametersValue[1])
       //     {
       //         vPeople[_points - 1] = 1.15 * variableParametersValue[1];
       //     }
       //     shag = (1.15 * variableParametersValue[2] - variableParametersValue[4]) / _points;
       //     vEquipment[0] = variableParametersValue[4];
       //     for (int i = 1; i < _points; i++)
       //     {
       //         vEquipment[i] = vEquipment[i - 1] + shag;
       //     }
       //     if (vEquipment[_points - 1] != 1.15 * variableParametersValue[2])
       //     {
       //         vEquipment[_points - 1] = 1.15 * variableParametersValue[2];
       //     }
       //     for (int i = 0; i < _points; i++)
       //     {
       //         vRevision[i] = variableParametersValue[3];
       //     }
       // }

       // private void SolveHz()
       // {
       //     //вниз
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hzVeightDown[i] = (vVeight[i]*vVeight[i] - variableParametersValue[4]*variableParametersValue[4])*(variableParametersValue[0]*variableParametersValue[0] - variableParametersValue[6]*variableParametersValue[6]);
       //         hzVeightDown[i] /= 2*variableParametersValue[13]*(1.15*variableParametersValue[0]*1.15*variableParametersValue[0] - variableParametersValue[4]*variableParametersValue[4]);
       //         hzVeightDown[i] += variableParametersValue[16];
       //     }
       //     //вниз
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hzPeopleDown[i] = (vPeople[i] * vPeople[i] - variableParametersValue[5] * variableParametersValue[5]) * (variableParametersValue[1] * variableParametersValue[1] - variableParametersValue[6] * variableParametersValue[6]);
       //         hzPeopleDown[i] /= 2 * variableParametersValue[14] * (1.15 * variableParametersValue[1] * 1.15 * variableParametersValue[1] - variableParametersValue[5] * variableParametersValue[5]);
       //         hzPeopleDown[i] += variableParametersValue[18];
       //     }
       //     //вниз
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hzEquipmentDown[i] = (vEquipment[i] * vEquipment[i] - variableParametersValue[4] * variableParametersValue[4]) * (variableParametersValue[2] * variableParametersValue[2] - variableParametersValue[6] * variableParametersValue[6]);
       //         hzEquipmentDown[i] /= 2 * variableParametersValue[13] * (1.15 * variableParametersValue[2] * 1.15 * variableParametersValue[2] - variableParametersValue[4] * variableParametersValue[4]);
       //         hzEquipmentDown[i] += variableParametersValue[16];
       //     }
       //     //
       //     double shag = (IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value)/_points;
       //     hzRevision[0] = IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value;
       //     for (int i = 1; i < _points; i++)
       //     {
       //         hzRevision[i] = hzRevision[i - 1] + shag;
       //     }
       //     if (hzRevision[_points - 1] != IoC.Resolve<MineConfig>().MainViewConfig.Border.Value)
       //     {
       //         hzRevision[_points - 1] = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value;
       //     }
       //     //вверх
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hzVeightUp[i] = (vVeight[i] * vVeight[i] - variableParametersValue[4] * variableParametersValue[4]) * (variableParametersValue[0] * variableParametersValue[0] - variableParametersValue[6] * variableParametersValue[6]);
       //         hzVeightUp[i] /= 2 * variableParametersValue[13] * (1.15 * variableParametersValue[0] * 1.15 * variableParametersValue[0] - variableParametersValue[4] * variableParametersValue[4]);
       //         hzVeightUp[i] += variableParametersValue[17];
       //     }
       //     //вверх
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hzPeopleUp[i] = (vPeople[i] * vPeople[i] - variableParametersValue[5] * variableParametersValue[5]) * (variableParametersValue[1] * variableParametersValue[1] - variableParametersValue[6] * variableParametersValue[6]);
       //         hzPeopleUp[i] /= 2 * variableParametersValue[14] * (1.15 * variableParametersValue[1] * 1.15 * variableParametersValue[1] - variableParametersValue[5] * variableParametersValue[5]);
       //         hzPeopleUp[i] += variableParametersValue[19];
       //     }
       //     //вверх
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hzEquipmentUp[i] = (vEquipment[i] * vEquipment[i] - variableParametersValue[4] * variableParametersValue[4]) * (variableParametersValue[2] * variableParametersValue[2] - variableParametersValue[6] * variableParametersValue[6]);
       //         hzEquipmentUp[i] /= 2 * variableParametersValue[13] * (1.15 * variableParametersValue[2] * 1.15 * variableParametersValue[2] - variableParametersValue[4] * variableParametersValue[4]);
       //         hzEquipmentUp[i] += variableParametersValue[17];
       //     }
       // }

       // private void SolveHk()
       // {
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hkVeightDown[i] = (vVeight[i] + variableParametersValue[15])*(vVeight[i] + variableParametersValue[15])/(2*variableParametersValue[11]);
       //         hkVeightDown[i] += vVeight[i]*(variableParametersValue[7] + variableParametersValue[8]);
       //         hkVeightDown[i] += variableParametersValue[15]*variableParametersValue[8]/2;
       //     }
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hkVeightUp[i] = hkVeightDown[i];
       //     }
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hkPeopleDown[i] = (vPeople[i] + variableParametersValue[15]) * (vPeople[i] + variableParametersValue[15]) / (2 * variableParametersValue[12]);
       //         hkPeopleDown[i] += vPeople[i] * (variableParametersValue[7] + variableParametersValue[8]);
       //         hkPeopleDown[i] += variableParametersValue[15] * variableParametersValue[8] / 2;
       //     }
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hkPeopleUp[i] = hkPeopleDown[i];
       //     }
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hkEquipmentDown[i] = (vEquipment[i] + variableParametersValue[15]) * (vEquipment[i] + variableParametersValue[15]) / (2 * variableParametersValue[11]);
       //         hkEquipmentDown[i] += vEquipment[i] * (variableParametersValue[7] + variableParametersValue[8]);
       //         hkEquipmentDown[i] += variableParametersValue[15] * variableParametersValue[8] / 2;
       //     }
       //     for (int i = 0; i < _points; i++)
       //     {
       //         hkEquipmentUp[i] = hkEquipmentDown[i];
       //     }
       // }

       // private void CheckHz()
       // {
       //     for (int i = 0; i < _points; i++)
       //     {
       //         if ((IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hzVeightDown[i] >= IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hkVeightDown[i]) || (IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hzPeopleDown[i] >= IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hkPeopleDown[i]) || (IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hzEquipmentDown[i] >= IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hkEquipmentDown[i]))
       //         {
       //             HzCrossHkDown = 1;
       //         }
       //         if ((hzVeightUp[i] <= hkVeightUp[i]) || (hzPeopleUp[i] <= hkPeopleUp[i]) || (hzEquipmentUp[i] <= hkEquipmentUp[i]))
       //         {
       //             HzCrossHkUp = 1;
       //         }
       //     }
       // }

       // private void SolveDiagramData()
       // {
       //     int j;
       //     DiagramVeight[0].X = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value;
       //     DiagramVeight[0].Y = variableParametersValue[4];
       //     for (int i = 1; i < (_points+1); i++)
       //     {
       //         DiagramVeight[i].X = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hzVeightDown[i - 1];
       //         DiagramVeight[i].Y = vVeight[i-1];
       //     }
       //     j = _points-1;
       //     for (int i = _points + 1; i < (2*_points + 1); i++)
       //     {
       //         DiagramVeight[i].X = hzVeightUp[j];
       //         DiagramVeight[i].Y = vVeight[j];
       //         j--;
       //     }
       //     DiagramVeight[2*_points + 1].X = IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value;
       //     DiagramVeight[2 * _points + 1].Y = variableParametersValue[4];
       //     //
       //     DiagramPeople[0].X = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value;
       //     DiagramPeople[0].Y = variableParametersValue[5];
       //     for (int i = 1; i < (_points + 1); i++)
       //     {
       //         DiagramPeople[i].X = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hzPeopleDown[i - 1];
       //         DiagramPeople[i].Y = vPeople[i - 1];
       //     }
       //     j = _points - 1;
       //     for (int i = _points + 1; i < (2 * _points + 1); i++)
       //     {
       //         DiagramPeople[i].X = hzPeopleUp[j];
       //         DiagramPeople[i].Y = vPeople[j];
       //         j--;
       //     }
       //     DiagramPeople[2 * _points + 1].X = IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value;
       //     DiagramPeople[2 * _points + 1].Y = variableParametersValue[5];
       //     //
       //     DiagramEquipment[0].X = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value;
       //     DiagramEquipment[0].Y = variableParametersValue[4];
       //     for (int i = 1; i < (_points + 1); i++)
       //     {
       //         DiagramEquipment[i].X = IoC.Resolve<MineConfig>().MainViewConfig.Border.Value - hzEquipmentDown[i - 1];
       //         DiagramEquipment[i].Y = vEquipment[i - 1];
       //     }
       //     j = _points - 1;
       //     for (int i = _points + 1; i < (2 * _points + 1); i++)
       //     {
       //         DiagramEquipment[i].X = hzEquipmentUp[j];
       //         DiagramEquipment[i].Y = vEquipment[j];
       //         j--;
       //     }
       //     DiagramEquipment[2 * _points + 1].X = IoC.Resolve<MineConfig>().MainViewConfig.BorderZero.Value;
       //     DiagramEquipment[2 * _points + 1].Y = variableParametersValue[4];
       //     //
       //     for (int i = 0; i < _points; i++)
       //     {
       //         DiagramRevision[i].X = hzRevision[i];
       //         DiagramRevision[i].Y = vRevision[i];
       //     }
       // }

       // public double[] vVeight { get; private set; }
       // public double[] vPeople { get; private set; }
       // public double[] vEquipment { get; private set; }
       // public double[] vRevision { get; private set; }
       // public double[] hzVeightDown { get; private set; }
       // public double[] hzPeopleDown { get; private set; }
       // public double[] hzEquipmentDown { get; private set; }
       // public double[] hzRevision { get; private set; }
       // public double[] hzVeightUp { get; private set; }
       // public double[] hzPeopleUp { get; private set; }
       // public double[] hzEquipmentUp { get; private set; }
       // public double[] hkVeightDown { get; private set; }
       // public double[] hkPeopleDown { get; private set; }
       // public double[] hkEquipmentDown { get; private set; }
       // public double[] hkRevision { get; private set; }
       // public double[] hkVeightUp { get; private set; }
       // public double[] hkPeopleUp { get; private set; }
       // public double[] hkEquipmentUp { get; private set; }
       // public GraphicData[] DiagramVeight { get; private set; }
       // public GraphicData[] DiagramPeople { get; private set; }
       // public GraphicData[] DiagramEquipment { get; private set; }
       // public GraphicData[] DiagramRevision { get; private set; }
       // private string[] variableParametersValueStr;
       // private double[] variableParametersValue;
       //// private Parameters _parameters;
       // private int _points;
       // public int HzCrossHkDown { get; private set; }
       // public int HzCrossHkUp { get; private set; }
    }
}
