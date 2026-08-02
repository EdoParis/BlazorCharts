using System.Collections;
using System.Drawing;
using BlazorGraphs.Core;

namespace BlazorGraphs
{
    public class Radargram : IEnumerable<Rating>, ILegend
    {
        private List<Rating> Data;
        internal NumericAxis AxisR { get; private set; }
        internal bool IsEmpty { get; private set; }
        public Color Color { get; private set; }
        public string Title { get; private set; }
        public int Categories { get => Data?.Count ?? default; }

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
            ExceptionUtils.ThrowIfInvalid(rating);
            Data.Add(rating);
            AxisR.Update(0);
            AxisR.Update((int)(rating.Value / 25 + 1) * 25);
            IsEmpty = false;
        }

        public void AddRange(IEnumerable<Rating> collection)
        {
            foreach (Rating rating in collection)
                Add(rating);
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
