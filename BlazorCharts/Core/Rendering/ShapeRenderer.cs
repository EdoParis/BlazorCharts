namespace BlazorGraphs.Core
{
    internal static class ShapeRenderer
    {
        public static string RenderCircle(int x, int y, int size)
        {
            int r = (int)(size / Math.Sqrt(Math.PI));

            return PathBuilder.CreateBuilder()
                              .MoveTo(x, y - r)
                              .SmallArcClockwise(r, r, x, y + r)
                              .SmallArcClockwise(r, r, x, y - r)
                              .Close()
                              .Build();
        }

        public static string RenderSquare(int x, int y, int size)
        {
            return PathBuilder.CreateBuilder()
                              .MoveTo(x - size / 2, y - size / 2)
                              .RelativeHorizontal(size)
                              .RelativeVertical(size)
                              .RelativeHorizontal(-size)
                              .Close()
                              .Build();
        }

        public static string RenderDiamond(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(2));

            return PathBuilder.CreateBuilder()
                              .MoveTo(x, y - s)
                              .LineTo(x + s, y)
                              .LineTo(x, y + s)
                              .LineTo(x - s, y)
                              .Close()
                              .Build();
        }

        public static string RenderTriangle(int x, int y, int size)
        {
            int b = 4 * size / 3;
            int h = (int)(b * Math.Sqrt(3) / 2);

            return PathBuilder.CreateBuilder()
                              .MoveTo(x - b / 2, y + h / 2)
                              .RelativeHorizontal(b)
                              .LineTo(x, y - h / 2)
                              .Close()
                              .Build();
        }

        public static string RenderSlice(int x, int y, int size)
        {
            int r = (int)(2 * size / Math.Sqrt(Math.PI));
            return PathBuilder.CreateBuilder()
                              .MoveTo(x - r / 2, y - r / 2)
                              .SmallRelativeArcClockwise(r, r, r, r)
                              .RelativeHorizontal(-r)
                              .Close()
                              .Build();
        }

        public static string RenderSolidLine(int x, int y, int size)
        {
            return PathBuilder.CreateBuilder()
                              .MoveTo(x - size / 2, y - size / 6)
                              .RelativeHorizontal(size)
                              .RelativeVertical(size / 3)
                              .RelativeHorizontal(-size)
                              .Close()
                              .Build();
        }

        public static string RenderDashedLine(int x, int y, int size)
        {
            return PathBuilder.CreateBuilder()
                              .MoveTo(x - size / 2, y - size / 6)
                              .RelativeHorizontal(2 * size / 5)
                              .RelativeVertical(size / 3)
                              .RelativeHorizontal(-2 * size / 5)
                              .Close()
                              .MoveTo(x + size / 2, y - size / 6)
                              .RelativeHorizontal(-2 * size / 5)
                              .RelativeVertical(size / 3)
                              .RelativeHorizontal(2 * size / 5)
                              .Close()
                              .Build();
        }

        public static string RenderPlus(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(5));

            return PathBuilder.CreateBuilder()
                              .MoveTo(x + s / 2, y + 3 * s / 2)
                              .RelativeVertical(-s)
                              .RelativeHorizontal(s)
                              .RelativeVertical(-s)
                              .RelativeHorizontal(-s)
                              .RelativeVertical(-s)
                              .RelativeHorizontal(-s)
                              .RelativeVertical(s)
                              .RelativeHorizontal(-s)
                              .RelativeVertical(s)
                              .RelativeHorizontal(s)
                              .RelativeVertical(s)
                              .Close()
                              .Build();
        }

        public static string RenderCross(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(10));

            return PathBuilder.CreateBuilder()
                              .MoveTo(x + s, y)
                              .RelativeTo(s, -s)
                              .RelativeTo(-s, -s)
                              .RelativeTo(-s, s)
                              .RelativeTo(-s, -s)
                              .RelativeTo(-s, s)
                              .RelativeTo(s, s)
                              .RelativeTo(-s, s)
                              .RelativeTo(s, s)
                              .RelativeTo(s, -s)
                              .RelativeTo(s, s)
                              .RelativeTo(s, -s)
                              .Close()
                              .Build();
        }
    }
}
