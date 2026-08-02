using Microsoft.AspNetCore.Components;
using BlazorGraphs.Core;

namespace BlazorGraphs.Components
{
    public partial class VerticalBarChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Bargram Model { get; set; }
        [Parameter] public EventCallback<Bar> OnClick {get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private int originH => Model is null ? offsetH : offsetH - (int)(Model.BinAxis.Min * scaleH);
        private int originV => Model is null ? offsetV : offsetV + (int)(Model.ValAxis.Min * scaleV);
        private double scaleH => (width - 2 * padding) / Model.BinAxis.Size;
        private double scaleV => (height - 2 * padding) / Model.ValAxis.Size;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitle;
        private TextLayout LayoutLabelsTop;
        private TextLayout LayoutLabelsBottom;

        protected override void OnParametersSet()
        {
            LayoutAxisX.WithTheme(Theme);
            LayoutAxisY.WithTheme(Theme);
            LayoutTitle.WithTheme(Theme);
            LayoutLabelsTop.WithTheme(Theme);
            LayoutLabelsBottom.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(height - padding)
                                    .To(padding)
                                    .At(padding);

            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .WithTheme(Theme)
                                    .From(padding)
                                    .To(width - padding);

            LayoutTitle = TextLayout.StartLayout()
                                    .Medium()
                                    .WithTheme(Theme);

            LayoutLabelsTop = TextLayout.VerticalTopLayout().Medium();
            LayoutLabelsBottom = TextLayout.VerticalBottomLayout().Medium();
        }
    }
}
