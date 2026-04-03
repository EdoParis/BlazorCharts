using BlazorGraphs.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Legends
{
    public partial class LegendBar
    {
        [Parameter] public Positioning Direction { get; set; }
        [Parameter] public LegendModel Model { get; set; }
    }
}
