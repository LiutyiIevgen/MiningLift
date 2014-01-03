﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ML.ConfigSettings.Services;
using ML.DataExchange;
using ML.DataExchange.Model;
using VisualizationSystem.Model;
using VisualizationSystem.Model.PanelData;
using VisualizationSystem.Services;

namespace VisualizationSystem.ViewModel
{
    class LeftDopPanelVm
    {
        public LeftDopPanelVm(int panelWidth, int panelHeight, Parameters parameter)
        {
            _parameters = parameter;
            this.panelWidth = panelWidth;
            this.panelHeight = panelHeight;
            SetLength();
            SetPointsValue();

            pen = new Pen(Color.Black, 2);
            red_pen = new Pen(Color.Red, 1);
            drawFont_two = new Font("Arial", 16);
            black = new SolidBrush(Color.Black);
            red = new SolidBrush(Color.Red);

            RuleDatas = new List<RuleData>();
            RuleInscriptions = new List<RuleInscription>();
            RulePointerLine = new List<RuleData>();
            RulePointer = new List<Pointer>();
            RuleFillPointer = new List<FillPointer>();
            PanelBorderLine = new List<BorderLine>();
        }

        private void SetLength()
        {
            if (_parameters.v <= IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value)
            {
                long_desh_width = panelWidth/3/2;
                middle_desh_width = panelWidth/3/4;
                small_desh_width = panelWidth/3/6;
                rule_hight = panelHeight - 20;
                pixel_pro_ten_santimeter = rule_hight/10;
            }
        }
        private void SetPointsValue()
        {
            if (_parameters.v <= IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value)
            {
                x1_long = Convert.ToInt32(panelWidth/2 - long_desh_width/2);
                x2_long = Convert.ToInt32(panelWidth/2 + long_desh_width/2);
                x1_middle = Convert.ToInt32(panelWidth/2 - middle_desh_width/2);
                x2_middle = Convert.ToInt32(panelWidth/2 + middle_desh_width/2);
                x1_small = Convert.ToInt32(panelWidth/2 - small_desh_width/2);
                x2_small = Convert.ToInt32(panelWidth/2 + small_desh_width/2);
            }
        }

