using BlazorGraphs.Enums;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using System.Drawing;

namespace DemoApp.Pages
{
    public partial class Home
    {
        private Histogram histogram;
        private Bargram bargram;
        private Linegram linegram;
        private Piegram piegram;
        private Polargram polargram;
        private Radargram radargram;
        private List<String> events;

        protected override void OnInitialized()
        {
            events = new List<string>();
            histogram = new Histogram("asseX", "asseY");
            bargram = new Bargram("asse-2");
            linegram = new Linegram("X1", "Y1");
            piegram = new Piegram();
            polargram = new Polargram("R1");
            radargram = new Radargram("R2");

            for (int i=0; i<10; i++)
            {
                histogram.Add(new Bin()
                {
                    Min = -20 + i,
                    Max = -20 + i + 1,
                    Value = -10 + 3 * i
                });

                bargram.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = 93 - i * i
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

            radargram.Add(new Rating("C1",151));
            radargram.Add(new Rating("C2",130));
            radargram.Add(new Rating("C3",90));
            radargram.Add(new Rating("C4",80));
            radargram.Add(new Rating("C5",120));
            radargram.Add(new Rating("C6",50));
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
