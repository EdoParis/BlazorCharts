using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using System.Drawing;

namespace BlazorGraphs.Internal
{
    internal sealed class Serie<T> where T : IValidable
    {
        private List<T> data;

        public string Label { get; set; }
        public KnownColor Color { get; set; }
        public IEnumerable<T> Data { get => data.AsReadOnly(); }
        public int Length { get => data.Count; }
        public bool IsEmpty { get => data.Count == 0; }

        public Serie()
        {
            data = new List<T>();
        }

        public void Clear()
        {
            data.Clear();
        }

        public void AddValue(T value)
        {
            InvalidArgumentException.ThrowIfInvalid(value);
            data.Add(value);
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                InvalidArgumentException.ThrowIfInvalid(value);
            }
            data.AddRange(values);
        }
    }
}
