using BlazorGraphs;
using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public partial class TooltipSelect : ComponentBase
    {
        [Parameter] public EventCallback<TooltipStyle> ValueChanged { get; set; }
        [Parameter] public TooltipStyle Value { get; set; }

        private Dictionary<int, (string Name, TooltipStyle Style)> available_styles;
        private Int32? style_index;
        private TooltipStyle style;

        public TooltipSelect()
        {
            available_styles = new Dictionary<int, (string Name, TooltipStyle Style)>()
            {
                {0, ("-", default)},
                {1, (nameof(TooltipStyle.Light), TooltipStyle.Light)},
                {2, (nameof(TooltipStyle.Dark), TooltipStyle.Dark) },
                {3, (nameof(TooltipStyle.Arctic), TooltipStyle.Arctic) },
                {4, (nameof(TooltipStyle.Beach), TooltipStyle.Beach) },
                {5, (nameof(TooltipStyle.Neon), TooltipStyle.Neon) },
                {6, (nameof(TooltipStyle.Night), TooltipStyle.Night) }
            };
        }

        protected override void OnParametersSet()
        {
            style = Value;
            style_index = null;
            foreach (var kvp in available_styles)
            {
                if (kvp.Value.Style == Value)
                {
                    style_index = kvp.Key;
                    break;
                }
            }
        }

        private async Task OnStyleChange(ChangeEventArgs e)
        {
            if (int.TryParse(e?.Value?.ToString(), out int parsed_index))
            {
                if (available_styles.TryGetValue(parsed_index, out var selected))
                {
                    style = selected.Style;
                    style_index = parsed_index;
                    await ValueChanged.InvokeAsync(selected.Style);
                }
            }
        }
    }
}
