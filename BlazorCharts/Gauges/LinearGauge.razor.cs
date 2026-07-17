using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Gauges
{
    public partial class LinearGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Boolean Reverse { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = 3 * PADDING;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.Axis.Size;
        private AxisLayout DefaultAxisLayout;
        private AxisLayout ReverseAxisLayout;

        protected override void OnInitialized()
        {
            DefaultAxisLayout = AxisLayout.FullExternal()
                                          .WithTickSize(20)
                                          .From(padding)
                                          .To(width - padding)
                                          .At(height - padding);

            ReverseAxisLayout = AxisLayout.FullInternal()
                                          .WithTickSize(20)
                                          .From(padding)
                                          .To(width - padding)
                                          .At(padding);
        }
    }
}
