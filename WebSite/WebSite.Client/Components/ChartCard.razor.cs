using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public partial class ChartCard
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
