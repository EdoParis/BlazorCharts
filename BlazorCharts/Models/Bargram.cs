using BlazorCharts.Structures;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Bargram : IEnumerable<KeyValuePair<String, Bin>>
    {
        private List<KeyValuePair<String, Bin>> bars;
        public Axis AxisX { get; private set; }
        public Axis AxisY { get; private set; }
        public string TitleX { get; private set; }
        public string TitleY { get; private set; }
        public int BarsCount { get => bars?.Count ?? default; }

        public Bargram(string title_x, string title_y)
        {
            bars = new List<KeyValuePair<String, Bin>>();
            TitleX = title_x;
            TitleY = title_y;
            AxisX = new Axis();
            AxisY = new Axis();
        }

        public void Clear()
        {
            bars.Clear();
            AxisX = new Axis();
            AxisY = new Axis();
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
            AxisX = AxisX.Update(bin.Min);
            AxisX = AxisX.Update(bin.Max);
            AxisY = AxisY.Update(default);
            AxisY = AxisY.Update(bin.Value);
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
