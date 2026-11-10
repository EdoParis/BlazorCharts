namespace BlazorGraphs.Core
{
    internal static class PathRenderer
    {
        public static string RenderCircle(int x, int y, int size)
        {
            int r = (int)(size / Math.Sqrt(Math.PI));
            return $"M {x} {y - r} A {r} {r} 0 0 1 {x} {y + r} A {r} {r} 0 0 1 {x} {y - r} Z";
        }

        public static string RenderSquare(int x, int y, int size)
        {
            return $"M {x - size / 2} {y - size / 2} h {size} v {size} h {-size} Z";
        }

        public static string RenderDiamond(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(2));
            return $"M {x} {y - s} L {x + s} {y} L {x} {y + s} L {x - s} {y} Z";
        }

        public static string RenderTriangle(int x, int y, int size)
        {
            int b = 4 * size / 3;
            int h = (int)(b * Math.Sqrt(3) / 2);
            return $"M {x - b / 2} {y + h / 2} h {b} L {x} {y - h / 2} Z";
        }

        public static string RenderSlice(int x, int y, int size)
        {
            return $"M {x - size / 2} {y - size / 2} a {size} {size} 0 0 1 {size} {size} h {-size}Z";
        }

        public static string RenderSolidLine(int x, int y, int size)
        {
            return $"M {x - size / 2} {y - size / 6} h {size} v {size / 3} h {-size} Z";
        }

        public static string RenderDashedLine(int x, int y, int size)
        {
            return $"M {x - size / 2} {y - size / 6} h {2 * size / 5} v {size / 3} h {-2 * size / 5} Z M {x + size / 2} {y - size / 6} h {-2 * size / 5} v {size / 3} h {2 * size / 5} Z";
        }
    }
}
