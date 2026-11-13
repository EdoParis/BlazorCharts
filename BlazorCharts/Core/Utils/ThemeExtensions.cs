namespace BlazorGraphs.Core
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

        public static string TooltipBackgroundString(this Theme theme)
        {
            return theme.Tooltip.BackgroundColor?.ToHex() ?? TRANSPARENT;
        }

        public static string TooltipBorderColorString(this Theme theme)
        {
            return theme.Tooltip.BorderColor?.ToHex() ?? CURRENT;
        }

        public static string TooltipTextColorString(this Theme theme)
        {
            return theme.Tooltip.TextColor?.ToHex() ?? CURRENT;
        }
    }
}
