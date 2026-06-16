using System;
using System.Drawing;

namespace BlazorGraphs.Structures
{
    public struct Theme
    {
        public Color? BackgroundColor { get; set; }
        public Color? TextColor { get; set; }
        public Color? AxisColor { get; set; }
        public string FontFamily { get; set; }

        public static Theme Dark
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(10, 10, 10),
                TextColor = Color.FromArgb(245, 245, 245),
                AxisColor = Color.FromArgb(245, 245, 245)
            };
        }

        public static Theme Light
        {
            get => new Theme()
            {
                BackgroundColor = Color.FromArgb(245, 245, 245),
                TextColor = Color.FromArgb(10, 10, 10),
                AxisColor = Color.FromArgb(10, 10, 10)
            };
        }
    }
}
