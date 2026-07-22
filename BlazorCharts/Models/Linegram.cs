using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System.Collections;

namespace BlazorGraphs.Models
{
    public class Linegram : IEnumerable<Line>, ILegend
    {
        private List<Line> lines;
        internal NumeriAxis AxisX { get; private set; }
        internal NumeriAxis AxisY { get; private set; }
        internal bool IsEmpty { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int LinesCount { get => lines?.Count ?? default; }

        public Linegram(string title_x, string title_y)
        {
            lines = new List<Line>();
            AxisX = new NumeriAxis(title_x);
            AxisY = new NumeriAxis(title_y);
            IsEmpty = true;
        }

        public void Clear()
        {
            lines.Clear();
            AxisX = new NumeriAxis(TitleX);
            AxisY = new NumeriAxis(TitleY);
            IsEmpty = true;
        }

        public void Add(Line line)
        {
            ArgumentNullException.ThrowIfNull(line);
            InvalidArgumentException.ThrowIfInvalid(line);

            IsEmpty = IsEmpty && !(line.Points?.Any() ?? false);
            lines.Add(line);
            AxisX.Update(new Interval(line.Points?.Select(p => p.X)));
            AxisY.Update(new Interval(line.Points?.Select(p => p.Y)));
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            return lines.Select(l => new LegendItem(l));
        }

        public IEnumerator<Line> GetEnumerator()
        {
            return lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
