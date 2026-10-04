using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class VerticalBarChart
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Double AspectRatio { get; set; } = AspectRatios.Square;
        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private ViewLayout LayoutView;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitle;
        private TextLayout LayoutLabelsTop;
        private TextLayout LayoutLabelsBottom;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            LayoutView.WithAspectRatio(AspectRatio);
            LayoutAxisX.WithTheme(Theme).From(LayoutView.Padding).To(LayoutView.Width - LayoutView.Padding);
            LayoutAxisY.WithTheme(Theme).From(LayoutView.Height - LayoutView.Padding).To(LayoutView.Padding).At(LayoutView.Padding);
            LayoutTitle.WithTheme(Theme);
            LayoutTooltip.WithTheme(Theme);
            LayoutLabelsTop.WithTheme(Theme);
            LayoutLabelsBottom.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutView = ViewLayout.Default();
            LayoutTooltip = TooltipLayout.Default()
                                         .WithMarker(MarkerLayout.SquareLayout());

            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(LayoutView.Height - LayoutView.Padding)
                                    .To(LayoutView.Padding)
                                    .At(LayoutView.Padding);

            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .WithTheme(Theme)
                                    .From(LayoutView.Padding)
                                    .To(LayoutView.Width - LayoutView.Padding);

            LayoutTitle = TextLayout.StartLayout()
                                    .Medium()
                                    .WithTheme(Theme);

            LayoutLabelsTop = TextLayout.VerticalTopLayout().Medium().WithTheme(Theme);
            LayoutLabelsBottom = TextLayout.VerticalBottomLayout().Medium().WithTheme(Theme);
        }

        private void OnMouseHandler(MouseEventArgs e)
        {
            if (e is null)
                return;

            LayoutTooltip.At(new Point()
            {
                X = (int)e.OffsetX + 10,
                Y = (int)e.OffsetY + 10
            });
        }

        private void OnBarEnter(Bar bar)
        {
            LayoutTooltip.Show()
                         .WithTitle(bar.Label)
                         .WithLabel(bar.Value.ToString("0.0#"))
                         .Marker.WithColor(bar.Value < 0 ? Model.SecondaryColor : Model.PrimaryColor);
        }

        private void OnBarLeave()
        {
            LayoutTooltip.Hide();
        }

        private void OnSvgLeave()
        {
            LayoutTooltip.Hide();
        }
    }
}
