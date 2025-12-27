using BlazorGraphs.Structures;
using BlazorGraphs.Internal;
using System.Collections;
using System;

namespace BlazorGraphs.Models
{
    public class Histogram : IEnumerable<Bin>
    {
        private List<Bin> bins;
        internal Axis AxisX { get; private set; }
        internal Axis AxisY { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int BinsCount { get => bins?.Count ?? default; }

        public Histogram(string title_x, string title_y)
        {
            bins = new List<Bin>();
            AxisX = new Axis(title_x);
            AxisY = new Axis(title_y);
        }

        public void Clear()
        {
            bins.Clear();
            AxisX = new Axis(TitleX);
            AxisY = new Axis(TitleY);
        }

        public void Add(Bin bin)
        {
            bins.Add(bin);
            AxisX.Update(bin.Min);
            AxisX.Update(bin.Max);
            AxisY.Update(0);
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
