namespace BlazorGraphs.Core
{
    internal static class MarkerExtensions
    {
        public static string Render(this MarkerShape shape, int x, int y, int size, bool rounded)
        {
            switch (shape)
            {
                case MarkerShape.Circle:
                    return PathRenderer.RenderCircle(x, y, size);

                case MarkerShape.Square:
                    return rounded ? RoundedPathRenderer.RenderSquare(x, y, size) :
                                     PathRenderer.RenderSquare(x, y, size);

                case MarkerShape.Diamond:
                    return rounded ? RoundedPathRenderer.RenderDiamond(x, y, size) :
                                     PathRenderer.RenderDiamond(x, y, size);

                case MarkerShape.Triangle:
                    return rounded ? RoundedPathRenderer.RenderTriangle(x, y, size) :
                                     PathRenderer.RenderTriangle(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }

        public static string Render(this MarkerSymbol symbol, int x, int y, int size, bool rounded)
        {
            switch (symbol)
            {
                case MarkerSymbol.Circle:
                    return PathRenderer.RenderCircle(x, y, size);

                case MarkerSymbol.Square:
                    return rounded ? RoundedPathRenderer.RenderSquare(x, y, size) :
                                     PathRenderer.RenderSquare(x, y, size);

                case MarkerSymbol.Diamond:
                    return rounded ? RoundedPathRenderer.RenderDiamond(x, y, size) :
                                     PathRenderer.RenderDiamond(x, y, size);

                case MarkerSymbol.Triangle:
                    return rounded ? RoundedPathRenderer.RenderTriangle(x, y, size) :
                                     PathRenderer.RenderTriangle(x, y, size);

                case MarkerSymbol.Slice:
                    return rounded ? RoundedPathRenderer.RenderSlice(x, y, size) :
                                     PathRenderer.RenderSlice(x, y, size);

                case MarkerSymbol.Solidline:
                    return rounded ? RoundedPathRenderer.RenderSolidLine(x, y, size) :
                                     PathRenderer.RenderSolidLine(x, y, size);

                case MarkerSymbol.Dashedline:
                    return rounded ? RoundedPathRenderer.RenderDashedLine(x, y, size) :
                                     PathRenderer.RenderDashedLine(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
