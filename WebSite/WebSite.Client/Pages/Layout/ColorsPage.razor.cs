using BlazorGraphs;
using Microsoft.AspNetCore.Components;

namespace WebApp.Pages.Layout
{
    public partial class ColorsPage : ComponentBase
    {
        private static Dictionary<int, (string Name, IColorStream Palette)> available_palettes = new()
        {
            {0, ("Random", new RandomPalette())},
            {1, (nameof(Palettes.Primary), Palettes.Primary)},
            {2, (nameof(Palettes.Light), Palettes.Light) },
            {3, (nameof(Palettes.Pastel), Palettes.Pastel) },
            {4, (nameof(Palettes.Dark), Palettes.Dark) },
            {5, (nameof(Palettes.Red), Palettes.Red) },
            {6, (nameof(Palettes.Green), Palettes.Green) },
            {7, (nameof(Palettes.Blue), Palettes.Blue) },
            {8, (nameof(Palettes.Purple), Palettes.Purple) },
        };
        private Circulargram model;
        private IColorStream palette;
        private Int32 palette_index;

        protected override void OnInitialized()
        {
            model = new Circulargram();
            palette = available_palettes[palette_index].Palette;

            for (int i = 0; i < 8; i++)
            {
                model.Add(new Slice()
                {
                    Label = $"S{i + 1}",
                    Color = palette.Next(),
                    Value = 10
                });
            }
        }

        private void OnPaletteSelect(int index)
        {
            if (available_palettes.TryGetValue(index, out var selected))
            {
                palette_index = index;
                palette = selected.Palette;

                model.Clear();
                for (int i = 0; i < 8; i++)
                {
                    model.Add(new Slice()
                    {
                        Label = $"S{i + 1}",
                        Color = palette.Next(),
                        Value = 10
                    });
                }
            }
        }
    }
}
