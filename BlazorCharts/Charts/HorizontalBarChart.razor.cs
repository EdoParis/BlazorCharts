using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
{
    public partial class HorizontalBarChart
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
        private int originH => Model is null ? offsetH : offsetH - (int)(Model.ValAxis.Min * scaleH);
        private int originV => Model is null ? offsetV : offsetV + (int)(Model.BinAxis.Min * scaleV);
        private double scaleH => (width - 2 * padding) / Model.ValAxis.Size;
        private double scaleV => (height - 2 * padding) / Model.BinAxis.Size;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitle;
        private TextLayout LayoutLabelsStart;
        private TextLayout LayoutLabelsEnd;

        protected override void OnParametersSet()
        {
            LayoutAxisX.WithTheme(Theme);
            LayoutAxisY.WithTheme(Theme);
            LayoutTitle.WithTheme(Theme);
            LayoutLabelsStart.WithTheme(Theme);
            LayoutLabelsEnd.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(padding)
                                    .To(width - padding)
                                    .At(height - padding);

            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .WithTheme(Theme)
                                    .From(height - padding)
                                    .To(padding);

            LayoutTitle = TextLayout.MiddleLayout()
                                    .Medium()
                                    .WithTheme(Theme)
                                    .At(width / 2, height - padding / 4);

            LayoutLabelsEnd = TextLayout.EndLayout()
                                        .WithTheme(Theme)
                                        .Medium();

            LayoutLabelsStart = TextLayout.StartLayout()
                                          .WithTheme(Theme)
                                          .Medium();
        }
    }
}
