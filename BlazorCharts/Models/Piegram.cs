using BlazorCharts.Structures;
using System.Collections;
using System;

namespace BlazorCharts.Models
{
    public class Piegram : IEnumerable<Slice>
    {
        private List<Slice> slices;
        public double Total { get; private set; }
        public int SlicesCount { get => slices?.Count ?? default; }

        public Piegram()
        {
            slices = new List<Slice>();
            Total = default;
        }

        public void Clear()
        {
            slices.Clear();
            Total = default;
        }

        public void Add(Slice slice)
        {
            slices.Add(slice);
            Total += slice.Value;
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
