using BlazorGraphs.Enums;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using System.Drawing;

namespace DemoApp.Pages
{
    public partial class Home
    {
        private Histogram histogram;
        private Histogram histogram2;
        private Bargram bargram;
        private Bargram bargram2;
        private Linegram linegram;
        private Piegram piegram;
        private Polargram polargram;
        private Radargram radargram;
        private Gaugegram gaugegram;
        private Gaugegram gaugegram2;
        private List<String> events;

        protected override void OnInitialized()
        {
            events = new List<string>();
            histogram = new Histogram("Axis-X", "Axis-Y", KnownColor.RoyalBlue, KnownColor.MediumPurple);
            histogram2 = new Histogram("Axis-X", "Axis-Y", KnownColor.RoyalBlue);
            bargram = new Bargram("Axis-2", KnownColor.MediumPurple);
            bargram2 = new Bargram("Axis-2", KnownColor.MediumOrchid, KnownColor.MediumSlateBlue);
            linegram = new Linegram("X1", "Y1");
            piegram = new Piegram();
            polargram = new Polargram("R1");
            radargram = new Radargram("R2", KnownColor.MediumVioletRed);
            gaugegram = new Gaugegram(0, 500, "G1", KnownColor.Navy);
            gaugegram2 = new Gaugegram(700, 1000, "G2", KnownColor.RoyalBlue);
            gaugegram.Value = 175;
            gaugegram2.Value = 800;

            for (int i=0; i<10; i++)
            {
                histogram2.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 1,
                    Value = 10 + 2 * i - 1
                });
                histogram2.Add(new Bin()
                {
                    Min = 2 * i + 1,
                    Max = 2 * i + 2,
                    Value = 10 + 2 * i
                });

                histogram.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = 5 - Math.Pow(i - 4, 2)
                });

                bargram.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = 93 - i * i
                });

                bargram2.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = 45 - i * i
                });
            }

            List<PointF> points1 = new();
            List<PointF> points2 = new();
            List<PointF> points3 = new();
            List<PointF> points4 = new();

            for (int i = 0; i < 20; i++)
            {
                points1.Add(new PointF(i, i * i));
                points2.Add(new PointF(i, (i + 2) * (i + 2)));
                points3.Add(new PointF(i, (i + 3) * (i + 3)));
                points4.Add(new PointF(i, (i + 4) * (i + 4)));
            }

            linegram.Add(new Line("F1", KnownColor.LimeGreen, points1));
            linegram.Add(new Line("F2", KnownColor.OrangeRed, points2, DrawMode.Drawline));
            linegram.Add(new Line("F3", KnownColor.CadetBlue, points3, DrawMode.Drawpoints));
            linegram.Add(new Line("F4", KnownColor.DodgerBlue, points4, DrawMode.Drawpoints | DrawMode.Drawline));

            piegram.Add(new Slice("S1", 5, KnownColor.Purple));
            piegram.Add(new Slice("S2", 30, KnownColor.OrangeRed));
            piegram.Add(new Slice("S3", 5, KnownColor.Gold));
            piegram.Add(new Slice("S4", 40, KnownColor.Aqua));
            piegram.Add(new Slice("S5", 15, KnownColor.DodgerBlue));

            polargram.Add(new Slice("primavera", 20, KnownColor.Purple));
            polargram.Add(new Slice("estate", 50, KnownColor.OrangeRed));
            polargram.Add(new Slice("autunno", 85, KnownColor.Gold));
            polargram.Add(new Slice("inverno", 25, KnownColor.Red));
            polargram.Add(new Slice("undefined", 40, KnownColor.DodgerBlue));

            radargram.Add(new Rating("C1",151));
            radargram.Add(new Rating("C2",130));
            radargram.Add(new Rating("C3",90));
            radargram.Add(new Rating("C4",80));
            radargram.Add(new Rating("C5",120));
            radargram.Add(new Rating("C6",50));

            gaugegram.AddBreakpoint(new Breakpoint()
            {
                Value = 150,
                Color = KnownColor.Green,
                Label = "LV-1"
            });
            gaugegram.AddBreakpoint(new Breakpoint()
            {
                Value = 250,
                Color = KnownColor.Gold,
                Label = "LV-2"
            });
            gaugegram.AddBreakpoint(new Breakpoint()
            {
                Value = 500,
                Color = KnownColor.Red,
                Label = "LV-3"
            });
        }

        private void BinClickHandler(Bin bin)
        {
            events.Add($"clicked bin: Min {bin.Min} - Max {bin.Max} - Value {bin.Value}");
        }

        private void BarClickHandler(Bar bar)
        {
            events.Add($"clicked bar: Label {bar.Label} - Value {bar.Value}");
        }

        private void SliceClickHandler(Slice slice)
        {
            events.Add($"clicked slice: Label {slice.Label} - Value {slice.Value}");
        }
    }
}
