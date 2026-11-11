using BlazorGraphs.Core;
using System.Drawing;

namespace BlazorGraphs
{
    public struct Theme : IEquatable<Theme>
    {
        public Color? BackgroundColor { get; set; }
        public Color? AxisColor { get; set; }
        public Color? TextColor { get; set; }
        public String FontFamily { get; set; }
        public Boolean RoundedShapes { get; set; }
        public Boolean RoundedMarkers { get; set; }
        public MarkerShape DataMarker { get; set; }
        public MarkerSymbol SeriesMarker { get; set; }

        public static Theme FromColor(Color color)
        {
            Color opposite_color = color.Invert();

            return new Theme()
            {
                BackgroundColor = color,
                AxisColor = opposite_color,
                TextColor = opposite_color
            };
        }

        public static Theme Rounded
        {
            get => new Theme()
            {
                RoundedShapes = true,
                RoundedMarkers = true
            };
        }

        public static Theme Dark
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(33, 37, 41),
                TextColor = Color.FromArgb(255, 255, 255),
                AxisColor = Color.FromArgb(255, 255, 255)
            };
        }

        public static Theme Light
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(255, 255, 255),
                TextColor = Color.FromArgb(33, 37, 41),
                AxisColor = Color.FromArgb(33, 37, 41)
            };
        }

        public static Theme Arctic
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(240, 244, 248),
                TextColor = Color.FromArgb(71, 85, 105),
                AxisColor = Color.FromArgb(148, 163, 184)
            };
        }

        public static Theme Beach
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(243, 239, 224),
                TextColor = Color.FromArgb(42, 68, 94),
                AxisColor = Color.FromArgb(190, 190, 160)
            };
        }

        public static Theme Neon
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(33, 37, 41),
                TextColor = Color.FromArgb(0, 240, 255),
                AxisColor = Color.FromArgb(0, 200, 230)
            };
        }

        public static Theme Night
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(45, 45, 68),
                TextColor = Color.FromArgb(160, 160, 160),
                AxisColor = Color.FromArgb(80, 80, 100)
            };
        }

        #region EQUALITY

        public override int GetHashCode()
        {
            return HashCode.Combine(BackgroundColor, 
                                    AxisColor,
                                    TextColor,
                                    FontFamily,
                                    RoundedShapes,
                                    RoundedMarkers,
                                    DataMarker,
                                    SeriesMarker);
        }

        public override bool Equals(object obj)
        {
            return obj is Theme other && Equals(other);
        }

        public bool Equals(Theme other)
        {
            return BackgroundColor == other.BackgroundColor &&
                   AxisColor == other.AxisColor &&
                   TextColor == other.TextColor &&
                   FontFamily == other.FontFamily &&
                   RoundedShapes == other.RoundedShapes &&
                   RoundedMarkers == other.RoundedMarkers &&
                   DataMarker == other.DataMarker &&
                   SeriesMarker == other.SeriesMarker;
        }

        public static bool operator ==(Theme left, Theme right) => left.Equals(right);
        public static bool operator !=(Theme left, Theme right) => !left.Equals(right);

        #endregion
    }
}
