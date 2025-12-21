using BlazorCharts.Structures;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Linegram : IEnumerable<Line>
    {
        private List<Line> lines;
        public ChartAxis AxisX { get; private set; }
        public ChartAxis AxisY { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int LinesCount { get => lines?.Count ?? default; }

        public Linegram(string title_x, string title_y)
        {
            lines = new List<Line>();
            AxisX = new ChartAxis(title_x);
            AxisY = new ChartAxis(title_y);
        }

        public void Clear()
        {
            lines.Clear();
            AxisX = new ChartAxis(TitleX);
            AxisY = new ChartAxis(TitleY);
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
