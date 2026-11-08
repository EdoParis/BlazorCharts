using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class SemiCircleGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW / 2 + PADDING;
        private int radius = VIEW / 2 - 2 * PADDING;
        private int padding = PADDING;
        private AxisLayout AxisLayout;
        private TextLayout ValueLayout;
        private TextLayout TitleLayout;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            AxisLayout.WithTheme(Theme);
            TitleLayout.WithTheme(Theme);
            ValueLayout.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            AxisLayout = AxisLayout.CircularLayout()
                                   .WithRadius(radius + padding / 2)
                                   .At(new Point(width / 2, height - padding))
                                   .From(0)
                                   .To(180)
                                   .WithTickSize(20)
                                   .WithTheme(Theme)
                                   .FullExternal();

            ValueLayout = TextLayout.TopLayout()
                                    .WithTheme(Theme)
                                    .Large()
                                    .At(width / 2, height - padding / 2);

            TitleLayout = TextLayout.MiddleLayout()
                                    .WithTheme(Theme)
                                    .Medium()
                                    .At(width / 2, height - padding / 2);

            LayoutTooltip = TooltipLayout.Default();
        }

        private string ArcPath(double start, double end)
        {
            int startpoint_x = (int)Math.Round(width / 2 - radius * Math.Cos(start));
            int startpoint_y = (int)Math.Round(height - padding - radius * Math.Sin(start));
            int middlepoint_x = (int)Math.Round(width / 2 - radius * Math.Cos((start + end) / 2));
            int middlepoint_y = (int)Math.Round(height - padding - radius * Math.Sin((start + end ) / 2));
            int endpoint_x = (int)Math.Round(width / 2 - radius * Math.Cos(end));
            int endpoint_y = (int)Math.Round(height - padding - radius * Math.Sin(end));

            return $"M {startpoint_x} {startpoint_y} " +
                   $"A {radius} {radius} 0 0 1 {middlepoint_x} {middlepoint_y} " +
                   $"A {radius} {radius} 0 0 1 {endpoint_x} {endpoint_y}";
        }

        private string RoundedGaugePath(double start, double end)
        {
            double radius_out = radius + padding / 2;
            double radius_in = radius - padding / 2;
            double theta = end - start;
            double roundness = 10;

            return $"M {(int)(width / 2 + (radius_out - roundness) * Math.Sin(start))} {(int)(height - padding - (radius_out - roundness) * Math.Cos(start))} " +
                    $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(start + roundness / radius_out))} {(int)(height - padding - radius_out * Math.Cos(start + roundness / radius_out))} " +
                    $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta / 2 + start))} {(int)(height - padding - radius_out * Math.Cos(theta / 2 + start))} " +
                    $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(end - roundness / radius_out))} {(int)(height - padding - radius_out * Math.Cos(end - roundness / radius_out))} " +
                    $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + (radius_out - roundness) * Math.Sin(end))} {(int)(height - padding - (radius_out - roundness) * Math.Cos(end))} " +
                    $"L {(int)(width / 2 + (radius_in + roundness) * Math.Sin(end))} {(int)(height - padding - (radius_in + roundness) * Math.Cos(end))} " +
                    $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + radius_in * Math.Sin(end - roundness / radius_in))} {(int)(height - padding - radius_in * Math.Cos(end - roundness / radius_in))} " +
                    $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin((start + end) / 2))} {(int)(height - padding - radius_in * Math.Cos((start + end) / 2))} " +
                    $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin(start + roundness / radius_in))} {(int)(height - padding - radius_in * Math.Cos(start + roundness / radius_in))} " +
                    $"A {(int)roundness} {(int)roundness} 0 0 1 {(int)(width / 2 + (radius_in + roundness) * Math.Sin(start))} {(int)(height - padding - (radius_in + roundness) * Math.Cos(start))} " +
                    "Z";
        }

        private string GaugePath(double start, double end)
        {
            double radius_out = radius + padding / 2;
            double radius_in = radius - padding / 2;
            double theta = end - start;

            return $"M {(int)(width / 2 + radius_out * Math.Sin(start))} {(int)(height - padding - radius_out * Math.Cos(start))} " +
                    $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(theta / 2 + start))} {(int)(height - padding - radius_out * Math.Cos(theta / 2 + start))} " +
                    $"A {(int)radius_out} {(int)radius_out} 0 0 1 {(int)(width / 2 + radius_out * Math.Sin(end))} {(int)(height - padding - radius_out * Math.Cos(end))} " +
                    $"L {(int)(width / 2 + radius_in * Math.Sin(end))} {(int)(height - padding - radius_in * Math.Cos(end))} " +
                    $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin((start + end) / 2))} {(int)(height - padding - radius_in * Math.Cos((start + end) / 2))} " +
                    $"A {(int)radius_in} {(int)radius_in} 0 0 0 {(int)(width / 2 + radius_in * Math.Sin(start))} {(int)(height - padding - radius_in * Math.Cos(start))} " +
                    "Z";
        }

        private void OnGaugeEnter()
        {
            LayoutTooltip.WithoutMarker()
                         .WithoutTitle()
                         .WithLabel(Model.Value.ToString("0.0#"))
                         .Show();
        }

        private void OnBreakpointEnter(Breakpoint breakpoint)
        {
            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = Theme.SeriesMarker,
                Color = breakpoint.Color
            })
            .WithoutTitle()
            .WithLabel(string.IsNullOrWhiteSpace(breakpoint.Label) ? $"< {breakpoint.Value.ToString("0.##")}" : breakpoint.Label)
            .Show();
        }
    }
}
