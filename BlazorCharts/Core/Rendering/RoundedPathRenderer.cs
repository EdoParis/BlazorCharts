namespace BlazorGraphs.Core
{
    internal static class RoundedPathRenderer
    {
        private static int ROUNDING = 10;

        public static string RenderSquare(int x, int y, int size)
        {
            int s = size / 2;
            int roundness = s > 2 * ROUNDING ? ROUNDING : s / 2;

            return $"M {x - s} {y - s + roundness} " +
                   $"a {roundness} {roundness} 0 0 1 {roundness} {-roundness} " +
                   $"h {size - 2 * roundness} " +
                   $"a {roundness} {roundness} 0 0 1 {roundness} {roundness} " +
                   $"v {size - 2 * roundness} " +
                   $"a {roundness} {roundness} 0 0 1 {-roundness} {roundness} " +
                   $"h {-size + 2 * roundness} " +
                   $"a {roundness} {roundness} 0 0 1 {-roundness} {-roundness} Z";
        }

        public static string RenderDiamond(int x, int y, int size)
        {
            int s = (int)(size / Math.Sqrt(2));
            int roundness = s > 2 * ROUNDING ? ROUNDING : s / 2;
            int w = (int)(roundness / Math.Sqrt(2));

            return $"M {x - w} {y - s + w} " +
                   $"A {roundness} {roundness} 0 0 1 {x + w} {y - s + w} " +
                   $"L {x + s - w} {y - w} " +
                   $"A {roundness} {roundness} 0 0 1 {x + s - w} {y + w} " +
                   $"L {x + w} {y + s - w} " +
                   $"A {roundness} {roundness} 0 0 1 {x - w} {y + s - w} " +
                   $"L {x - s + w} {y + w} " +
                   $"A {roundness} {roundness} 0 0 1 {x - s + w} {y - w} Z";
        }

        public static string RenderTriangle(int x, int y, int size)
        {
            int b = 4 * size / 3;
            int h = (int)(b * Math.Sqrt(3) / 2);
            int roundness = b > 4 * ROUNDING ? ROUNDING : b / 4;
            int r_sin_alpha = (int)(roundness * Math.Sqrt(3) / 2);
            int r_cos_alpha = roundness / 2;

            return $"M {x + b / 2 - roundness} {y + h / 2} " +
                   $"A {roundness * 2 / 3} {roundness * 2 / 3} 0 0 0 {x + b / 2 - r_cos_alpha} {y + h / 2 - r_sin_alpha} " +
                   $"L {x + r_cos_alpha} {y - h / 2 + r_sin_alpha} " +
                   $"A {roundness * 2 / 3} {roundness * 2 / 3} 0 0 0 {x - r_cos_alpha} {y - h / 2 + r_sin_alpha} " +
                   $"L {x - b / 2 + r_cos_alpha} {y + h / 2 - r_sin_alpha} " +
                   $"A {roundness * 2 / 3} {roundness * 2 / 3} 0 0 0 {x - b / 2 + roundness} {y + h / 2} Z";
        }

        public static string RenderSlice(int x, int y, int size)
        {
            int s = size / 2;
            int roundness = s > 2 * ROUNDING ? ROUNDING : s / 2;

            return $"M {x - s} {y - s + roundness} " +
                   $"a {roundness} {roundness} 0 0 1 {roundness} {-roundness} " +
                   $"A {size} {size} 0 0 1 {x + s} {y + s - roundness}" +
                   $"a {roundness} {roundness} 0 0 1 {-roundness} {roundness} " +
                   $"L {x - s} {y + s} Z";
        }

        public static string RenderSolidLine(int x, int y, int size)
        {
            int roundness = size / 6;
            return $"M {x - size / 2 + roundness} {y + roundness} " +
                   $"A {roundness} {roundness} 0 0 1 {x - size / 2 + roundness} {y - roundness} " +
                   $"H {x + size / 2 - roundness} " +
                   $"A {roundness} {roundness} 0 0 1 {x + size / 2 - roundness} {y + roundness} Z";
        }

        public static string RenderDashedLine(int x, int y, int size)
        {
            int roundness = size / 6;
            return $"M {x - size / 2 + roundness} {y + roundness} " +
                   $"A {roundness} {roundness} 0 0 1 {x - size / 2 + roundness} {y - roundness} " +
                   $"H {x - size / 10 - roundness} " +
                   $"A {roundness} {roundness} 0 0 1 {x - size / 10 - roundness} {y + roundness} Z" +
                   $"M {x + size / 2 - roundness} {y - roundness} " +
                   $"A {roundness} {roundness} 0 0 1 {x + size / 2 - roundness} {y + roundness} " +
                   $"H {x + size / 10 + roundness} " +
                   $"A {roundness} {roundness} 0 0 1 {x + size / 10 + roundness} {y - roundness} Z";
        }
    }
}
