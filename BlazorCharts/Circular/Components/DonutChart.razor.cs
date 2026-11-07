using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class DonutChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Boolean Percentage { get; set; } 
        [Parameter] public Circulargram Model { get; set; }
        [Parameter] public EventCallback<Slice> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private TextLayout LayoutSliceValue;
        private TextLayout LayoutTotalValue;
        private TextLayout LayoutTextTitle;
        private TooltipLayout LayoutTooltip;

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
                                         .At(width / 2, height / 2);

            LayoutTextTitle = TextLayout.MiddleLayout()
                                        .Medium()
                                        .At(width / 2, padding / 5)
                                        .WithTheme(Theme);

            LayoutTooltip = TooltipLayout.Default();
        }

        private string SlicePath(Slice slice, double rotation = 0)
        {
            double radius_out = Math.Min(width, height) / 2 - padding;
            double radius_in = 2 * radius_out / 3;
            double theta = 2 * Math.PI * slice.Value / Model.Total;

            return $"M {(int)(width / 2 + radius_in * Math.Sin(rotation))} {(int)(height / 2 - radius_in * Math.Cos(rotation))}  " +
                   $"L {(int)(width / 2 + radius_out * Math.Sin(rotation))} {(int)(height / 2 - radius_out * Math.Cos(rotation))} " +
                   $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta / 2 + rotation))} {(int)(height / 2 - radius_out * Math.Cos(theta / 2 + rotation))} " +
                   $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta + rotation))} {(int)(height / 2 - radius_out * Math.Cos(theta + rotation))} " +
                   $"L {(int)(width / 2 + radius_in * Math.Sin(theta + rotation))} {(int)(height / 2 - radius_in * Math.Cos(theta + rotation))} " +
                   $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin(theta / 2 + rotation))} {(int)(height / 2 - radius_in * Math.Cos(theta / 2 + rotation))} " +
                   $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin(rotation))} {(int)(height / 2 - radius_in * Math.Cos(rotation))} " +
                   "Z";
        }

        private string RoundedSlicePath(Slice slice, double rotation = 0)
        {
            double radius_out = Math.Min(width, height) / 2 - padding;
            double radius_in = 2 * radius_out / 3;
            double theta = 2 * Math.PI * slice.Value / Model.Total;
            double roundness = 10;

            if (radius_in * theta > 2 * roundness)
            {
                return $"M {(int)(width / 2 + (radius_out - roundness) * Math.Sin(rotation))} {(int)(height / 2 - (radius_out - roundness) * Math.Cos(rotation))} " +
                       $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(rotation + roundness / radius_out))} {(int)(height / 2 - radius_out * Math.Cos(rotation + roundness / radius_out))} " +
                       $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta / 2 + rotation))} {(int)(height / 2 - radius_out * Math.Cos(theta / 2 + rotation))} " +
                       $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta + rotation - roundness / radius_out))} {(int)(height / 2 - radius_out * Math.Cos(theta + rotation - roundness / radius_out))} " +
                       $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + (radius_out - roundness) * Math.Sin(theta + rotation))} {(int)(height / 2 - (radius_out - roundness) * Math.Cos(theta + rotation))} " +
                       $"L {(int)(width / 2 + (radius_in + roundness) * Math.Sin(theta + rotation))} {(int)(height / 2 - (radius_in + roundness) * Math.Cos(theta + rotation))} " +
                       $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + radius_in * Math.Sin(theta + rotation - roundness / radius_in))} {(int)(height / 2 - radius_in * Math.Cos(theta + rotation - roundness / radius_in))} " +
                       $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin(theta / 2 + rotation))} {(int)(height / 2 - radius_in * Math.Cos(theta / 2 + rotation))} " +
                       $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin(rotation + roundness / radius_in))} {(int)(height / 2 - radius_in * Math.Cos(rotation + roundness / radius_in))} " +
                       $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + (radius_in + roundness) * Math.Sin(rotation))} {(int)(height / 2 - (radius_in + roundness) * Math.Cos(rotation))} " +
                       "Z";
            }
            else if (radius_out * theta > 2 * roundness)
            {
                double roundness_in = (radius_in - roundness) * theta / 2;
                double degree_rot = (rotation + theta / 2) / Math.PI * 180;
                return $"M {(int)(width / 2 + (radius_out - roundness) * Math.Sin(rotation))} {(int)(height / 2 - (radius_out - roundness) * Math.Cos(rotation))} " +
                       $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(rotation + roundness / radius_out))} {(int)(height / 2 - radius_out * Math.Cos(rotation + roundness / radius_out))} " +
                       $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta / 2 + rotation))} {(int)(height / 2 - radius_out * Math.Cos(theta / 2 + rotation))} " +
                       $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta + rotation - roundness / radius_out))} {(int)(height / 2 - radius_out * Math.Cos(theta + rotation - roundness / radius_out))} " +
                       $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + (radius_out - roundness) * Math.Sin(theta + rotation))} {(int)(height / 2 - (radius_out - roundness) * Math.Cos(theta + rotation))} " +
                       $"L {(int)(width / 2 + (radius_in + roundness) * Math.Sin(theta + rotation))} {(int)(height / 2 - (radius_in + roundness) * Math.Cos(theta + rotation))} " +
                       $"A {(int)roundness_in} {(int)roundness} {(int)degree_rot} 0 1 {(int)(width / 2 + (radius_in + roundness) * Math.Sin(rotation))} {(int)(height / 2 - (radius_in + roundness) * Math.Cos(rotation))} " +
                       "Z";
            }
            else
            {
                double roundness_in = (radius_in - roundness) * theta / 2;
                double roundness_out = (radius_out - roundness) * theta / 2;
                double degree_rot = (rotation + theta / 2) / Math.PI * 180;
                return $"M {(int)(width / 2 + (radius_out - roundness) * Math.Sin(rotation))} {(int)(height / 2 - (radius_out - roundness) * Math.Cos(rotation))} " +
                       $"A {(int)roundness_out} {(int)roundness} {(int)degree_rot} 0 1 {(int)(width / 2 + (radius_out - roundness) * Math.Sin(theta + rotation))} {(int)(height / 2 - (radius_out - roundness) * Math.Cos(theta + rotation))} " +
                       $"L {(int)(width / 2 + (radius_in + roundness) * Math.Sin(theta + rotation))} {(int)(height / 2 - (radius_in + roundness) * Math.Cos(theta + rotation))} " +
                       $"A {(int)roundness_in} {(int)roundness} {(int)degree_rot} 0 1 {(int)(width / 2 + (radius_in + roundness) * Math.Sin(rotation))} {(int)(height / 2 - (radius_in + roundness) * Math.Cos(rotation))} " +
                       "Z";
            }
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

        private void OnSliceEnter(Slice slice)
        {
            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = Theme.SeriesMarker,
                Color = slice.Color
            })
            .WithTitle(slice.Label)
            .WithLabel(Percentage ? (slice.Value / Model.Total).ToString("0.0#%") : slice.Value.ToString("0.##"))
            .Show();
        }
    }
}
