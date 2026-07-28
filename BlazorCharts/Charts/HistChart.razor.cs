using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
{
    public partial class HistChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Histogram Model { get; set; }
        [Parameter] public EventCallback<Bin> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private int originH => Model is null ? offsetH : offsetH - (int)(Model.AxisX.Min * scaleH);
        private int originV => Model is null ? offsetV : offsetV + (int)(Model.AxisY.Min * scaleV);
        private double scaleH => (width - 2 * padding) / Model.AxisX.Size;
        private double scaleV => (height - 2 * padding) / Model.AxisY.Size;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitleY;
        private TextLayout LayoutTitleX;

        protected override void OnParametersSet()
        {
            LayoutAxisX.WithTheme(Theme);
            LayoutAxisY.WithTheme(Theme);
            LayoutTitleX.WithTheme(Theme);
            LayoutTitleY.WithTheme(Theme);
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
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(padding)
                                    .To(width - padding);

            LayoutTitleX = TextLayout.MiddleLayout()
                                     .Medium()
                                     .WithTheme(Theme);

            LayoutTitleY = TextLayout.StartLayout()
                                     .Medium()
                                     .WithTheme(Theme)
                                     .At(padding / 2, padding / 2);
        }
    }
}
