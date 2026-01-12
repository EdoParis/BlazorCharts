using BlazorGraphs.Internal;
using BlazorGraphs.Structures;
using System;
using System.Collections;

namespace BlazorGraphs.Models
{
    public class Polargram : IEnumerable<Slice>
    {
        private List<Slice> slices;
        internal Axis AxisR { get; private set; }
        internal bool IsEmpty { get; private set; }
        public int SlicesCount { get => slices?.Count ?? default; }

        public Polargram(string title_r)
        {
            slices = new List<Slice>();
            AxisR = new Axis(title_r);
            IsEmpty = true;
        }

        public void Clear()
        {
            slices.Clear();
            IsEmpty = true;
        }

        public void Add(Slice slice)
        {
            slices.Add(slice);
            AxisR.Update(0);
            AxisR.Update((int)(slice.Value / 5 + 1) * 5);
            IsEmpty = false;
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
