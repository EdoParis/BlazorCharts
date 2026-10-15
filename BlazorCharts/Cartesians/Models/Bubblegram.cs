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
        public int SeriesCount { get => series?.Count ?? default; }
        public string TitleX { get; set; }
        public string TitleY { get; set; }

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
            if (!serie.IsEmpty)
            {
                AxisX.Include(Interval.From(serie.Data.Select(p => p.X)));
                AxisY.Include(Interval.From(serie.Data.Select(p => p.Y)));
                AxisB.Include(Interval.From(serie.Data.Select(p => p.Radius)));
                IsEmpty = false;
            }
            series.Add(serie);
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
