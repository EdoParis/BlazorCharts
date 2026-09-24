using Microsoft.AspNetCore.Components;
using BlazorGraphs.Core;

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

        protected override void OnParametersSet()
        {
            LayoutView.WithAspectRatio(AspectRatio);
            LayoutAxisX.WithTheme(Theme).From(LayoutView.Padding).To(LayoutView.Width - LayoutView.Padding);
            LayoutAxisY.WithTheme(Theme).From(LayoutView.Height - LayoutView.Padding).To(LayoutView.Padding).At(LayoutView.Padding);
            LayoutTitle.WithTheme(Theme);
            LayoutLabelsTop.WithTheme(Theme);
            LayoutLabelsBottom.WithTheme(Theme);
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
                                    .WithTheme(Theme)
                                    .From(LayoutView.Padding)
                                    .To(LayoutView.Width - LayoutView.Padding);

            LayoutTitle = TextLayout.StartLayout()
                                    .Medium()
                                    .WithTheme(Theme);

            LayoutLabelsTop = TextLayout.VerticalTopLayout().Medium().WithTheme(Theme);
            LayoutLabelsBottom = TextLayout.VerticalBottomLayout().Medium().WithTheme(Theme);
        }
    }
}
