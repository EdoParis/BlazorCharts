using System.Drawing;

namespace BlazorGraphs
{
    public class ColorPalette : IColorStream
    {
        private Color[] palette;
        private Int32 index;

        public ColorPalette(params Color[] colors) 
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

        public static ColorPalette Primary
        {
            get => new ColorPalette(Color.Red, 
                                    Color.Orange, 
                                    Color.Gold, 
                                    Color.LimeGreen, 
                                    Color.Aqua, 
                                    Color.DodgerBlue, 
                                    Color.Violet, 
                                    Color.BlueViolet);
        }

        public static ColorPalette Light
        {
            get => new ColorPalette(Color.DeepSkyBlue, 
                                    Color.Turquoise, 
                                    Color.GreenYellow, 
                                    Color.Gold, 
                                    Color.Tomato, 
                                    Color.Pink, 
                                    Color.Orchid, 
                                    Color.MediumPurple);
        }

        public static ColorPalette Pastel
        {
            get => new ColorPalette(Color.LightBlue, 
                                    Color.PaleTurquoise, 
                                    Color.PaleGreen, 
                                    Color.PapayaWhip, 
                                    Color.PeachPuff, 
                                    Color.LightPink, 
                                    Color.Plum, 
                                    Color.Thistle);
        }

        public static ColorPalette Dark
        {
            get => new ColorPalette(Color.SteelBlue, 
                                    Color.CadetBlue, 
                                    Color.DarkSeaGreen, 
                                    Color.Khaki, 
                                    Color.Tan, 
                                    Color.RosyBrown, 
                                    Color.SlateGray, 
                                    Color.DarkSlateBlue);
        }
    }
}
