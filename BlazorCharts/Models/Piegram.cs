using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using BlazorGraphs.Legends;
using System.Collections;

namespace BlazorGraphs.Models
{
    public class Piegram : IEnumerable<Slice>, ILegend
    {
        private List<Slice> slices;
        internal Boolean IsEmpty { get; private set; }
        public Double Total { get; private set; }
        public Int32 SlicesCount { get => slices?.Count ?? default; }

        public Piegram()
        {
            slices = new List<Slice>();
            Total = default;
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
            InvalidArgumentException.ThrowIfInvalid(slice);

            slices.Add(slice);
            Total += slice.Value;
            IsEmpty = (Total == 0);
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
