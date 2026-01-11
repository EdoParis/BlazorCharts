using BlazorGraphs.Internal;
using BlazorGraphs.Structures;
using System;
using System.Collections;

namespace BlazorGraphs.Models
{
    public class Radargram : IEnumerable<Rating>
    {
        private List<Rating> Data;
        internal Axis AxisR { get; private set; }
        internal bool IsEmpty { get; private set; }
        public int Categories { get => Data?.Count ?? default; }

        public Radargram(string title_r)
        {
            Data = new();
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
            AxisR.Update(rating.Value);
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
    }
}
