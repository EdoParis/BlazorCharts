using BlazorGraphs.Structures;
using BlazorGraphs.Exceptions;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Internal;
using BlazorGraphs.Legends;
using System.Collections;
using System;
using System.Drawing;

namespace BlazorGraphs.Models
{
    public class Bargram : IEnumerable<KeyValuePair<String, Bin>>, ILegend
    {
        private List<KeyValuePair<String, Bin>> bars;
        internal Axis BinAxis { get; private set; }
        internal Axis ValAxis { get; private set; }
        internal bool IsEmpty { get; private set; }
        public KnownColor PrimaryColor { get; private set; }
        public KnownColor SecondaryColor { get; private set; }
        public string Title { get => ValAxis?.Title; }
        public int BarsCount { get => bars?.Count ?? default; }

        public Bargram(string title_y, KnownColor color = KnownColor.Black)
        {
            bars = new List<KeyValuePair<String, Bin>>();
            ValAxis = new Axis(title_y);
            BinAxis = new Axis();
            PrimaryColor = color;
            SecondaryColor = color;
            IsEmpty = true;
        }

        public Bargram(string title_y, KnownColor primary_color, KnownColor secondary_color)
        {
            bars = new List<KeyValuePair<String, Bin>>();
            ValAxis = new Axis(title_y);
            BinAxis = new Axis();
            PrimaryColor = primary_color;
            SecondaryColor = secondary_color;
            IsEmpty = true;
        }

        public void Clear()
        {
            bars.Clear();
            BinAxis = new Axis();
            ValAxis = new Axis(Title);
            IsEmpty = true;
        }

        public void Add(Bar bar)
        {
            InvalidArgumentException.ThrowIfInvalid(bar);
            IsEmpty = false;

            Bin bin = new Bin()
            {
                Min = 2 * bars.Count + 1,
                Max = 2 * (bars.Count + 1),
                Value = bar.Value
            };
            bars.Add(KeyValuePair.Create(bar.Label, bin));
            BinAxis.Update(0);
            BinAxis.Update(bin.Max + 1);
            ValAxis.Update(0);
            ValAxis.Update(bin.Value);
        }

        public IEnumerator<KeyValuePair<String, Bin>> GetEnumerator()
        {
            return bars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<LegendItem> ToLegend()
        {
            if (PrimaryColor == SecondaryColor)
            {
                return [new LegendItem()
                {
                    Text = Title,
                    Color = PrimaryColor
                }];
            }
            else
            {
                return [new LegendItem()
                {
                    Text = $"↑ {Title}",
                    Color = PrimaryColor
                },
                new LegendItem()
                {
                    Text = $"↓ {Title}",
                    Color = SecondaryColor
                }];
            }
        }
    }
}
