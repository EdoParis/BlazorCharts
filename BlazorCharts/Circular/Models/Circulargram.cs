using BlazorGraphs.Core;
using System.Collections;

namespace BlazorGraphs
{
    public class Circulargram : IEnumerable<Slice>, ILegend
    {
        private List<Slice> slices;
        internal NumericAxis AxisR { get; private set; }
        internal bool IsEmpty { get; private set; }
        public double Total { get; private set; }
        public int SlicesCount { get => slices?.Count ?? default; }
        public string Title { get; private set; }

        public Circulargram(string title = null)
        {
            slices = new List<Slice>();
            AxisR = new NumericAxis();
            Total = default;
            Title = title;
            IsEmpty = true;
        }

        public void Clear()
        {
            slices.Clear();
            Total = default;
            IsEmpty = true;
        }

        public void Add(Slice slice)
        {
            ExceptionUtils.ThrowIfInvalid(slice);
            slices.Add(slice);
            AxisR.Include(0);
            AxisR.Include((int)(slice.Value / 25 + 1) * 25);
            Total += slice.Value;
            IsEmpty = Total == 0;
        }

        public void AddRange(IEnumerable<Slice> collection)
        {
            foreach (Slice slice in collection)
                Add(slice);
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            return slices.Select(s => new LegendItem(s));
        }

        public IEnumerator<Slice> GetEnumerator()
        {
            return slices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
