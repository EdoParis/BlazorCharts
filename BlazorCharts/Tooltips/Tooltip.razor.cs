using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class Tooltip : ComponentBase
    {
        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Point Position { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
