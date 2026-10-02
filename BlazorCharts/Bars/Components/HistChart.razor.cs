using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class HistChart
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Double AspectRatio { get; set; } = AspectRatios.Square;
        [Parameter] public Histogram Model { get; set; }
        [Parameter] public EventCallback<Bin> OnClick { get; set; }
        private ViewLayout LayoutView;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitleY;
        private TextLayout LayoutTitleX;
        private Point TooltipPosition;
        private Bin? SelectedBin;

        protected override void OnParametersSet()
        {
            LayoutView.WithAspectRatio(AspectRatio);
            LayoutAxisX.WithTheme(Theme).From(LayoutView.Padding).To(LayoutView.Width - LayoutView.Padding);
            LayoutAxisY.WithTheme(Theme).From(LayoutView.Height - LayoutView.Padding).To(LayoutView.Padding).At(LayoutView.Padding);
            LayoutTitleX.WithTheme(Theme);
            LayoutTitleY.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutView = ViewLayout.Default();
            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(LayoutView.Height - LayoutView.Padding)
                                    .To(LayoutView.Padding)
                                    .At(LayoutView.Padding);

            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(LayoutView.Padding)
                                    .To(LayoutView.Width - LayoutView.Padding);

            LayoutTitleX = TextLayout.MiddleLayout()
                                     .Medium()
                                     .WithTheme(Theme);

            LayoutTitleY = TextLayout.StartLayout()
                                     .Medium()
                                     .WithTheme(Theme)
                                     .At(LayoutView.Padding / 2, LayoutView.Padding / 2);
        }

        private void OnMouseHover(MouseEventArgs e)
        {
            if (e is null)
                return;

            TooltipPosition = new Point()
            {
                X = (int)e.OffsetX + 10,
                Y = (int)e.OffsetY + 10
            };
        }
    }
}
