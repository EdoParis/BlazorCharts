using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs
{
    public class Cartesiangram : ILegend
    { 
        private List<Serie<Datapoint>> series;
        internal bool IsEmpty { get; private set; }
        internal NumericAxis AxisX { get; private set; }
        internal NumericAxis AxisY { get; private set; }
        internal IEnumerable<Serie<Datapoint>> Series { get => series.AsReadOnly(); }
        public int SeriesCount { get => series?.Count ?? default; }
        public string TitleX { get; set; }
        public string TitleY { get; set; }

        public Cartesiangram(string title_x, string title_y)
        {
            series = new List<Serie<Datapoint>>();
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            IsEmpty = true;
            TitleX = title_x;
            TitleY = title_y;
        }

        public void Clear()
        {
            series.ForEach(s => s?.Clear());
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            series.Clear();
            IsEmpty = true;
        }

        public void AddSerie(string label, Color color, IEnumerable<Datapoint> points)
        {
            Serie<Datapoint> serie = new Serie<Datapoint>()
            {
                Label = label,
                Color = color
            };
            serie.AddRange(points);
            series.Add(serie);
            AxisX.Include(Interval.From(points.Select(p => p.X)));
            AxisY.Include(Interval.From(points.Select(p => p.Y)));
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
