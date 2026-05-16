using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using BlazorGraphs.Structures;
using System.Drawing;
using System.Collections;

namespace BlazorGraphs.Models
{
    public class Gaugegram : IEnumerable<Breakpoint>, ILegend
    {
        private List<Breakpoint> breakpoints;
        internal Axis Axis { get; private set; }
        public KnownColor Color { get; private set; }
        public double Value { get; set; }
        public bool HasBreakPoints { get => breakpoints?.Count > 0; }

        public Gaugegram(double min, double max, string title, KnownColor color = KnownColor.Black)
        {
            Span range = new Span(min, max);
            breakpoints = new List<Breakpoint>();
            Axis = new Axis(range, title);
            Color = color;
            Value = min;
        }

        public void AddBreakpoint(Breakpoint breakpoint)
        {
            InvalidArgumentException.ThrowIfInvalid(breakpoint);
            ArgumentOutOfRangeException.ThrowIfLessThan(breakpoint.Value, Axis.Min);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(breakpoint.Value, Axis.Max);

            for (int i = 0; i < breakpoints.Count; i++)
            {
                if (breakpoints[i].Value == breakpoint.Value)
                    throw new ArgumentException($"breakpoint already present with value: {breakpoint.Value}");

                if (breakpoints[i].Value > breakpoint.Value)
                {
                    breakpoints.Insert(i, breakpoint);
                    return;
                }
            }
            breakpoints.Add(breakpoint);
        }

        public void Clear()
        {
            breakpoints.Clear();
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            if (breakpoints.Any())
            {
                return breakpoints.Select(t => new LegendItem(t));
            }
            else
            {
                return [new LegendItem()
                {
                    Color = Color,
                    Text = Axis.Title
                }];
            }
        }

        public IEnumerator<Breakpoint> GetEnumerator()
        {
            return breakpoints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
