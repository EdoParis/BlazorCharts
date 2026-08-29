using BlazorGraphs.Core;
using System.Collections;
using System.Drawing;

namespace BlazorGraphs
{
    public class Bargram : IEnumerable<KeyValuePair<string, Bin>>, ILegend
    {
        private List<KeyValuePair<string, Bin>> bars;
        internal NumericAxis BinAxis { get; private set; }
        internal NumericAxis ValAxis { get; private set; }
        internal bool IsEmpty { get; private set; }
        public string Title { get; private set; }
        public Color PrimaryColor { get; private set; }
        public Color SecondaryColor { get; private set; }
        public int BarsCount { get => bars?.Count ?? default; }

        public Bargram(string title_y, Color color)
        {
            bars = new List<KeyValuePair<string, Bin>>();
            ValAxis = new NumericAxis();
            BinAxis = new NumericAxis();
            PrimaryColor = color;
            SecondaryColor = color;
            IsEmpty = true;
            Title = title_y;
        }

        public Bargram(string title_y, Color primary_color, Color secondary_color)
        {
            bars = new List<KeyValuePair<string, Bin>>();
            ValAxis = new NumericAxis();
            BinAxis = new NumericAxis();
            PrimaryColor = primary_color;
            SecondaryColor = secondary_color;
            IsEmpty = true;
            Title = title_y;
        }

        public void Clear()
        {
            bars.Clear();
            BinAxis = new NumericAxis();
            ValAxis = new NumericAxis();
            IsEmpty = true;
        }

        public void Add(Bar bar)
        {
            ExceptionUtils.ThrowIfInvalid(bar);
            IsEmpty = false;

            Bin bin = new Bin()
            {
                Min = 2 * bars.Count + 1,
                Max = 2 * (bars.Count + 1),
                Value = bar.Value
            };
            bars.Add(KeyValuePair.Create(bar.Label, bin));
            BinAxis.Include(0);
            BinAxis.Include(bin.Max + 1);
            ValAxis.Include(0);
            ValAxis.Include(bin.Value);
        }

        public void AddRange(IEnumerable<Bar> collection)
        {
            foreach (Bar bar in collection)
                Add(bar);
        }

        public IEnumerator<KeyValuePair<string, Bin>> GetEnumerator()
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
                    Text = $"{Title} ≥ 0",
                    Color = PrimaryColor
                },
                new LegendItem()
                {
                    Text = $"{Title} < 0",
                    Color = SecondaryColor
                }];
            }
        }
    }
}
