using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Components
{
    public partial class PolarAreaChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Circulargram Model { get; set; }
        [Parameter] public EventCallback<Slice> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private TextLayout LayoutTitle;
        private TextLayout LayoutTicks;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            LayoutTitle.WithTheme(Theme);
            LayoutTicks.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutTitle = TextLayout.MiddleLayout()
                                    .Medium()
                                    .WithTheme(Theme)
                                    .At(width / 2, height - padding / 2);

            LayoutTicks = TextLayout.TopLayout()
                                    .WithTheme(Theme)
                                    .Medium();

            LayoutTooltip = TooltipLayout.Default();
        }

        private string SlicePath(Slice slice, double rotation = 0)
        {
            double radius = slice.Value / Model.AxisR.Size * (Math.Min(width, height) - 2 * padding) / 2;
            double theta = 2 * Math.PI / Model.SlicesCount;

            return PathBuilder.CreateBuilder()
                              .MoveTo(width / 2, height / 2)
                              .LineTo(width / 2 + radius * Math.Sin(rotation), height / 2 - radius * Math.Cos(rotation))
                              .SmallArcClockwise(radius, width / 2 + radius * Math.Sin(theta / 2 + rotation), height / 2 - radius * Math.Cos(theta / 2 + rotation))
                              .SmallArcClockwise(radius, width / 2 + radius * Math.Sin(theta + rotation), height / 2 - radius * Math.Cos(theta + rotation))
                              .Close()
                              .Build();
        }

        private string RoundedSlicePath(Slice slice, double rotation = 0)
        {
            double theta = 2 * Math.PI / Model.SlicesCount;
            double radius = slice.Value / Model.AxisR.Size * (Math.Min(width, height) - 2 * padding) / 2;
            double roundness = 10;

            if (radius * theta > 2 * roundness)
            {
                return PathBuilder.CreateBuilder()
                                  .MoveTo(width / 2, height / 2)
                                  .LineTo(width / 2 + (radius - roundness) * Math.Sin(rotation), height / 2 - (radius - roundness) * Math.Cos(rotation))
                                  .SmallArcClockwise(roundness, width / 2 + radius * Math.Sin(rotation + roundness / radius), height / 2 - radius * Math.Cos(rotation + roundness / radius))
                                  .SmallArcClockwise(radius, width / 2 + radius * Math.Sin(theta / 2 + rotation), height / 2 - radius * Math.Cos(theta / 2 + rotation))
                                  .SmallArcClockwise(radius, width / 2 + radius * Math.Sin(theta + rotation - roundness / radius), height / 2 - radius * Math.Cos(theta + rotation - roundness / radius))
                                  .SmallArcClockwise(roundness, width / 2 + (radius - roundness) * Math.Sin(theta + rotation), height / 2 - (radius - roundness) * Math.Cos(theta + rotation))
                                  .Close()
                                  .Build();
            }
            else
            {
                double roundness2 = (radius - roundness) * theta / 2;
                double degree_rot = (rotation + theta / 2) / Math.PI * 180;
                return PathBuilder.CreateBuilder()
                                  .MoveTo(width / 2, height / 2)
                                  .LineTo(width / 2 + (radius - roundness) * Math.Sin(rotation), height / 2 - (radius - roundness) * Math.Cos(rotation))
                                  .SmallArcClockwise(roundness2, roundness, width / 2 + (radius - roundness) * Math.Sin(theta + rotation), height / 2 - (radius - roundness) * Math.Cos(theta + rotation), degree_rot)
                                  .Close()
                                  .Build();
            }
        }

        private void OnSliceEnter(Slice slice)
        {
            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = Theme.Markers.Series,
                Color = slice.Color
            })
            .WithTitle(slice.Label)
            .WithLabel(slice.Value.ToString("0.##"))
            .Show();
        }
    }
}
