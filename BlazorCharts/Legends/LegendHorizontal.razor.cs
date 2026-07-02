using BlazorGraphs.Interfaces;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Legends
{
    public partial class LegendHorizontal
    {
        [Parameter] public ILegend Model { get; set; }
        [Parameter] public Theme Theme { get; set; }
    }
}
