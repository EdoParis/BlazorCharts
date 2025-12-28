using BlazorGraphs.Structures;
using System.Collections;
using System;

namespace BlazorGraphs.Models
{
    public class Piegram : IEnumerable<Slice>
    {
        private List<Slice> slices;
        internal bool IsEmpty { get; private set; }
        public double Total { get; private set; }
        public int SlicesCount { get => slices?.Count ?? default; }

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
            slices.Add(slice);
            Total += slice.Value;
            IsEmpty = (Total == 0);
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