        public List<RuleData> GetDopRuleDatas()
        {
            if (_parameters.v <= IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value)
            {
                RuleDatas.Add(new RuleData
                    {
                        Pen = pen,
                        FirstPoint = new Point(panelWidth/2, 0),
                        SecondPoint = new Point(panelWidth/2, panelHeight)
                    });
                for (int i = Convert.ToInt32(Math.Round(_parameters.s, 2)*100) - 500;
                     i <= Convert.ToInt32(Math.Round(_parameters.s, 2)*100) + 500;
                     i++)
                {
                    if (i%100 == 0)
                    {
                        RuleDatas.Add(new RuleData
                            {
                                Pen = pen,
                                FirstPoint =
                                    new Point(x1_long,
                                              (10 + Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                               Convert.ToInt32(pixel_pro_ten_santimeter*
                                                               (Math.Round(_parameters.s, 2) - 5)))),
                                SecondPoint =
                                    new Point(x2_long,
                                              (10 + Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                               Convert.ToInt32(pixel_pro_ten_santimeter*
                                                               (Math.Round(_parameters.s, 2) - 5))))
                            });
                        if ((i/100) >= 10 && (i/100) < 100)
                            RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString((i/100)*(-1)),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position =
                                        new Point(x1_long - 35,
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*
                                                                  (Math.Round(_parameters.s, 2) - 5)) - 2)
                                });
                        else if ((i/100) <= -10)
                            RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString((i/100)*(-1)),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position =
                                        new Point(x1_long - 25,
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*
                                                                  (Math.Round(_parameters.s, 2) - 5)) - 2)
                                });
                        else if ((i/100) <= 0 && (i/100) > -10)
                            RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString((i/100)*(-1)),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position =
                                        new Point(x1_long - 20,
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*
                                                                  (Math.Round(_parameters.s, 2) - 5)) - 2)
                                });
                        else if ((i/100) > 0 && (i/100) < 10)
                            RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString((i/100)*(-1)),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position =
                                        new Point(x1_long - 25,
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*
                                                                  (Math.Round(_parameters.s, 2) - 5)) - 2)
                                });
                        else if ((i/100) >= 100 && (i/100) < 1000)
                            RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString((i/100)*(-1)),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position =
                                        new Point(x1_long - 50,
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*
                                                                  (Math.Round(_parameters.s, 2) - 5)) - 2)
                                });
                        else if ((i/100) >= 1000)
                            RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString((i/100)*(-1)),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position =
                                        new Point(x1_long - 58,
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                                  Convert.ToInt32(pixel_pro_ten_santimeter*
                                                                  (Math.Round(_parameters.s, 2) - 5)) - 2)
                                });
                    }
                    else if (i%50 == 0)
                    {
                        RuleDatas.Add(new RuleData
                            {
                                Pen = pen,
                                FirstPoint =
                                    new Point(x1_middle,
                                              (10 + Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                               Convert.ToInt32(pixel_pro_ten_santimeter*
                                                               (Math.Round(_parameters.s, 2) - 5)))),
                                SecondPoint =
                                    new Point(x2_middle,
                                              (10 + Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                               Convert.ToInt32(pixel_pro_ten_santimeter*
                                                               (Math.Round(_parameters.s, 2) - 5))))
                            });
                    }
                    else if (i%10 == 0)
                    {
                        RuleDatas.Add(new RuleData
                            {
                                Pen = pen,
                                FirstPoint =
                                    new Point(x1_small,
                                              (10 + Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                               Convert.ToInt32(pixel_pro_ten_santimeter*
                                                               (Math.Round(_parameters.s, 2) - 5)))),
                                SecondPoint =
                                    new Point(x2_small,
                                              (10 + Convert.ToInt32(pixel_pro_ten_santimeter*i/100) -
                                               Convert.ToInt32(pixel_pro_ten_santimeter*
                                                               (Math.Round(_parameters.s, 2) - 5))))
                            });
                    }
                }
            }
            return RuleDatas;
        }

        public List<RuleInscription> GetDopRuleInscription()
        {
            return RuleInscriptions;
        }

        public List<RuleData> GetDopRulePointerLine()
        {
            if (_parameters.v <= IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value)
            {
                RulePointerLine.Add(new RuleData
                    {
                        Pen = red_pen,
                        FirstPoint = new Point(x1_long, panelHeight/2),
                        SecondPoint = new Point(panelWidth - 15, panelHeight/2)
                    });
                RulePointer.Add(new Pointer
                    {
                        Pen = red_pen,
                        Triangle = new Point[3]
                            {
                                new Point(panelWidth - 40, panelHeight/2),
                                new Point(panelWidth - 15, panelHeight/2 - 10),
                                new Point(panelWidth - 15, panelHeight/2 + 10)
                            }
                    });
                RuleFillPointer.Add(new FillPointer
                    {
                        Brush = red,
                        Triangle = new Point[3]
                            {
                                new Point(panelWidth - 40, panelHeight/2),
                                new Point(panelWidth - 15, panelHeight/2 - 10),
                                new Point(panelWidth - 15, panelHeight/2 + 10)
                            }
                    });
            }
            return RulePointerLine;
        }

        public List<Pointer> GetDopRulePointer()
        {
            return RulePointer;
        }

        public List<FillPointer> GetDopRuleFillPointer()
        {
            return RuleFillPointer;
        }

        public List<BorderLine> GetDopRulePanelBorderLine()
        {
            if (_parameters.v <= IoC.Resolve<MineConfig>().MainViewConfig.MaxDopRuleSpeed.Value)
            {
                PanelBorderLine.Add(new BorderLine
                    {
                        Pen = pen,
                        LeftTopX = 0,
                        LeftTopY = 0,
                        Width = panelWidth - 1,
                        Height = panelHeight - 1
                    });
            }
            return PanelBorderLine;
        }

        public void DisposeDrawingAttributes()
        {
            pen.Dispose();
            red_pen.Dispose();
            drawFont_two.Dispose();
            black.Dispose();
            red.Dispose();
        }

        public List<RuleData> RuleDatas { get; private set; }
        public List<RuleInscription> RuleInscriptions { get; private set; }
        public List<RuleData> RulePointerLine { get; private set; }
        public List<Pointer> RulePointer { get; private set; }
        public List<FillPointer> RuleFillPointer { get; private set; }
        public List<BorderLine> PanelBorderLine { get; private set; }
        private Parameters _parameters;
        private int panelWidth;
        private int panelHeight;
        private double long_desh_width;
        private double middle_desh_width;
        private double small_desh_width;
        private double rule_hight;
        private double pixel_pro_meter;
        private double pixel_pro_ten_santimeter;
        private int x1_long;
        private int x2_long;
        private int x1_middle;
        private int x2_middle;
        private int x1_small;
        private int x2_small;
        private Pen pen;
        private Pen red_pen;
        private Font drawFont_two;
        private SolidBrush black;
        private SolidBrush red;
    }
}
