using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Components
{
    public partial class LegendHorizontal
    {
        [Parameter] public ILegend Model { get; set; }
        [Parameter] public Theme Theme { get; set; }
    }
}
