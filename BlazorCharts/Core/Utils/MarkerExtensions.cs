namespace BlazorGraphs.Core
{
    internal static class MarkerExtensions
    {
        public static string Render(this DataMarker shape, int x, int y, int size, bool rounded)
        {
            switch (shape)
            {
                case DataMarker.Circle:
                    return ShapeRenderer.RenderCircle(x, y, size);

                case DataMarker.Square:
                    return rounded ? RoundedShapeRenderer.RenderSquare(x, y, size) :
                                     ShapeRenderer.RenderSquare(x, y, size);

                case DataMarker.Diamond:
                    return rounded ? RoundedShapeRenderer.RenderDiamond(x, y, size) :
                                     ShapeRenderer.RenderDiamond(x, y, size);

                case DataMarker.Triangle:
                    return rounded ? RoundedShapeRenderer.RenderTriangle(x, y, size) :
                                     ShapeRenderer.RenderTriangle(x, y, size);

                case DataMarker.Plus:
                    return rounded ? RoundedShapeRenderer.RenderPlus(x, y, size) :
                                     ShapeRenderer.RenderPlus(x, y, size);

                case DataMarker.Cross:
                    return rounded ? RoundedShapeRenderer.RenderCross(x, y, size) :
                                     ShapeRenderer.RenderCross(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }

        public static string Render(this SeriesMarker symbol, int x, int y, int size, bool rounded)
        {
            switch (symbol)
            {
                case SeriesMarker.Circle:
                    return ShapeRenderer.RenderCircle(x, y, size);

                case SeriesMarker.Square:
                    return rounded ? RoundedShapeRenderer.RenderSquare(x, y, size) :
                                     ShapeRenderer.RenderSquare(x, y, size);

                case SeriesMarker.Diamond:
                    return rounded ? RoundedShapeRenderer.RenderDiamond(x, y, size) :
                                     ShapeRenderer.RenderDiamond(x, y, size);

                case SeriesMarker.Triangle:
                    return rounded ? RoundedShapeRenderer.RenderTriangle(x, y, size) :
                                     ShapeRenderer.RenderTriangle(x, y, size);

                case SeriesMarker.Plus:
                    return rounded ? RoundedShapeRenderer.RenderPlus(x, y, size) :
                                     ShapeRenderer.RenderPlus(x, y, size);

                case SeriesMarker.Cross:
                    return rounded ? RoundedShapeRenderer.RenderCross(x, y, size) : 
                                     ShapeRenderer.RenderCross(x, y, size);

                case SeriesMarker.Slice:
                    return rounded ? RoundedShapeRenderer.RenderSlice(x, y, size) :
                                     ShapeRenderer.RenderSlice(x, y, size);

                case SeriesMarker.Solidline:
                    return rounded ? RoundedShapeRenderer.RenderSolidLine(x, y, size) :
                                     ShapeRenderer.RenderSolidLine(x, y, size);

                case SeriesMarker.Dashedline:
                    return rounded ? RoundedShapeRenderer.RenderDashedLine(x, y, size) :
                                     ShapeRenderer.RenderDashedLine(x, y, size);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
