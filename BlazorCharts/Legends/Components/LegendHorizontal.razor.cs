using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Components
{
    public partial class LegendHorizontal
    {
        [Parameter] public MarkerShapes Marker { get; set; }
        [Parameter] public ILegend Model { get; set; }
        [Parameter] public Theme Theme { get; set; }
        private MarkerRenderer marker_renderer;

        protected override void OnInitialized()
        {
            marker_renderer = new MarkerRenderer();
        }
    }
}
