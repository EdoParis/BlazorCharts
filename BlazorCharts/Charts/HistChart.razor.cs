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
        private AxisLayout LayoutAxisTopX;
        private AxisLayout LayoutAxisDownX;

        protected override void OnInitialized()
        {
            LayoutAxisY = AxisLayout.TicksInternal()
                                    .WithTickSize(20)
                                    .From(height - padding)
                                    .To(padding)
                                    .At(padding);

            LayoutAxisTopX = AxisLayout.FullInternal()
                                       .WithTickSize(20)
                                       .From(padding)
                                       .To(width - padding)
                                       .At(() => Model?.AxisY is null ? 
                                                 height - padding :
                                                 height - padding + (int)(Model.AxisY.Min / Model.AxisY.Size * (height - 2 * padding)));

            LayoutAxisDownX = AxisLayout.TicksInternal()
                                        .WithTickSize(20)
                                        .From(padding)
                                        .To(width - padding)
                                        .At(() => Model?.AxisY is null ?
                                                  height - padding :
                                                  height - padding + (int)(Model.AxisY.Min / Model.AxisY.Size * (height - 2 * padding)));
        }
    }
}
