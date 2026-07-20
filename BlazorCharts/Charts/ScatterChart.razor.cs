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
        [Parameter] public Linegram Model { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.AxisX.Size;
        private double scaleV => (height - 2 * padding) / Model.AxisY.Size;
        private AxisLayout LayoutAxisY;
        private AxisLayout LayoutAxisX;

        protected override void OnInitialized()
        {
            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .From(padding)
                                    .To(width - padding)
                                    .At(height - padding);

            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .From(height - padding)
                                    .To(padding)
                                    .At(padding);
        }
    }
}
