using System;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Theme
    {
        public Color? BackgroundColor { get; set; }
        public Color? AxisColor { get; set; }
        public Color? TextColor { get; set; }
        public string FontFamily { get; set; }

        public static Theme Dark
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(18, 18, 20),
                TextColor = Color.FromArgb(248, 249, 250),
                AxisColor = Color.FromArgb(248, 249, 250)
            };
        }

        public static Theme Light
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(248, 249, 250),
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
                BackgroundColor = Color.FromArgb(10, 10, 20),
                TextColor = Color.FromArgb(0, 240, 255),
                AxisColor = Color.FromArgb(0, 200, 230)
            };
        }
    }
}
