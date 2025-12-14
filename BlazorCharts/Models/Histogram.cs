using BlazorCharts.Structures;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Histogram : IEnumerable<Bin>
    {
        private List<Bin> bins;
        public Axis AxisX { get; private set; }
        public Axis AxisY { get; private set; }
        public string TitleX { get; private set; }
        public string TitleY { get; private set; }
        public int BinsCount { get => bins?.Count ?? default; }

        public Histogram(string title_x, string title_y)
        {
            bins = new List<Bin>();
            TitleX = title_x;
            TitleY = title_y;
            AxisX = new Axis();
            AxisY = new Axis();
        }

        public void Clear()
        {
            bins.Clear();
            AxisX = new Axis();
            AxisY = new Axis();
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
