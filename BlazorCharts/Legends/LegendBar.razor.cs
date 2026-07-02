using BlazorGraphs.Enums;
using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Legends
{
    [Obsolete("use LegendHorizontal or LegendVertical components instead")]
    public partial class LegendBar
    {
        [Parameter] public Positioning Direction { get; set; }
        [Parameter] public ILegend Model { get; set; }
        [Parameter] public Theme Theme { get; set; }
    }
}
