using BlazorGraphs.Structures;

namespace BlazorGraphs.Extensions
{
    internal static class ThemeExtensions
    {
        private const string TRANSPARENT = "transparent";
        private const string CURRENT = "currentColor";
        private const string INHERIT = "inherit";

        public static string BackgroundString(this Theme theme)
        {
            return theme.BackgroundColor?.ToHex() ?? TRANSPARENT;
        }

        public static string AxisColorString(this Theme theme)
        {
            return theme.AxisColor?.ToHex() ?? CURRENT;
        }

        public static string TextColorString(this Theme theme)
        {
            return theme.TextColor?.ToHex() ?? CURRENT;
        }

        public static string FontString(this Theme theme)
        {
            return theme.FontFamily ?? INHERIT;
        }

        public static Theme Merge(this Theme first, Theme second)
        {
            return new Theme()
            {
                BackgroundColor = first.BackgroundColor ?? second.BackgroundColor,
                TextColor = first.TextColor ?? second.TextColor,
                AxisColor = first.AxisColor ?? second.AxisColor,
                FontFamily = first.FontFamily ?? second.FontFamily
            };
        }
    }
}
