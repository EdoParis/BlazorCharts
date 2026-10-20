using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal class MarkerRenderer
    {
        public RenderFragment Render(Marker marker) => Render(marker.Shape, marker.Color);

        public RenderFragment Render(MarkerShapes shape, Color color)
        {
            switch (shape)
            {
                case MarkerShapes.Circle:
                    return RenderCircle(color);

                case MarkerShapes.Square:
                    return RenderSquare(color);

                case MarkerShapes.Triangle:
                    return RenderTriangle(color);

                case MarkerShapes.Dashed:
                    return RenderDashed(color);

                case MarkerShapes.Segment:
                    return RenderSegment(color);

                case MarkerShapes.Diamond:
                    return RenderDiamond(color);

                case MarkerShapes.Droplet:
                    return RenderDroplet(color);

                case MarkerShapes.Slice:
                    return RenderSlice(color);

                default:
                    throw new NotImplementedException();
            }
        }

        public RenderFragment RenderCircle(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "circle");
                builder.AddAttribute(5, "cx", 5);
                builder.AddAttribute(6, "cy", 5);
                builder.AddAttribute(7, "r", 4);
                builder.AddAttribute(9, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderSquare(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "rect");
                builder.AddAttribute(5, "x", 1);
                builder.AddAttribute(6, "y", 1);
                builder.AddAttribute(7, "width", 8);
                builder.AddAttribute(8, "height", 8);
                builder.AddAttribute(9, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderSlice(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "path");
                builder.AddAttribute(5, "d", "M 1 9 L 1 1 A 8 8 0 0 1 9 9 Z");
                builder.AddAttribute(6, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderSegment(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "path");
                builder.AddAttribute(5, "d", "M 0 4 L 9 4 L 9 6 L 0 6 Z");
                builder.AddAttribute(6, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderDashed(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "path");
                builder.AddAttribute(5, "d", "M 0 4 L 4 4 L 4 6 L 0 6 L 0 4 M 5 4 L 9 4 L 9 6 L 5 6 L 5 4");
                builder.AddAttribute(6, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderTriangle(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "path");
                builder.AddAttribute(5, "d", "M 0 9 L 4.5 1 L 9 9 Z");
                builder.AddAttribute(6, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderDiamond(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "path");
                builder.AddAttribute(5, "d", "M 0.5 5 L 5 0.5 L 9.5 5 L 5 9.5 Z");
                builder.AddAttribute(6, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderDroplet(Color color)
        {
            return builder =>
            {
                builder.OpenElement(0, "svg");
                builder.AddAttribute(1, "width", "1.5em");
                builder.AddAttribute(2, "height", "1em");
                builder.AddAttribute(3, "viewBox", "0 0 15 10");
                builder.OpenElement(4, "path");
                builder.AddAttribute(5, "d", "M 2 5 L 5 0 L 8 5 A 3 3 0 0 1 5 9 A 3 3 0 0 1 2 5 ");
                builder.AddAttribute(6, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }
    }
}
