using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class ThemePage : ComponentBase
    {
        private static Dictionary<int, (string Name, Theme Theme)> available_themes = new()
        {
            {0, ("-", default)},
            {1, (nameof(Theme.Light), Theme.Light)},
            {2, (nameof(Theme.Dark), Theme.Dark) },
            {3, (nameof(Theme.Arctic), Theme.Arctic) },
            {4, (nameof(Theme.Beach), Theme.Beach) },
            {5, (nameof(Theme.Neon), Theme.Neon) },
        };
        private Histogram model;
        private Theme theme;
        private Int32? theme_index;

        private Color? BackgroundTheme
        {
            get => theme.BackgroundColor;
            set
            {
                theme.BackgroundColor = value;
                theme_index = null;
            }
        }

        private Color? AxisTheme
        {
            get => theme.AxisColor;
            set
            {
                theme.AxisColor = value;
                theme_index = null;
            }
        }

        private Color? TextTheme
        {
            get => theme.TextColor;
            set
            {
                theme.TextColor = value;
                theme_index = null;
            }
        }

        private String FontTheme
        {
            get => theme.FontFamily;
            set
            {
                theme.FontFamily = value;
                theme_index = null;
            }
        }

        protected override void OnInitialized()
        {
            model = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue, Color.MediumOrchid);

            for (int i = 0; i < 10; i++)
            {
                model.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = 5 - Math.Pow(i - 4, 2)
                });
            }
        }

        private void OnThemeSelect(int index)
        {
            if (available_themes.TryGetValue(index, out var selected))
            {
                theme = selected.Theme;
                theme_index = index;
            }
        }
    }
}
