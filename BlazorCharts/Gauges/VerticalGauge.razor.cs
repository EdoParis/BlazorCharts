using BlazorGraphs.Internal;
using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Gauges
{
    public partial class VerticalGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Boolean Reverse { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = 3 * PADDING;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetV => height - padding;
        private double scaleV => (height - 2 * padding) / Model.Axis.Size;
        private AxisLayout DefaultAxisLayout;
        private AxisLayout ReverseAxisLayout;

        protected override void OnInitialized()
        {
            DefaultAxisLayout = AxisLayout.FullExternal()
                                          .WithTickSize(20)
                                          .From(height - padding)
                                          .To(padding)
                                          .At(width / 2);

            ReverseAxisLayout = AxisLayout.FullInternal()
                                          .WithTickSize(20)
                                          .From(height - padding)
                                          .To(padding)
                                          .At(width / 2);
        }
    }
}
