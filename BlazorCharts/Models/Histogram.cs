using BlazorGraphs.Structures;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System;
using System.Collections;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public class Histogram : IEnumerable<Bin>, ILegend
    {
        private List<Bin> bins;
        internal Axis AxisX { get; private set; }
        internal Axis AxisY { get; private set; }
        internal bool IsEmpty { get; private set; }
        public KnownColor Color { get; private set; }
        public string TitleX { get => AxisX?.Title; }
        public string TitleY { get => AxisY?.Title; }
        public int BinsCount { get => bins?.Count ?? default; }

        public Histogram(string title_x, string title_y, KnownColor color = KnownColor.Black)
        {
            bins = new List<Bin>();
            AxisX = new Axis(title_x);
            AxisY = new Axis(title_y);
            Color = color;
            IsEmpty = true;
        }

        public void Clear()
        {
            bins.Clear();
            AxisX = new Axis(TitleX);
            AxisY = new Axis(TitleY);
            IsEmpty = true;
        }

        public void Add(Bin bin)
        {
            IsEmpty = false;
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

        public IEnumerable<LegendItem> ToLegend()
        {
            return [new LegendItem() {
                Text = TitleY,
                Color = Color
            }];
        }
    }
}
