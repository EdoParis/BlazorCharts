using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System.Collections;

namespace BlazorGraphs.Models
{
    public class Polargram : IEnumerable<Slice>, ILegend
    {
        private List<Slice> slices;
        internal NumericAxis AxisR { get; private set; }
        internal Boolean IsEmpty { get; private set; }
        public String Title { get; private set; }
        public Int32 SlicesCount { get => slices?.Count ?? default; }

        public Polargram(string title)
        {
            slices = new List<Slice>();
            AxisR = new NumericAxis();
            Title = title;
            IsEmpty = true;
        }

        public void Clear()
        {
            slices.Clear();
            IsEmpty = true;
        }

        public void Add(Slice slice)
        {
            InvalidArgumentException.ThrowIfInvalid(slice);

            slices.Add(slice);
            AxisR.Update(0);
            AxisR.Update((int)(slice.Value / 25 + 1) * 25);
            IsEmpty = false;
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
