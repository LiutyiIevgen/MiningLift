using System;
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
    class SpeedPanelVm
    {
        public SpeedPanelVm(int panelWidth, int panelHeight, Parameters parameter)
        {
            _parameters = parameter;
            this.panelWidth = panelWidth;
            this.panelHeight = panelHeight;
            SetLength();
            SetPointsValue();

            pen = new Pen(Color.Black, 2);
            green_pen = new Pen(Color.FromArgb(255, 0, 255, 0), 1);
            drawFont_two = new Font("Arial", 16);
            black = new SolidBrush(Color.Black);
            green = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
            p_green = new SolidBrush(Color.FromArgb(125, 0, 255, 0));

            RuleDatas = new List<RuleData>();
            RuleInscriptions = new List<RuleInscription>();
            RulePointerLine = new List<RuleData>();
            RulePointer = new List<Pointer>();
            RuleFillPointer = new List<FillPointer>();
            SpeedMeaningZone = new List<CageAndRuleZone>();
        }

        private void SetLength()
        {
            long_desh_width = panelHeight / 3;
            middle_desh_width = panelHeight / 5;
            small_desh_width = panelHeight / 8;
            rule_hight = panelWidth - 20;
            pixel_pro_meter = rule_hight / IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value;
        }

        private void SetPointsValue()
        {
            x1_long = Convert.ToInt32(panelHeight / 2 - long_desh_width / 2);
            x2_long = Convert.ToInt32(panelHeight / 2 + long_desh_width / 2);
            x1_middle = Convert.ToInt32(panelHeight / 2 - middle_desh_width / 2);
            x2_middle = Convert.ToInt32(panelHeight / 2 + middle_desh_width / 2);
            x1_small = Convert.ToInt32(panelHeight / 2 - small_desh_width / 2);
            x2_small = Convert.ToInt32(panelHeight / 2 + small_desh_width / 2);
        }

        public List<RuleData> GetSpeedRuleDatas()
        {
            RuleDatas.Add(new RuleData
            {
                Pen = pen,
                FirstPoint = new Point(0, panelHeight / 2),
                SecondPoint = new Point(panelWidth, panelHeight / 2)
            });
            for (int i = 0; i <= IoC.Resolve<MineConfig>().MainViewConfig.MaxSpeed.Value * 10; i++)
            {
                if (i % 10 == 0)
                {
                    RuleDatas.Add(new RuleData
                    {
                        Pen = pen,
                        FirstPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * i / 10)), x1_long),
                        SecondPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * i / 10)), x2_long)
                    });
                    if (i / 10 >= 10)
                        RuleInscriptions.Add(new RuleInscription
                                {
                                    Text = Convert.ToString(i / 10),
                                    Font = drawFont_two,
                                    Brush = black,
                                    Position = new Point(Convert.ToInt32(pixel_pro_meter * i / 10) - 10, x2_long)
                                });
                    else
                        RuleInscriptions.Add(new RuleInscription
                        {
                            Text = Convert.ToString(i / 10),
                            Font = drawFont_two,
                            Brush = black,
                            Position = new Point(Convert.ToInt32(pixel_pro_meter * i / 10), x2_long)
                        });
                }
                else if (i % 5 == 0)
                {
                    RuleDatas.Add(new RuleData
                    {
                        Pen = pen,
                        FirstPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * i / 10)), x1_middle),
                        SecondPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * i / 10)), x2_middle)
                    });
                }
                else if (i % 1 == 0)
                {
                    RuleDatas.Add(new RuleData
                    {
                        Pen = pen,
                        FirstPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * i / 10)), x1_small),
                        SecondPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * i / 10)), x2_small)
                    });
                }
            }
            return RuleDatas;
        }

        public List<RuleInscription> GetSpeedRuleInscription()
        {
            return RuleInscriptions;
        }

        public List<RuleData> GetSpeedRulePointerLine()
        {
                RulePointerLine.Add(new RuleData
                {
                    Pen = green_pen,
                    FirstPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), x2_long),
                    SecondPoint = new Point((10 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), 3)
                });
                RulePointer.Add(new Pointer
                {
                    Pen = green_pen,
                    Triangle = new Point[3]
                            {
                                new Point((10 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), x1_long - 2),
                                new Point((5 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), 3),
                                new Point((15 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), 3)
                            }
                });
                RuleFillPointer.Add(new FillPointer
                {
                    Brush = green,
                    Triangle = new Point[3]
                            {
                                new Point((10 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), x1_long - 2),
                                new Point((5 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), 3),
                                new Point((15 + Convert.ToInt32(pixel_pro_meter * _parameters.v)), 3)
                            }
                });
            return RulePointerLine;
        }

        public List<Pointer> GetSpeedRulePointer()
        {
            return RulePointer;
        }

        public List<FillPointer> GetSpeedRuleFillPointer()
        {
            return RuleFillPointer;
        }

        public List<CageAndRuleZone> GetSpeedRuleSpeedMeaningZone()
        {
                SpeedMeaningZone.Add(new CageAndRuleZone
                {
                    Brush = p_green,
                    LeftTopX = 10,
                    LeftTopY = x1_middle,
                    Width = Convert.ToInt32(pixel_pro_meter * _parameters.v),
                    Height = Convert.ToInt32(middle_desh_width)
                });
                return SpeedMeaningZone;
        }

        public void DisposeDrawingAttributes()
        {
            pen.Dispose();
            green_pen.Dispose();
            drawFont_two.Dispose();
            black.Dispose();
            green.Dispose();
            p_green.Dispose();
        }

        public List<RuleData> RuleDatas { get; private set; }
        public List<RuleInscription> RuleInscriptions { get; private set; }
        public List<RuleData> RulePointerLine { get; private set; }
        public List<Pointer> RulePointer { get; private set; }
        public List<FillPointer> RuleFillPointer { get; private set; }
        public List<CageAndRuleZone> SpeedMeaningZone { get; private set; }
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
        private Pen green_pen;
        private Font drawFont_two;
        private SolidBrush black;
        private SolidBrush green;
        SolidBrush p_green;

    }
}
