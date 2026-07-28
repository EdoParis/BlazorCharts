using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
{
    public partial class ScatterChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Cartesiangram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.AxisX.Size;
        private double scaleV => (height - 2 * padding) / Model.AxisY.Size;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;
        private TextLayout LayoutTitleX;
        private TextLayout LayoutTitleY;

        protected override void OnParametersSet()
        {
            LayoutAxisX.WithTheme(Theme);
            LayoutAxisY.WithTheme(Theme);
            LayoutTitleX.WithTheme(Theme);
            LayoutTitleY.WithTheme(Theme);
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
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .WithTheme(Theme)
                                    .From(height - padding)
                                    .To(padding)
                                    .At(padding);

            LayoutTitleX = TextLayout.MiddleLayout()
                                     .WithTheme(Theme)
                                     .Medium()
                                     .At(width / 2, height - padding / 4);

            LayoutTitleY = TextLayout.StartLayout()
                                     .WithTheme(Theme)
                                     .Medium()
                                     .At(padding / 2, padding / 2);
        }
    }
}
