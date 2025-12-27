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
        private List<String> events;

        protected override void OnInitialized()
        {
            events = new List<string>();
            histogram = new Histogram("asseX", "asseY");
            bargram = new Bargram("asse-1", "asse-2");
            linegram = new Linegram("X1", "Y1");
            piegram = new Piegram();

            for (int i=0; i<22; i++)
            {
                histogram.Add(new Bin()
                {
                    Min = i,
                    Max = i + 1,
                    Value = i * i
                });

                bargram.Add(new Bar()
                {
                    Label = $"{i + 1}",
                    Value = 10 + i
                });
            }

            List<PointF> points1 = new();
            List<PointF> points2 = new();
            for (int i=0; i<100; i++)
            {
                points1.Add(new PointF(i * (float)Math.Cos(i / 10f * Math.PI), i * (float)Math.Sin(i / 10f * Math.PI)));
                points2.Add(new PointF(i * (float)Math.Cos(i / 50f * Math.PI), i * (float)Math.Sin(i / 50f * Math.PI)));
            }

            linegram.Add(new Line("F1", KnownColor.Orange, points1));
            linegram.Add(new Line("F2", KnownColor.LimeGreen, points2));

            piegram.Add(new Slice("S1", 40, KnownColor.CadetBlue));
            piegram.Add(new Slice("S2", 20, KnownColor.OrangeRed));
            piegram.Add(new Slice("S3", 20, KnownColor.Gold));
            piegram.Add(new Slice("S4", 5, KnownColor.DodgerBlue));
        }

        private void BinClickHandler(Bin bin)
        {
            events.Add($"clicked bin: Min {bin.Min} - Max {bin.Max} - Value {bin.Value}");
        }

        private void BarClickHandler(Bar bar)
        {
            events.Add($"clicked bar: Label {bar.Label} - Value {bar.Value}");
        }
    }
}
