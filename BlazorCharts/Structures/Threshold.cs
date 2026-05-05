using BlazorGraphs.Interfaces;
using System;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Threshold : IValidable
    {
        public string Label { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public KnownColor Color { get; set; }

        public bool Overlap(Threshold other)
        {
            return other.From < To && other.To > From;
        }

        public bool IsValid()
        {
            return !(From >= To ||
                    double.IsInfinity(From) ||
                    double.IsInfinity(To) ||
                    double.IsNaN(From) ||
                    double.IsNaN(To));
        }
    }
}
