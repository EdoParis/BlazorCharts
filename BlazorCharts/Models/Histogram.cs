using BlazorCharts.Structures;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Histogram : IEnumerable<Bin>
    {
        private List<Bin> bins;
        public ChartAxis AxisX { get; private set; }
        public ChartAxis AxisY { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int BinsCount { get => bins?.Count ?? default; }

        public Histogram(string title_x, string title_y)
        {
            bins = new List<Bin>();
            AxisX = new ChartAxis(title_x);
            AxisY = new ChartAxis(title_y);
        }

        public void Clear()
        {
            bins.Clear();
            AxisX = new ChartAxis();
            AxisY = new ChartAxis();
        }

        public void Add(Bin bin)
        {
            bins.Add(bin);
            AxisX.Update(bin.Min);
            AxisX.Update(bin.Max);
            AxisY.Update(default);
            AxisY.Update(bin.Value);
        }

        public IEnumerator<Bin> GetEnumerator()
        {
            return bins.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
