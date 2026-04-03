using BlazorGraphs.Structures;
using System.Collections;
using System;

namespace BlazorGraphs.Legends
{
    public class LegendModel : IEnumerable<LegendItem>
    {
        private List<LegendItem> items;

        public LegendModel()
        {
            items = new();
        }

        public void Add(LegendItem item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public static LegendModel Build(IEnumerable<Slice> elements)
        {
            ArgumentNullException.ThrowIfNull(elements);

            LegendModel legend = new();

            foreach (Slice slice in elements)
            {
                legend.Add(new LegendItem(slice));
            }
            return legend;
        }

        public static LegendModel Build(IEnumerable<Line> elements)
        {
            ArgumentNullException.ThrowIfNull(elements);

            LegendModel legend = new();

            foreach (Line line in elements)
            {
                legend.Add(new LegendItem(line));
            }
            return legend;
        }

        public IEnumerator<LegendItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
