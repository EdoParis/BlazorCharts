using Microsoft.AspNetCore.Components;
using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class DonutChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Circulargram Model { get; set; }
        [Parameter] public EventCallback<Slice> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private TextLayout LayoutSliceValue;
        private TextLayout LayoutTotalValue;
        private TextLayout LayoutTextTitle;

        protected override void OnParametersSet()
        {
            LayoutSliceValue.WithTheme(Theme);
            LayoutTotalValue.WithTheme(Theme);
            LayoutTextTitle.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutSliceValue = TextLayout.MiddleLayout()
                                         .WithTheme(Theme)
                                         .Medium();

            LayoutTotalValue = TextLayout.MiddleLayout()
                                         .WithTheme(Theme)
                                         .Large()
                                         .At(height / 2, width / 2);

            LayoutTextTitle = TextLayout.MiddleLayout()
                                        .Medium()
                                        .At(width / 2, padding / 5)
                                        .WithTheme(Theme);
        }

        private string SlicePath(Slice slice, double rotation = 0)
        {
            double radius_out = Math.Min(width, height) / 2 - padding;
            double radius_in = 2 * radius_out / 3;
            double theta = 2 * Math.PI * slice.Value / Model.Total;
            bool is_wide = theta > Math.PI;

            return $"M {(int)(width / 2 + radius_in * Math.Sin(rotation))} {(int)(height / 2 - radius_in * Math.Cos(rotation))}  " +
                   $"L {(int)(width / 2 + radius_out * Math.Sin(rotation))} {(int)(height / 2 - radius_out * Math.Cos(rotation))} " +
                   $"A {(int)radius_out} {(int)radius_out} 0 {(is_wide ? 1 : 0)} 1 {(int)(width / 2 + radius_out * Math.Sin(theta + rotation))} {(int)(height / 2 - radius_out * Math.Cos(theta + rotation))} " +
                   $"L {(int)(width / 2 + radius_in * Math.Sin(theta + rotation))} {(int)(height / 2 - radius_in * Math.Cos(theta + rotation))} " +
                   $"A {(int)radius_in} {(int)radius_in} 0 {(is_wide ? 1 : 0)} 0 {(int)(width / 2 + radius_in * Math.Sin(rotation))} {(int)(height / 2 - radius_in * Math.Cos(rotation))} " +
                   "Z";
        }

        private Point SliceMidPoint(Slice slice, double rotation = 0)
        {
            double radius = (Math.Min(width, height) / 2 - padding) * 5 / 6;
            double theta = Math.PI * slice.Value / Model.Total;

            return new Point()
            {
                X = (int)(width / 2 + radius * Math.Sin(theta + rotation)),
                Y = (int)(height / 2 - radius * Math.Cos(theta + rotation))
            };
        }

        private Point SliceExternalPoint(Slice slice, double rotation = 0)
        {
            double radius = 1.1 * (Math.Min(width, height) - 2 * padding) / 2;
            double theta = Math.PI * slice.Value / Model.Total;

            return new Point()
            {
                X = (int)(width / 2 + radius * Math.Sin(theta + rotation)),
                Y = (int)(height / 2 - radius * Math.Cos(theta + rotation))
            };
        }
    }
}
