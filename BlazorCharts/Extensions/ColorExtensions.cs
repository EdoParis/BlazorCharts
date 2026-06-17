using System.Drawing;

namespace BlazorGraphs.Extensions
{
    internal static class ColorExtensions
    {
        public static string ToHex(this Color color)
        {
            return "#" + (color.ToArgb() & 0x00FFFFFF).ToString("X6");
        }

        public static string ToHex(this KnownColor color)
        {
            return Color.FromKnownColor(color).ToHex();
        }

        public static Color Invert(this Color color)
        {
            return Color.FromArgb(
                color.A,  
                255 - color.R,
                255 - color.G,
                255 - color.B
            );
        }
    }
}
