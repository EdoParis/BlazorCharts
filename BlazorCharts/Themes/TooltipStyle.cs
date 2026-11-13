using System.Drawing;

namespace BlazorGraphs
{
    public struct TooltipStyle : IEquatable<TooltipStyle>
    {
        public Color? BackgroundColor { get; set; }
        public Color? BorderColor { get; set; }
        public Color? TextColor { get; set; }

        public static TooltipStyle Dark
        {
            get => new TooltipStyle()
            {
                BackgroundColor = Color.FromArgb(43, 48, 53),
                BorderColor = Color.FromArgb(150, 150, 150),
                TextColor = Color.FromArgb(255, 255, 255)
            };
        }

        public static TooltipStyle Light
        {
            get => new TooltipStyle()
            {
                BackgroundColor = Color.FromArgb(255, 255, 255),
                BorderColor = Color.FromArgb(200, 200, 200),
                TextColor = Color.FromArgb(33, 37, 41)
            };
        }

        public static TooltipStyle Arctic
        {
            get => new TooltipStyle()
            {
                BackgroundColor = Color.FromArgb(240, 244, 248),
                BorderColor = Color.FromArgb(148, 163, 184),
                TextColor = Color.FromArgb(71, 85, 105)
            };
        }

        public static TooltipStyle Beach
        {
            get => new TooltipStyle()
            {
                BackgroundColor = Color.FromArgb(243, 239, 224),
                BorderColor = Color.FromArgb(190, 190, 160),
                TextColor = Color.FromArgb(42, 68, 94)
            };
        }

        public static TooltipStyle Neon
        {
            get => new TooltipStyle()
            {
                BackgroundColor = Color.FromArgb(43, 48, 53),
                BorderColor = Color.FromArgb(0, 200, 230),
                TextColor = Color.FromArgb(0, 240, 255)
            };
        }

        public static TooltipStyle Night
        {
            get => new TooltipStyle()
            {
                BackgroundColor = Color.FromArgb(33, 37, 41),
                BorderColor = Color.FromArgb(80, 80, 100),
                TextColor = Color.FromArgb(160, 160, 160)
            };
        }

        #region EQUALITY

        public override int GetHashCode()
        {
            return HashCode.Combine(BackgroundColor,
                                    BorderColor,
                                    TextColor);
        }

        public override bool Equals(object obj)
        {
            return obj is TooltipStyle other && Equals(other);
        }

        public bool Equals(TooltipStyle other)
        {
            return BackgroundColor == other.BackgroundColor &&
                   BorderColor == other.BorderColor &&
                   TextColor == other.TextColor;
        }

        public static bool operator ==(TooltipStyle left, TooltipStyle right) => left.Equals(right);
        public static bool operator !=(TooltipStyle left, TooltipStyle right) => !left.Equals(right);

        #endregion
    }
}
