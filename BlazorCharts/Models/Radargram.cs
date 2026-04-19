using BlazorGraphs.Structures;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System;
using System.Collections;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public class Radargram : IEnumerable<Rating>, ILegend
    {
        private List<Rating> Data;
        internal Axis AxisR { get; private set; }
        internal bool IsEmpty { get; private set; }
        public KnownColor Color { get; private set; }
        public string Title { get => AxisR?.Title; }
        public int Categories { get => Data?.Count ?? default; }

        public Radargram(string title_r, KnownColor color = KnownColor.Black)
        {
            Data = new();
            Color = color;
            AxisR = new Axis(title_r);
            IsEmpty = true;
        }

        public void Clear()
        {
            Data.Clear();
            IsEmpty = true;
        }

        public void Add(Rating rating)
        {
            Data.Add(rating);
            AxisR.Update(0);
            AxisR.Update((int)(rating.Value % 5 == 0 ? rating.Value : (rating.Value / 5 + 5) * 5));
            IsEmpty = false;
        }

        public IEnumerator<Rating> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            return [new LegendItem() {
                Text = Title,
                Color = Color
            }];
        }
    }
}
