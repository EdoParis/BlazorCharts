using BlazorCharts.Structures;
using BlazorCharts.Internal;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Bargram : IEnumerable<KeyValuePair<String, Bin>>
    {
        private List<KeyValuePair<String, Bin>> bars;
        internal Axis AxisX { get; private set; }
        internal Axis AxisY { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int BarsCount { get => bars?.Count ?? default; }

        public Bargram(string title_x, string title_y)
        {
            bars = new List<KeyValuePair<String, Bin>>();
            AxisX = new Axis(title_x);
            AxisY = new Axis(title_y);
        }

        public void Clear()
        {
            bars.Clear();
            AxisX = new Axis(TitleX);
            AxisY = new Axis(TitleY);
        }

        public void Add(Bar bar)
        {
            Bin bin = new Bin()
            {
                Min = 2 * bars.Count,
                Max = 2 * bars.Count + 1,
                Value = bar.Value
            };
            bars.Add(KeyValuePair.Create(bar.Label, bin));
            AxisX.Update(bin.Min);
            AxisX.Update(bin.Max);
            AxisY.Update(0);
            AxisY.Update(bin.Value);
        }

        public IEnumerator<KeyValuePair<String, Bin>> GetEnumerator()
        {
            return bars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
