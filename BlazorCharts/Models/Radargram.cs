using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System.Collections;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public class Radargram : IEnumerable<Rating>, ILegend
    {
        private List<Rating> Data;
        internal NumericAxis AxisR { get; private set; }
        internal Boolean IsEmpty { get; private set; }
        public Color Color { get; private set; }
        public String Title { get; private set; }
        public Int32 Categories { get => Data?.Count ?? default; }

        public Radargram(string title, Color color)
        {
            Data = new();
            Color = color;
            AxisR = new NumericAxis();
            Title = title;
            IsEmpty = true;
        }

        public void Clear()
        {
            Data.Clear();
            IsEmpty = true;
        }

        public void Add(Rating rating)
        {
            InvalidArgumentException.ThrowIfInvalid(rating);

            Data.Add(rating);
            AxisR.Update(0);
            AxisR.Update((int)(rating.Value / 25 + 1) * 25);
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
