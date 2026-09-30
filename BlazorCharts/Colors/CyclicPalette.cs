using System.Drawing;

namespace BlazorGraphs
{
    public class CyclicPalette : IColorStream
    {
        private Color[] palette;
        private Int32 index;

        public CyclicPalette(params Color[] colors) 
        {
            ArgumentNullException.ThrowIfNull(colors);
            ArgumentOutOfRangeException.ThrowIfZero(colors.Length);
            palette = colors;
            index = 0;
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
