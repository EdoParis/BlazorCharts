using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public class Bubblegram : ILegend
    { 
        private List<Serie<Bubblepoint>> series;
        internal Boolean IsEmpty { get; private set; }
        internal NumeriAxis AxisX { get; private set; }
        internal NumeriAxis AxisY { get; private set; }
        internal NumeriAxis AxisB { get; private set; }
        internal IEnumerable<Serie<Bubblepoint>> Series { get => series.AsReadOnly(); }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }

        public Bubblegram(string title_x, string title_y)
        {
            series = new List<Serie<Bubblepoint>>();
            AxisX = new NumeriAxis(title_x);
            AxisY = new NumeriAxis(title_y);
            AxisB = new NumeriAxis();
            IsEmpty = true;
        }

        public void Clear()
        {
            series.ForEach(s => s?.Clear());
            AxisX = new NumeriAxis(TitleX);
            AxisY = new NumeriAxis(TitleY);
            AxisB = new NumeriAxis();
            series.Clear();
            IsEmpty = true;
        }

        public void AddSerie(string label, KnownColor color, IEnumerable<Bubblepoint> points)
        {
            Serie<Bubblepoint> serie = new Serie<Bubblepoint>()
            {
                Label = label,
                Color = color
            };
            serie.AddRange(points);
            series.Add(serie);
            AxisX.Update(new Interval(points?.Select(p => p.X)));
            AxisY.Update(new Interval(points?.Select(p => p.Y)));
            AxisB.Update(new Interval(points?.Select(p => p.Radius)));
            IsEmpty = IsEmpty && serie.IsEmpty;
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            return series.Select(s => new LegendItem()
            {
                Color = s.Color,
                Text = s.Label
            });
        }
    }
}
