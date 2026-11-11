using BlazorGraphs;
using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public partial class ThemeSelect : ComponentBase
    {
        [Parameter] public EventCallback<Theme> ValueChanged { get; set; }
        [Parameter] public Theme Value 
        { 
            get => theme; 
            set 
            {
                theme = value;
                theme_index = null;
                foreach(var kvp in available_themes)
                {
                    if (kvp.Value.Theme == value)
                    {
                        theme_index = kvp.Key;
                        break;
                    }
                }
            } 
        }

        private Dictionary<int, (string Name, Theme Theme)> available_themes;
        private Int32? theme_index;
        private Theme theme;

        public ThemeSelect()
        {
            available_themes = new Dictionary<int, (string Name, Theme Theme)>()
            {
                {0, ("-", default)},
                {1, (nameof(Theme.Light), Theme.Light)},
                {2, (nameof(Theme.Dark), Theme.Dark) },
                {3, (nameof(Theme.Arctic), Theme.Arctic) },
                {4, (nameof(Theme.Beach), Theme.Beach) },
                {5, (nameof(Theme.Neon), Theme.Neon) },
                {6, (nameof(Theme.Night), Theme.Night) },
                {7, (nameof(Theme.Rounded), Theme.Rounded) }
            };
        }

        private async Task OnThemeSelect(int index)
        {
            if (available_themes.TryGetValue(index, out var selected))
            {
                theme = selected.Theme;
                theme_index = index;
                await ValueChanged.InvokeAsync(selected.Theme);
            }
        }
    }
}
