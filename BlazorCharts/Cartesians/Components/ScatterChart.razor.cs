using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class ScatterChart
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Double AspectRatio { get; set; } = AspectRatios.Square;
        [Parameter] public Cartesiangram Model { get; set; }
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
            LayoutTooltip.WithTheme(Theme);
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

            LayoutTooltip = TooltipLayout.Default()
                                         .WithMarker(MarkerLayout.CircleLayout());
        }

        private void OnPointEnter(Datapoint point, Color color)
        {
            LayoutTooltip.Show()
                         .WithLabel($"{point.X.ToString("0.##")} | {point.Y.ToString("0.##")}")
                         .Marker.WithColor(color);
        }
    }
}
