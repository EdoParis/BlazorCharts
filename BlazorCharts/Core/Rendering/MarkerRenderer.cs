using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal class MarkerRenderer
    {
        public RenderFragment Render(Marker marker)
        {
            switch (marker.Shape)
            {
                case MarkerShapes.Circle:
                    return RenderCircle(marker.Color);

                case MarkerShapes.Square:
                    return RenderSquare(marker.Color);

                case MarkerShapes.Slice:
                    return RenderSlice(marker.Color);

                case MarkerShapes.Segment:
                    return RenderSegment(marker.Color);

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
                builder.AddAttribute(6, "cy", 4);
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
                builder.OpenElement(4, "rect");
                builder.AddAttribute(5, "x", 1);
                builder.AddAttribute(6, "y", 3);
                builder.AddAttribute(7, "width", 8);
                builder.AddAttribute(8, "height", 2);
                builder.AddAttribute(9, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }
    }
}
