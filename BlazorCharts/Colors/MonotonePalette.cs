using System.Drawing;

namespace BlazorGraphs
{
    public class MonotonePalette : IColorStream
    {
        private Color[] palette;
        private Int32 index;

        public MonotonePalette(Color base_color, byte lenght)
        {
            ArgumentOutOfRangeException.ThrowIfZero(lenght);
            index = 0;
            palette = new Color[lenght];

            if (base_color.GetBrightness() > 0.75)
                base_color = Color.FromArgb((int)(0.75 * base_color.R),
                                            (int)(0.75 * base_color.G),
                                            (int)(0.75 * base_color.B));
            else if (base_color.GetBrightness() < 0.25)
                base_color = Color.FromArgb((int)(base_color.R + 0.25 * (255 - base_color.R)),
                                            (int)(base_color.G + 0.25 * (255 - base_color.G)),
                                            (int)(base_color.B + 0.25 * (255 - base_color.B)));

            for (int i = 0; i < lenght / 2; i++)
            {
                palette[i] = Color.FromArgb((int)(base_color.R + 1.5 * (lenght / 2 - i) / lenght * (255 - base_color.R)),
                                            (int)(base_color.G + 1.5 * (lenght / 2 - i) / lenght * (255 - base_color.G)),
                                            (int)(base_color.B + 1.5 * (lenght / 2 - i) / lenght * (255 - base_color.B)));
            }

            for (int i = lenght / 2; i < lenght; i++)
            {
                palette[i] = Color.FromArgb((int)(base_color.R + 1.5 * (lenght / 2 - i) / lenght * base_color.R),
                                            (int)(base_color.G + 1.5 * (lenght / 2 - i) / lenght * base_color.G),
                                            (int)(base_color.B + 1.5 * (lenght / 2 - i) / lenght * base_color.B));
            }
        }

        public Color Next()
        {
            Color new_color = palette[index];
            index++;

            if (index >= palette.Length)
                index = 0;

            return new_color;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
