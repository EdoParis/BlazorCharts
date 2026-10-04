using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;
using System.Text;

namespace BlazorGraphs.Components
{
    public partial class StepChart
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Double AspectRatio { get; set; } = AspectRatios.Square;
        [Parameter] public Boolean HidePoints { get; set; }
        [Parameter] public Cartesiangram Model { get; set; }
        private ViewLayout LayoutView;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitleX;
        private TextLayout LayoutTitleY;
        private TooltipLayout LayoutTooltipPoint;
        private TooltipLayout LayoutTooltipSerie;

        protected override void OnParametersSet()
        {
            LayoutView.WithAspectRatio(AspectRatio);
            LayoutAxisX.WithTheme(Theme).From(LayoutView.Padding).To(LayoutView.Width - LayoutView.Padding).At(LayoutView.Height - LayoutView.Padding);
            LayoutAxisY.WithTheme(Theme).From(LayoutView.Height - LayoutView.Padding).To(LayoutView.Padding).At(LayoutView.Padding);
            LayoutTitleX.WithTheme(Theme).At(LayoutView.Width / 2, LayoutView.Height - LayoutView.Padding / 4);
            LayoutTitleY.WithTheme(Theme).At(LayoutView.Padding / 2, LayoutView.Padding / 2);
            LayoutTooltipPoint.WithTheme(Theme);
            LayoutTooltipSerie.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutView = ViewLayout.Default();
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

            LayoutTooltipPoint = TooltipLayout.Default()
                                              .WithMarker(MarkerLayout.CircleLayout());

            LayoutTooltipSerie = TooltipLayout.Default()
                                              .WithMarker(MarkerLayout.SegmentLayout());
        }

        private string LinePath(Serie<Datapoint> serie)
        {
            StringBuilder builder = new StringBuilder();
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
                        builder.Append($"L {p.X} {p.Y} ");
                    else
                    {
                        builder.Append($"L {(p.X + previous_point.Value.X) / 2} {previous_point.Value.Y} ");
                        builder.Append($"L {(p.X + previous_point.Value.X) / 2} {p.Y} ");
                        builder.Append($"L {p.X} {p.Y} ");
                    }
                }
                else
                {
                    builder.Append($"M {p.X} {p.Y} ");
                }
                previous_point = p;
            }
            return builder.ToString();
        }

        private void OnMouseHandler(MouseEventArgs e)
        {
            if (e is null)
                return;

            LayoutTooltipPoint.At(new Point()
            {
                X = (int)e.OffsetX + 10,
                Y = (int)e.OffsetY + 10
            });

            LayoutTooltipSerie.At(new Point()
            {
                X = (int)e.OffsetX + 10,
                Y = (int)e.OffsetY + 10
            });
        }

        private void OnPointEnter(Datapoint point, Color color)
        {
            LayoutTooltipSerie.Hide();
            LayoutTooltipPoint.Show()
                              .WithLabel($"{point.X.ToString("0.##")} | {point.Y.ToString("0.##")}")
                              .Marker.WithColor(color);
        }

        private void OnSerieEnter(Serie<Datapoint> serie)
        {
            LayoutTooltipPoint.Hide();
            LayoutTooltipSerie.Show()
                              .WithLabel(serie.Label)
                              .Marker.WithColor(serie.Color);
        }

        private void OnPointLeave()
        {
            LayoutTooltipPoint.Hide();
            LayoutTooltipSerie.Hide();
        }

        private void OnSerieLeave()
        {
            LayoutTooltipPoint.Hide();
            LayoutTooltipSerie.Hide();
        }

        private void OnSvgLeave()
        {
            LayoutTooltipPoint.Hide();
            LayoutTooltipSerie.Hide();
        }
    }
}
