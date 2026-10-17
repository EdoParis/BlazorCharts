using System.Drawing;

namespace BlazorGraphs.Core
{
    internal class Serie
    {
        public String Label { get; set; }
        public Color Color { get; set; }
    }

    internal sealed class Serie<T> : Serie where T : IValidable
    {
        private List<T> data;        
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
            ArgumentNullException.ThrowIfNull(values);
            List<T> list_values = values.ToList();

            foreach (T value in list_values)
            {
                ExceptionUtils.ThrowIfInvalid(value);
            }
            data.AddRange(list_values);
        }
    }
}
