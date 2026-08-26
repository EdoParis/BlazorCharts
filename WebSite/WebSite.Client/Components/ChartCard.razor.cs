using Microsoft.AspNetCore.Components;
using BlazorGraphs;

namespace WebApp.Components
{
    public partial class ChartCard
    {
        [Parameter] public String Title { get; set; }
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
