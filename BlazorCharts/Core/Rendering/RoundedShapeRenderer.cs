namespace BlazorGraphs.Core
{
    internal static class RoundedShapeRenderer
    {
        private static int ROUNDING = 10;

        public static string RenderSquare(int x, int y, int size)
        {
            int s = size / 2;
            int roundness = s > 2 * ROUNDING ? ROUNDING : s / 2;

            return PathBuilder.CreateBuilder()
                              .MoveTo(x - s, y - s + roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, roundness, -roundness)
                              .RelativeHorizontal(size - 2 * roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, roundness, roundness)
                              .RelativeVertical(size - 2 * roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, -roundness, roundness)
                              .RelativeHorizontal(-size + 2 * roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, -roundness, -roundness)
                              .Close()
                              .Build();
        }

        public static string RenderDiamond(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(2));
            int roundness = s > 2 * ROUNDING ? ROUNDING : s / 2;
            int w = (int)(roundness / Math.Sqrt(2));

            return PathBuilder.CreateBuilder()
                              .MoveTo(x - w, y - s + w)
                              .SmallArcClockwise(roundness, roundness, x + w, y - s + w)
                              .LineTo(x + s - w, y - w)
                              .SmallArcClockwise(roundness, roundness, x + s - w, y + w)
                              .LineTo(x + w, y + s - w)
                              .SmallArcClockwise(roundness, roundness, x - w, y + s - w)
                              .LineTo(x - s + w, y + w)
                              .SmallArcClockwise(roundness, roundness, x - s + w, y - w)
                              .Close()
                              .Build();
        }

        public static string RenderTriangle(int x, int y, int size)
        {
            int b = 4 * size / 3;
            int h = (int)(b * Math.Sqrt(3) / 2);
            int roundness = b > 4 * ROUNDING ? ROUNDING : b / 4;
            int r_sin_alpha = (int)(roundness * Math.Sqrt(3) / 2);
            int r_cos_alpha = roundness / 2;

            return PathBuilder.CreateBuilder()
                              .MoveTo(x + b / 2 - roundness, y + h / 2)
                              .SmallArcCounterclockwise(roundness * 2 / 3, roundness * 2 / 3, x + b / 2 - r_cos_alpha, y + h / 2 - r_sin_alpha)
                              .LineTo(x + r_cos_alpha, y - h / 2 + r_sin_alpha)
                              .SmallArcCounterclockwise(roundness * 2 / 3, roundness * 2 / 3, x - r_cos_alpha, y - h / 2 + r_sin_alpha)
                              .LineTo(x - b / 2 + r_cos_alpha, y + h / 2 - r_sin_alpha)
                              .SmallArcCounterclockwise(roundness * 2 / 3, roundness * 2 / 3, x - b / 2 + roundness, y + h / 2)
                              .Close()
                              .Build();
        }

        public static string RenderSlice(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(Math.PI));
            int roundness = s > 2 * ROUNDING ? ROUNDING : s / 2;

            return PathBuilder.CreateBuilder()
                              .MoveTo(x - s, y - s + roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, roundness, -roundness)
                              .SmallArcClockwise(size, size, x + s, y + s - roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, -roundness, roundness)
                              .LineTo(x - s, y + s)
                              .Close()
                              .Build();
        }

        public static string RenderSolidLine(int x, int y, int size)
        {
            int roundness = size / 6;

            return PathBuilder.CreateBuilder()
                              .MoveTo(x - size / 2 + roundness, y + roundness)
                              .SmallArcClockwise(roundness, roundness, x - size / 2 + roundness, y - roundness)
                              .Horizontal(x + size / 2 - roundness)
                              .SmallArcClockwise(roundness, roundness, x + size / 2 - roundness, y + roundness)
                              .Close()
                              .Build();
        }

        public static string RenderDashedLine(int x, int y, int size)
        {
            int roundness = size / 6;

            return PathBuilder.CreateBuilder()
                              .MoveTo(x - size / 2 + roundness, y + roundness)
                              .SmallArcClockwise(roundness, roundness, x - size / 2 + roundness, y - roundness)
                              .Horizontal(x - size / 10 - roundness)
                              .SmallArcClockwise(roundness, roundness, x - size / 10 - roundness, y + roundness)
                              .Close()
                              .MoveTo(x + size / 2 - roundness, y - roundness)
                              .SmallArcClockwise(roundness, roundness, x + size / 2 - roundness, y + roundness)
                              .Horizontal(x + size / 10 + roundness)
                              .SmallArcClockwise(roundness, roundness, x + size / 10 + roundness, y - roundness)
                              .Close()
                              .Build();
        }

        public static string RenderPlus(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(5));
            int roundness = s > 4 * ROUNDING ? ROUNDING : s / 4;

            return PathBuilder.CreateBuilder()
                              .MoveTo(x + s / 2, y + s / 2 + roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, roundness, - roundness)
                              .RelativeHorizontal(s - 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, roundness, - roundness)
                              .RelativeVertical(-s + 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, -roundness, -roundness)
                              .RelativeHorizontal(-s + 2 * roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, -roundness, -roundness)
                              .RelativeVertical(-s + 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, -roundness, -roundness)
                              .RelativeHorizontal(-s + 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, -roundness, roundness)
                              .RelativeVertical(s - 2 * roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, -roundness, roundness)
                              .RelativeHorizontal(-s + 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, -roundness, roundness)
                              .RelativeVertical(s - 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, roundness, roundness)
                              .RelativeHorizontal(s - 2 * roundness)
                              .SmallRelativeArcClockwise(roundness, roundness, roundness, roundness)
                              .RelativeVertical(s - 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, roundness, roundness)
                              .RelativeHorizontal(s - 2 * roundness)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, roundness, -roundness)
                              .Close()
                              .Build();
        }

        public static string RenderCross(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(10));
            int roundness = s > 4 * ROUNDING ? ROUNDING : s / 4;
            int w = (int)(roundness * Math.Sqrt(2));

            return PathBuilder.CreateBuilder()
                              .MoveTo(x + s + w / 2, y + w / 2)
                              .SmallRelativeArcClockwise(roundness, roundness, 0, -w)
                              .RelativeTo(s - w, -s + w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, 0, -w)
                              .RelativeTo(-s + w, -s + w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, -w, 0)
                              .RelativeTo(-s + w, s - w)
                              .SmallRelativeArcClockwise(roundness, roundness, -w, 0)
                              .RelativeTo(-s + w, -s + w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, -w, 0)
                              .RelativeTo(-s + w, s - w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, 0, w)
                              .RelativeTo(s - w, s - w)
                              .SmallRelativeArcClockwise(roundness, roundness, 0, w)
                              .RelativeTo(-s + w, s - w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, 0, w)
                              .RelativeTo(s - w, s - w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, w, 0)
                              .RelativeTo(s - w, -s + w)
                              .SmallRelativeArcClockwise(roundness, roundness, w, 0)
                              .RelativeTo(s - w, s - w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, w, 0)
                              .RelativeTo(s - w, -s + w)
                              .SmallRelativeArcCounterclockwise(roundness, roundness, 0, -w)
                              .Close()
                              .Build();
        }
    }
}
