using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class StepChart
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Double AspectRatio { get; set; } = AspectRatios.Square;
        [Parameter] public Boolean HidePoints { get; set; }
        [Parameter] public Cartesiangram Model { get; set; }
        [Parameter] public EventCallback<SerieEventArgs> OnSerieClick { get; set; }
        [Parameter] public EventCallback<PointEventArgs> OnPointClick { get; set; }
        private ViewLayout LayoutView;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitleX;
        private TextLayout LayoutTitleY;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            LayoutView.WithAspectRatio(AspectRatio);
            LayoutAxisX.WithTheme(Theme).From(LayoutView.Padding).To(LayoutView.Width - LayoutView.Padding).At(LayoutView.Height - LayoutView.Padding);
            LayoutAxisY.WithTheme(Theme).From(LayoutView.Height - LayoutView.Padding).To(LayoutView.Padding).At(LayoutView.Padding);
            LayoutTitleX.WithTheme(Theme).At(LayoutView.Width / 2, LayoutView.Height - LayoutView.Padding / 4);
            LayoutTitleY.WithTheme(Theme).At(LayoutView.Padding / 2, LayoutView.Padding / 2);
        }

        protected override void OnInitialized()
        {
            LayoutView = ViewLayout.Default();
            LayoutTooltip = TooltipLayout.Default();
            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(LayoutView.Padding)
                                    .To(LayoutView.Width - LayoutView.Padding)
                                    .At(LayoutView.Height - LayoutView.Padding);

            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(LayoutView.Height - LayoutView.Padding)
                                    .To(LayoutView.Padding)
                                    .At(LayoutView.Padding);

            LayoutTitleX = TextLayout.MiddleLayout()
                                     .WithTheme(Theme)
                                     .Medium()
                                     .At(LayoutView.Width / 2, LayoutView.Height - LayoutView.Padding / 4);

            LayoutTitleY = TextLayout.StartLayout()
                                     .WithTheme(Theme)
                                     .Medium()
                                     .At(LayoutView.Padding / 2, LayoutView.Padding / 2);
        }

        private string LinePath(Serie<Datapoint> serie)
        {
            PathBuilder builder = PathBuilder.CreateBuilder();
            Point? previous_point = null;

            foreach (Datapoint point in serie.Data)
            {
                Point p = new Point()
                {
                    X = LayoutAxisX.StartingPoint.X + (int)((point.X - Model.AxisX.Min) * LayoutAxisX.Amplitude / Model.AxisX.Size),
                    Y = LayoutAxisY.StartingPoint.Y + (int)((point.Y - Model.AxisY.Min) * LayoutAxisY.Amplitude / Model.AxisY.Size)
                };

                if (previous_point.HasValue)
                {
                    if (point.Y == previous_point.Value.Y)
                        builder.Horizontal(p.X);
                    else
                    {
                        builder.Horizontal((p.X + previous_point.Value.X) / 2)
                               .Vertical(p.Y)
                               .Horizontal(p.X);
                    }
                }
                else
                {
                    builder.MoveTo(p.X, p.Y);
                }
                previous_point = p;
            }
            return builder.Build();
        }

        private string RoundedLinePath(Serie<Datapoint> serie)
        {
            PathBuilder builder = PathBuilder.CreateBuilder();
            Point? previous_point = null;

            foreach (Datapoint point in serie.Data)
            {
                Point p = new Point()
                {
                    X = LayoutView.Padding + (int)((point.X - Model.AxisX.Min) * LayoutView.InternalWidth / Model.AxisX.Size),
                    Y = LayoutView.Height - LayoutView.Padding - (int)((point.Y - Model.AxisY.Min) * LayoutView.InternalHeight / Model.AxisY.Size)
                };

                if (previous_point.HasValue)
                {
                    if (point.Y == previous_point.Value.Y)
                        builder.Horizontal(p.X);
                    else
                    {
                        int ry = Math.Sign(p.Y - previous_point.Value.Y) * Math.Min(Math.Abs(p.Y - previous_point.Value.Y) / 2, 10);
                        int rx = Math.Sign(p.X - previous_point.Value.X) * Math.Min(Math.Abs(p.X - previous_point.Value.X) / 2, 10);

                        if (rx * ry > 0)
                        {
                            builder.Horizontal((p.X + previous_point.Value.X) / 2 - rx)
                                   .SmallRelativeArcClockwise(Math.Abs(rx), Math.Abs(ry), rx, ry)
                                   .Vertical(p.Y - ry)
                                   .SmallRelativeArcCounterclockwise(Math.Abs(rx), Math.Abs(ry), rx, ry)
                                   .LineTo(p.X, p.Y);
                        }
                        else
                        {
                            builder.Horizontal((p.X + previous_point.Value.X) / 2 - rx)
                                   .SmallRelativeArcCounterclockwise(Math.Abs(rx), Math.Abs(ry), rx, ry)
                                   .Vertical(p.Y - ry)
                                   .SmallRelativeArcClockwise(Math.Abs(rx), Math.Abs(ry), rx, ry)
                                   .LineTo(p.X, p.Y);
                        }
                    }
                }
                else
                {
                    builder.MoveTo(p.X, p.Y);
                }
                previous_point = p;
            }
            return builder.Build();
        }

        private void OnPointEnter(Datapoint point, Color color)
        {
            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = (SeriesMarker)Theme.Markers.Data,
                Color = color
            })
            .WithLabel($"{point.X.ToString("0.##")} | {point.Y.ToString("0.##")}")
            .Show();
        }

        private void OnSerieEnter(Serie<Datapoint> serie)
        {
            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = Theme.Markers.Series,
                Color = serie.Color
            })
            .WithLabel(serie.Label)
            .Show();
        }
    }
}
