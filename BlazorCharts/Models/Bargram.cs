using BlazorCharts.Structures;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Bargram : IEnumerable<KeyValuePair<String, Bin>>
    {
        private List<KeyValuePair<String, Bin>> bars;
        public ChartAxis AxisX { get; private set; }
        public ChartAxis AxisY { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int BarsCount { get => bars?.Count ?? default; }

        public Bargram(string title_x, string title_y)
        {
            bars = new List<KeyValuePair<String, Bin>>();
            AxisX = new ChartAxis(title_x);
            AxisY = new ChartAxis(title_y);
        }

        public void Clear()
        {
            bars.Clear();
            AxisX = new ChartAxis(TitleX);
            AxisY = new ChartAxis(TitleY);
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
