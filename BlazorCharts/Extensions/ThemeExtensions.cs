using BlazorGraphs.Structures;

namespace BlazorGraphs.Extensions
{
    internal static class ThemeExtensions
    {
        private const string DEFAULT_BACKGROUND = "transparent";
        private const string DEFAULT_COLOR = "currentColor";
        private const string DEFAULT_FONT = "inherit";

        public static string BackgroundString(this Theme theme)
        {
            return theme.BackgroundColor?.ToHex() ?? DEFAULT_BACKGROUND;
        }

        public static string TextColorString(this Theme theme)
        {
            return theme.TextColor?.ToHex() ?? DEFAULT_COLOR;
        }

        public static string AxisColorString(this Theme theme)
        {
            return theme.AxisColor?.ToHex() ?? DEFAULT_COLOR;
        }

        public static string FontString(this Theme theme)
        {
            return theme.FontFamily ?? DEFAULT_FONT;
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
