using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class Speedometer
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Boolean InnerAxis { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int radius = VIEW / 2 - 2 * PADDING;
        private int padding = PADDING;
        private AxisLayout AxisInternalLayout;
        private AxisLayout AxisExternalLayout;
        private TextLayout ValueLayout;
        private TextLayout TitleLayout;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            AxisExternalLayout.WithTheme(Theme);
            AxisInternalLayout.WithTheme(Theme);
            ValueLayout.WithTheme(Theme);
            TitleLayout.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            AxisExternalLayout = AxisLayout.CircularLayout()
                                           .WithRadius(radius + padding / 2)
                                           .At(new Point(width / 2, height / 2))
                                           .WithTickSize(20)
                                           .WithTheme(Theme)
                                           .FullExternal()
                                           .From(-45)
                                           .To(225);

            AxisInternalLayout = AxisLayout.CircularLayout()
                                           .WithRadius(radius - padding / 2)
                                           .At(new Point(width / 2, height / 2))
                                           .WithTickSize(20)
                                           .WithTheme(Theme)
                                           .FullInternal()
                                           .From(-45)
                                           .To(225);

            ValueLayout = TextLayout.TopLayout()
                                    .Large()
                                    .WithTheme(Theme)
                                    .At(width / 2, height / 2 + radius + padding / 2);

            TitleLayout = TextLayout.MiddleLayout()
                                    .Medium()
                                    .WithTheme(Theme)
                                    .At(width / 2, height / 2 + radius + padding / 2);

            LayoutTooltip = TooltipLayout.Default();
        }

        private string ArcPath(double start, double end)
        {
            int startpoint_x = (int)Math.Round(width / 2 - radius * Math.Cos(start));
            int startpoint_y = (int)Math.Round(height / 2 - radius * Math.Sin(start));
            int middlepoint_x = (int)Math.Round(width / 2 - radius * Math.Cos((start + end) / 2));
            int middlepoint_y = (int)Math.Round(height / 2 - radius * Math.Sin((start + end) / 2));
            int endpoint_x = (int)Math.Round(width / 2 - radius * Math.Cos(end));
            int endpoint_y = (int)Math.Round(height / 2 - radius * Math.Sin(end));

            return PathBuilder.CreateBuilder()
                              .MoveTo(startpoint_x, startpoint_y)
                              .SmallArcClockwise(radius, middlepoint_x, middlepoint_y)
                              .SmallArcClockwise(radius, endpoint_x, endpoint_y)
                              .Build();
        }

        private string RoundedGaugePath(double start, double end)
        {
            double radius_out = radius + padding / 2;
            double radius_in = radius - padding / 2;
            double middle = (start + end) / 2;
            double roundness = 10;

            return PathBuilder.CreateBuilder()
                              .MoveTo(width / 2 + (radius_out - roundness) * Math.Sin(start), height / 2 - (radius_out - roundness) * Math.Cos(start))
                              .SmallArcClockwise(roundness, width / 2 + radius_out * Math.Sin(start + roundness / radius_out), height / 2 - radius_out * Math.Cos(start + roundness / radius_out))
                              .SmallArcClockwise(radius_out, width / 2 + radius_out * Math.Sin(middle), height / 2 - radius_out * Math.Cos(middle))
                              .SmallArcClockwise(radius_out, width / 2 + radius_out * Math.Sin(end - roundness / radius_out), height / 2 - radius_out * Math.Cos(end - roundness / radius_out))
                              .SmallArcClockwise(roundness, width / 2 + (radius_out - roundness) * Math.Sin(end), height / 2 - (radius_out - roundness) * Math.Cos(end))
                              .LineTo(width / 2 + (radius_in + roundness) * Math.Sin(end), height / 2 - (radius_in + roundness) * Math.Cos(end))
                              .SmallArcClockwise(roundness, width / 2 + radius_in * Math.Sin(end - roundness / radius_in), height / 2 - radius_in * Math.Cos(end - roundness / radius_in))
                              .SmallArcCounterclockwise(radius_in, width / 2 + radius_in * Math.Sin(middle), height / 2 - radius_in * Math.Cos(middle))
                              .SmallArcCounterclockwise(radius_in, width / 2 + radius_in * Math.Sin(start + roundness / radius_in), height / 2 - radius_in * Math.Cos(start + roundness / radius_in))
                              .SmallArcClockwise(roundness, width / 2 + (radius_in + roundness) * Math.Sin(start), height / 2 - (radius_in + roundness) * Math.Cos(start))
                              .Close()
                              .Build();
        }

        private string GaugePath(double start, double end)
        {
            double radius_out = radius + padding / 2;
            double radius_in = radius - padding / 2;
            double middle = (start + end) / 2;

            return PathBuilder.CreateBuilder()
                              .MoveTo(width / 2 + radius_out * Math.Sin(start), height / 2 - radius_out * Math.Cos(start))
                              .SmallArcClockwise(radius_out, width / 2 + radius_out * Math.Sin(middle), height / 2 - radius_out * Math.Cos(middle))
                              .SmallArcClockwise(radius_out, width / 2 + radius_out * Math.Sin(end), height / 2 - radius_out * Math.Cos(end))
                              .LineTo(width / 2 + radius_in * Math.Sin(end), height / 2 - radius_in * Math.Cos(end))
                              .SmallArcCounterclockwise(radius_in, width / 2 + radius_in * Math.Sin(middle), height / 2 - radius_in * Math.Cos(middle))
                              .SmallArcCounterclockwise(radius_in, width / 2 + radius_in * Math.Sin(start), height / 2 - radius_in * Math.Cos(start))
                              .Close()
                              .Build();
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
                Symbol = Theme.Markers.Series,
                Color = breakpoint.Color
            })
            .WithoutTitle()
            .WithLabel(string.IsNullOrWhiteSpace(breakpoint.Label) ? $"< {breakpoint.Value.ToString("0.##")}" : breakpoint.Label)
            .Show();
        }
    }
}
