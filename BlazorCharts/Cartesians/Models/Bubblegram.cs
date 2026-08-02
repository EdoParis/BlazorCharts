using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs
{
    public class Bubblegram : ILegend
    { 
        private List<Serie<Bubblepoint>> series;
        internal bool IsEmpty { get; private set; }
        internal NumericAxis AxisX { get; private set; }
        internal NumericAxis AxisY { get; private set; }
        internal NumericAxis AxisB { get; private set; }
        internal IEnumerable<Serie<Bubblepoint>> Series { get => series.AsReadOnly(); }
        public string TitleX { get; private set; }
        public string TitleY { get; private set; }

        public Bubblegram(string title_x, string title_y)
        {
            series = new List<Serie<Bubblepoint>>();
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            AxisB = new NumericAxis();
            IsEmpty = true;
            TitleX = title_x;
            TitleY = title_y;
        }

        public void Clear()
        {
            series.ForEach(s => s?.Clear());
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            AxisB = new NumericAxis();
            series.Clear();
            IsEmpty = true;
        }

        public void AddSerie(string label, Color color, IEnumerable<Bubblepoint> points)
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
