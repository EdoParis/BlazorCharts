namespace BlazorGraphs.Core
{
    internal static class PathRenderer
    {
        public static string RenderShape(MarkerShape shape, int x, int y, int size)
        {
            switch (shape)
            {
                case MarkerShape.Circle:
                    return RenderCircle(x, y, size);

                case MarkerShape.Square:
                    return RenderSquare(x, y, size);

                case MarkerShape.Diamond:
                    return RenderDiamond(x, y, size);

                case MarkerShape.Triangle:
                    return RenderTriangle(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }

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
            int b = (int)(2 * size / Math.Pow(3, 1 / 4.0));
            int h = (int)(size * Math.Pow(3, 1 / 4.0));
            return $"M {x - b / 2} {y + h / 2} h {b} L {x} {y - h / 2} Z";
        }
    }
}
