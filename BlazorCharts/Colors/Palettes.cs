using System.Drawing;

namespace BlazorGraphs
{
    public static class Palettes
    {
        public static CyclicPalette Primary
        {
            get => new CyclicPalette(Color.Red,
                                     Color.Orange,
                                     Color.Gold,
                                     Color.LimeGreen,
                                     Color.Aqua,
                                     Color.DodgerBlue,
                                     Color.Violet,
                                     Color.BlueViolet);
        }

        public static CyclicPalette Light
        {
            get => new CyclicPalette(Color.DeepSkyBlue,
                                     Color.Turquoise,
                                     Color.GreenYellow,
                                     Color.Gold,
                                     Color.Tomato,
                                     Color.Pink,
                                     Color.Orchid,
                                     Color.MediumPurple);
        }

        public static CyclicPalette Pastel
        {
            get => new CyclicPalette(Color.LightBlue,
                                     Color.PaleTurquoise,
                                     Color.PaleGreen,
                                     Color.PapayaWhip,
                                     Color.PeachPuff,
                                     Color.LightPink,
                                     Color.Plum,
                                     Color.Thistle);
        }

        public static CyclicPalette Dark
        {
            get => new CyclicPalette(Color.SteelBlue,
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
