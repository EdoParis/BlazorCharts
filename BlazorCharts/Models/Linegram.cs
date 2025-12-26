using BlazorCharts.Structures;
using BlazorCharts.Internal;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Linegram : IEnumerable<Line>
    {
        private List<Line> lines;
        internal Axis AxisX { get; private set; }
        internal Axis AxisY { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int LinesCount { get => lines?.Count ?? default; }

        public Linegram(string title_x, string title_y)
        {
            lines = new List<Line>();
            AxisX = new Axis(title_x);
            AxisY = new Axis(title_y);
        }

        public void Clear()
        {
            lines.Clear();
            AxisX = new Axis(TitleX);
            AxisY = new Axis(TitleY);
        }

        public void Add(Line line)
        {
            lines.Add(line);
            AxisX.Update(line.RangeX);
            AxisY.Update(line.RangeY);
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
