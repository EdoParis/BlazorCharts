using System.Drawing;
using BlazorGraphs;

namespace DemoApp.Pages
{
    public partial class Home
    {
        private Histogram histogram;
        private Histogram histogram2;
        private Bargram bargram;
        private Bargram bargram2;
        private Cartesiangram chartgram;
        private Cartesiangram chartgram2;
        private Bubblegram bubblegram;
        private Circulargram circulargram;
        private Radargram radargram;
        private Gaugegram gaugegram;
        private Gaugegram gaugegram2;
        private List<String> events;

        protected override void OnInitialized()
        {
            events = new List<string>();
            histogram = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue, Color.MediumPurple);
            histogram2 = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue);
            bargram = new Bargram("Axis-2", Color.MediumPurple);
            bargram2 = new Bargram("Axis-2", Color.MediumOrchid, Color.MediumSlateBlue);
            chartgram = new Cartesiangram("X1", "Y1");
            chartgram2 = new Cartesiangram("X1", "Y1");
            bubblegram = new Bubblegram("X1", "Y1");
            circulargram = new Circulargram("R1");
            radargram = new Radargram("R2", Color.MediumVioletRed);
            gaugegram = new Gaugegram(0, 500, "G1", Color.Navy);
            gaugegram2 = new Gaugegram(700, 1000, "G2", Color.RoyalBlue);
            gaugegram.Value = 170;
            gaugegram2.Value = 800;

            for (int i=5; i<15; i++)
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
                    Value = 20 - Math.Pow(i - 4, 2)
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

            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            List<Datapoint> points4 = new();
            List<Bubblepoint> bubbles1 = new();
            List<Bubblepoint> bubbles2 = new();

            for (int i = 0; i < 10; i++)
            {
                points1.Add(new Datapoint() { X = 2 * i, Y = 50 + i * i });
                points2.Add(new Datapoint() { X = 2 * i, Y = (i + 2) * (i + 2) });
                points3.Add(new Datapoint() { X = 2 * i, Y = (i + 4) * (i + 4) });
                points4.Add(new Datapoint() { X = 2 * i, Y = (i + 6) * (i + 6) });
                bubbles1.Add(new Bubblepoint() { X = 2 * i, Y = (i + 5) * (i + 4), Value = 25 + i });
                bubbles2.Add(new Bubblepoint() { X = 2 * i, Y = (i + 4) * (i + 4), Value = 10 + i });
            }

            Random rnd = new Random();
            List<Datapoint> points5 = new();
            List<Datapoint> points6 = new();
            List<Datapoint> points7 = new();
            for (int i = 0; i < 20; i++)
            {
                points5.Add(new Datapoint() { X = 10 * rnd.NextDouble(), Y = 10 * rnd.NextDouble() });
                points6.Add(new Datapoint() { X = 5 + 20 * rnd.NextDouble(), Y = 5 + 20 * rnd.NextDouble() });
                points7.Add(new Datapoint() { X = 50 * rnd.NextDouble(), Y = 20 + 5 * rnd.NextDouble() });
            }

            chartgram.AddSerie("F1", Color.LimeGreen, points1);
            chartgram.AddSerie("F2", Color.OrangeRed, points2);
            chartgram.AddSerie("F3", Color.CadetBlue, points3);
            chartgram.AddSerie("F4", Color.DodgerBlue, points4);

            chartgram2.AddSerie("F1", Color.Gold, points5);
            chartgram2.AddSerie("F2", Color.OrangeRed, points6);
            chartgram2.AddSerie("F3", Color.RoyalBlue, points7);

            bubblegram.AddSerie("B1", Color.MediumPurple, bubbles1);
            bubblegram.AddSerie("B2", Color.OrangeRed, bubbles2);

            circulargram.Add(new Slice("S1", 22, Color.Purple));
            circulargram.Add(new Slice("S2", 40, Color.OrangeRed));
            circulargram.Add(new Slice("S4", 58, Color.Gold));
            circulargram.Add(new Slice("S3", 75, Color.Aqua));
            circulargram.Add(new Slice("S5", 45, Color.DodgerBlue));

            radargram.Add(new Rating("C1",140));
            radargram.Add(new Rating("C2",130));
            radargram.Add(new Rating("C3",90));
            radargram.Add(new Rating("C4",80));
            radargram.Add(new Rating("C5",120));
            radargram.Add(new Rating("C6",175));
            radargram.Add(new Rating("B9",150));
            radargram.Add(new Rating("D1",100));

            gaugegram.AddBreakpoint(new Breakpoint()
            {
                Value = 150,
                Color = Color.Green,
            });
            gaugegram.AddBreakpoint(new Breakpoint()
            {
                Value = 250,
                Color = Color.Gold,
            });
            gaugegram.AddBreakpoint(new Breakpoint()
            {
                Value = 500,
                Color = Color.Red,
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
