using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class HorizontalBarChart
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Double AspectRatio { get; set; } = AspectRatios.Square;
        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private ViewLayout LayoutView;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitle;
        private TextLayout LayoutLabelsStart;
        private TextLayout LayoutLabelsEnd;
        private Point TooltipPosition;
        private Bar? SelectedBar;

        protected override void OnParametersSet()
        {
            LayoutView.WithAspectRatio(AspectRatio);
            LayoutAxisY.WithTheme(Theme).From(LayoutView.Height - LayoutView.Padding).To(LayoutView.Padding);
            LayoutAxisX.WithTheme(Theme).From(LayoutView.Padding).To(LayoutView.Width - LayoutView.Padding).At(LayoutView.Height - LayoutView.Padding); ;
            LayoutTitle.WithTheme(Theme).At(LayoutView.Width / 2, LayoutView.Height - LayoutView.Padding / 4);
        }

        protected override void OnInitialized()
        {
            LayoutView = ViewLayout.Default();
            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .WithTheme(Theme)
                                    .From(LayoutView.Height - LayoutView.Padding)
                                    .To(LayoutView.Padding);

            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(LayoutView.Padding)
                                    .To(LayoutView.Width - LayoutView.Padding)
                                    .At(LayoutView.Height - LayoutView.Padding);

            LayoutTitle = TextLayout.MiddleLayout()
                                    .Medium()
                                    .WithTheme(Theme)
                                    .At(LayoutView.Width / 2, LayoutView.Height - LayoutView.Padding / 4);

            LayoutLabelsEnd = TextLayout.EndLayout()
                                        .WithTheme(Theme)
                                        .Medium();

            LayoutLabelsStart = TextLayout.StartLayout()
                                          .WithTheme(Theme)
                                          .Medium();
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
