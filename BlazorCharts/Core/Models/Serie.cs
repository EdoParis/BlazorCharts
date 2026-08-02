using System.Drawing;

namespace BlazorGraphs.Core
{
    internal sealed class Serie<T> where T : IValidable
    {
        private List<T> data;

        public string Label { get; set; }
        public Color Color { get; set; }
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
            ExceptionUtils.ThrowIfInvalid(value);
            data.Add(value);
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                ExceptionUtils.ThrowIfInvalid(value);
            }
            data.AddRange(values);
        }
    }
}
