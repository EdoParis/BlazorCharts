using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class PieChart
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
        private TextLayout LayoutTextSlice;
        private TextLayout LayoutTextTitle;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            LayoutTextSlice.WithTheme(Theme);
            LayoutTextTitle.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutTextSlice = TextLayout.MiddleLayout()
                                        .Medium()
                                        .WithTheme(Theme);

            LayoutTextTitle = TextLayout.MiddleLayout()
                                        .Medium()
                                        .At(width / 2, padding / 5)
                                        .WithTheme(Theme);

            LayoutTooltip = TooltipLayout.Default();
        }

        private string SlicePath(Slice slice, double rotation = 0)
        {
            double radius = (Math.Min(width, height) - 2 * padding) / 2;
            double theta = 2 * Math.PI * slice.Value / Model.Total;

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
            double theta = 2 * Math.PI * slice.Value / Model.Total;
            double radius = (Math.Min(width, height) - 2 * padding) / 2;
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

        private Point SliceMidPoint(Slice slice, double rotation = 0)
        {
            double radius = (Math.Min(width, height) - 2 * padding) / 4;
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
                Symbol = Theme.Markers.Series,
                Color = slice.Color
            })
            .WithTitle(slice.Label)
            .WithLabel(Percentage ? (slice.Value / Model.Total).ToString("0.0#%") : slice.Value.ToString("0.##"))
            .Show();
        }
    }
}
