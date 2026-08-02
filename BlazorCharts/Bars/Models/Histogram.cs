using BlazorGraphs.Core;
using System.Collections;
using System.Drawing;

namespace BlazorGraphs
{
    public class Histogram : IEnumerable<Bin>, ILegend
    {
        private List<Bin> bins;
        internal NumericAxis AxisX { get; private set; }
        internal NumericAxis AxisY { get; private set; }
        internal bool IsEmpty { get; private set; }
        public Color PrimaryColor { get; private set; }
        public Color SecondaryColor { get; private set; }
        public string TitleX { get; private set; }
        public string TitleY { get; private set; }
        public int BinsCount { get => bins?.Count ?? default; }

        public Histogram(string title_x, string title_y, Color color)
        {
            bins = new List<Bin>();
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            PrimaryColor = color;
            SecondaryColor = color;
            TitleX = title_x;
            TitleY = title_y;
            IsEmpty = true;
        }

        public Histogram(string title_x, string title_y, Color primary_color, Color secondary_color)
        {
            bins = new List<Bin>();
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            PrimaryColor = primary_color;
            SecondaryColor = secondary_color;
            TitleX = title_x;
            TitleY = title_y;
            IsEmpty = true;
        }

        public void Clear()
        {
            bins.Clear();
            AxisX = new NumericAxis();
            AxisY = new NumericAxis();
            IsEmpty = true;
        }

        public void Add(Bin bin)
        {
            ExceptionUtils.ThrowIfInvalid(bin);
            IsEmpty = false;
            bins.Add(bin);
            AxisX.Update(bin.Min);
            AxisX.Update(bin.Max);
            AxisY.Update(0);
            AxisY.Update(bin.Value);
        }

        public IEnumerator<Bin> GetEnumerator()
        {
            return bins.GetEnumerator();
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
                    Text = TitleY,
                    Color = PrimaryColor
                }];
            }
            else
            {
                return [new LegendItem() 
                {
                    Text = $"{TitleY} ≥ 0",
                    Color = PrimaryColor
                }, 
                new LegendItem()
                {
                    Text = $"{TitleY} < 0",
                    Color = SecondaryColor
                }];
            }
        }
    }
}
