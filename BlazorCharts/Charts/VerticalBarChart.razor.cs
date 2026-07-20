using BlazorGraphs.Models;
using BlazorGraphs.Internal;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
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

        protected override void OnInitialized()
        {
            LayoutAxisY = AxisLayout.VerticalLayout()
                                    .TicksInternal()
                                    .WithTickSize(20)
                                    .From(height - padding)
                                    .To(padding)
                                    .At(padding);

            LayoutAxisX = AxisLayout.HorizontalLayout()
                                    .From(padding)
                                    .To(width - padding);
        }
    }
}
