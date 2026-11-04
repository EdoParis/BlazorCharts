using BlazorGraphs;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace WebApp.Pages.Layout
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
            {6, (nameof(Theme.Night), Theme.Night) },
        };

        private enum chart_options
        {
            Linechart,
            Scatterchart,
            Bubblechart
        }

        private Cartesiangram cartesiangram;
        private Bubblegram bubblegram;
        private Theme theme;
        private Int32? theme_index;
        private chart_options selected_chart;

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

        private MarkerSymbol SymbolTheme
        {
            get => theme.SeriesMarker;
            set
            {
                theme.SeriesMarker = value;
                theme_index = null;
            }
        }

        private MarkerShape ShapeTheme
        {
            get => theme.DataMarker;
            set
            {
                theme.DataMarker = value;
                theme_index = null;
            }
        }

        protected override void OnInitialized()
        {
            cartesiangram = new Cartesiangram("Axis-X", "Axis-Y");
            bubblegram = new Bubblegram("Axis-X2", "Axis-Y2");
            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            List<Datapoint> points4 = new();
            List<Bubblepoint> bubbles1 = new();
            List<Bubblepoint> bubbles2 = new();
            List<Bubblepoint> bubbles3 = new();
            Random random = new Random();

            for (int i = 0; i <= 10; i++)
            {
                points1.Add(new Datapoint() { X = 2 * i, Y = 50 + i * i });
                points2.Add(new Datapoint() { X = 2 * i, Y = (i + 2) * (i + 2) });
                points3.Add(new Datapoint() { X = 2 * i, Y = (i + 4) * (i + 4) });
                points4.Add(new Datapoint() { X = 2 * i, Y = (i + 6) * (i + 6) });
                bubbles1.Add(new Bubblepoint() { X = 10 * random.NextDouble(), Y = 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
                bubbles2.Add(new Bubblepoint() { X = 10 * (2 + random.NextDouble()), Y = 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
                bubbles3.Add(new Bubblepoint() { X = 10 * (3 + random.NextDouble()), Y = 10 * random.NextDouble(), Value = 10 * random.NextDouble() });
            }

            cartesiangram.AddSerie("Fn-1", Color.LimeGreen, points1);
            cartesiangram.AddSerie("Fn-2", Color.OrangeRed, points2);
            cartesiangram.AddSerie("Fn-3", Color.CadetBlue, points3);
            cartesiangram.AddSerie("Fn-4", Color.DodgerBlue, points4);
            bubblegram.AddSerie("Bubbles-1", Color.Red, bubbles1);
            bubblegram.AddSerie("Bubbles-2", Color.Gold, bubbles2);
            bubblegram.AddSerie("Bubbles-3", Color.Purple, bubbles3);
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
