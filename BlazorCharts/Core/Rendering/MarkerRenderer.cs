using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal class MarkerRenderer
    {
        public RenderFragment Render(Marker marker) => Render(marker.Symbol, marker.Color);

        public RenderFragment Render(MarkerSymbol symbol, Color color)
        {
            switch (symbol)
            {
                case MarkerSymbol.Circle:
                    return RenderCircle(color);

                case MarkerSymbol.Square:
                    return RenderSquare(color);

                case MarkerSymbol.Triangle:
                    return RenderTriangle(color);

                case MarkerSymbol.Dashedline:
                    return RenderDashed(color);

                case MarkerSymbol.Solidline:
                    return RenderSegment(color);

                case MarkerSymbol.Diamond:
                    return RenderDiamond(color);

                case MarkerSymbol.Droplet:
                    return RenderDroplet(color);

                case MarkerSymbol.Slice:
                    return RenderSlice(color);

                default:
                    throw new NotImplementedException();
            }
        }

        public RenderFragment RenderCircle(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "circle");
                builder.AddAttribute(sequence++, "cx", 5);
                builder.AddAttribute(sequence++, "cy", 5);
                builder.AddAttribute(sequence++, "r", 4);
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderSquare(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "rect");
                builder.AddAttribute(sequence++, "x", 1);
                builder.AddAttribute(sequence++, "y", 1);
                builder.AddAttribute(sequence++, "width", 8);
                builder.AddAttribute(sequence++, "height", 8);
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderSlice(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "path");
                builder.AddAttribute(sequence++, "d", "M 1 9 L 1 1 A 8 8 0 0 1 9 9 Z");
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderSegment(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "path");
                builder.AddAttribute(sequence++, "d", "M 0 4 L 9 4 L 9 6 L 0 6 Z");
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderDashed(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "path");
                builder.AddAttribute(sequence++, "d", "M 0 4 L 4 4 L 4 6 L 0 6 L 0 4 M 5 4 L 9 4 L 9 6 L 5 6 L 5 4");
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderTriangle(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "path");
                builder.AddAttribute(sequence++, "d", "M 0 9 L 4.5 1 L 9 9 Z");
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderDiamond(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "path");
                builder.AddAttribute(sequence++, "d", "M 0.5 5 L 5 0.5 L 9.5 5 L 5 9.5 Z");
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }

        public RenderFragment RenderDroplet(Color color)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "svg");
                builder.AddAttribute(sequence++, "width", "1.5em");
                builder.AddAttribute(sequence++, "height", "1em");
                builder.AddAttribute(sequence++, "viewBox", "0 0 15 10");
                builder.OpenElement(sequence++, "path");
                builder.AddAttribute(sequence++, "d", "M 2 5 L 5 0 L 8 5 A 3 3 0 0 1 5 9 A 3 3 0 0 1 2 5 ");
                builder.AddAttribute(sequence++, "fill", color.ToHex());
                builder.CloseElement();
                builder.CloseElement();
            };
        }
    }
}
