using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using BlazorGraphs.Structures;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public class Gaugegram : ILegend
    {
        private List<Threshold> Thresholds;
        internal Axis ValAxis { get; private set; }
        public KnownColor Color { get; private set; }
        public double Value { get; set; }

        public Gaugegram(double min, double max, string title, KnownColor color = KnownColor.Black)
        {
            Span interval = new Span(min, max);
            Thresholds = new List<Threshold>();
            ValAxis = new Axis(interval, title);
            Color = color;
        }

        public void Add(Threshold threshold)
        {
            InvalidArgumentException.ThrowIfInvalid(threshold);
            ArgumentOutOfRangeException.ThrowIfLessThan(threshold.From, ValAxis.Min);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(threshold.To, ValAxis.Max);                

            foreach (Threshold th in Thresholds)
            {
                if (threshold.Overlap(th))
                    throw new ArgumentException("Thresholds overlapping");
            }
            Thresholds.Add(threshold);
        }

        public void Clear()
        {
            Thresholds.Clear();
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            if (Thresholds.Any())
            {
                return Thresholds.Select(t => new LegendItem(t));
            }
            else
            {
                return [new LegendItem()
                {
                    Color = Color,
                    Text = ValAxis.Title
                }];
            }
        }
    }
}
