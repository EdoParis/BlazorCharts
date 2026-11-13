namespace BlazorGraphs.Core
{
    internal static class MarkerExtensions
    {
        public static string Render(this DataMarker shape, int x, int y, int size, bool rounded)
        {
            switch (shape)
            {
                case DataMarker.Circle:
                    return PathRenderer.RenderCircle(x, y, size);

                case DataMarker.Square:
                    return rounded ? RoundedPathRenderer.RenderSquare(x, y, size) :
                                     PathRenderer.RenderSquare(x, y, size);

                case DataMarker.Diamond:
                    return rounded ? RoundedPathRenderer.RenderDiamond(x, y, size) :
                                     PathRenderer.RenderDiamond(x, y, size);

                case DataMarker.Triangle:
                    return rounded ? RoundedPathRenderer.RenderTriangle(x, y, size) :
                                     PathRenderer.RenderTriangle(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }

        public static string Render(this SeriesMarker symbol, int x, int y, int size, bool rounded)
        {
            switch (symbol)
            {
                case SeriesMarker.Circle:
                    return PathRenderer.RenderCircle(x, y, size);

                case SeriesMarker.Square:
                    return rounded ? RoundedPathRenderer.RenderSquare(x, y, size) :
                                     PathRenderer.RenderSquare(x, y, size);

                case SeriesMarker.Diamond:
                    return rounded ? RoundedPathRenderer.RenderDiamond(x, y, size) :
                                     PathRenderer.RenderDiamond(x, y, size);

                case SeriesMarker.Triangle:
                    return rounded ? RoundedPathRenderer.RenderTriangle(x, y, size) :
                                     PathRenderer.RenderTriangle(x, y, size);

                case SeriesMarker.Slice:
                    return rounded ? RoundedPathRenderer.RenderSlice(x, y, size) :
                                     PathRenderer.RenderSlice(x, y, size);

                case SeriesMarker.Solidline:
                    return rounded ? RoundedPathRenderer.RenderSolidLine(x, y, size) :
                                     PathRenderer.RenderSolidLine(x, y, size);

                case SeriesMarker.Dashedline:
                    return rounded ? RoundedPathRenderer.RenderDashedLine(x, y, size) :
                                     PathRenderer.RenderDashedLine(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
