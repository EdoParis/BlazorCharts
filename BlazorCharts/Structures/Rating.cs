using BlazorGraphs.Interfaces;
using System.Collections;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Rating : IValidable
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public Rating(string label, double value)
        {
            Label = label;
            Value = value;
        }

        public bool IsValid()
        {
            return Value >= 0 && string.IsNullOrWhiteSpace(Label);
        }
    }
}
