using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal abstract class MarkerLayout
    {
        public Color Color { get; private set; }

        public MarkerLayout WithColor(Color color)
        {
            Color = color;
            return this;
        }

        public static Square SquareLayout()
        {
            return new Square();
        }

        public static Circle CircleLayout()
        {
            return new Circle();
        }

        public static Slice SliceLayout()
        {
            return new Slice();
        }

        public abstract RenderFragment Render();

        public class Square : MarkerLayout
        {
            public override RenderFragment Render()
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
                    builder.AddAttribute(9, "fill", Color.ToHex());
                    builder.CloseElement();
                    builder.CloseElement();
                };
            }
        }

        public class Circle : MarkerLayout
        {
            public override RenderFragment Render()
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
                    builder.AddAttribute(9, "fill", Color.ToHex());
                    builder.CloseElement();
                    builder.CloseElement();
                };
            }
        }

        public class Slice : MarkerLayout
        {
            public override RenderFragment Render()
            {
                return builder =>
                {
                    builder.OpenElement(0, "svg");
                    builder.AddAttribute(1, "width", "1.5em");
                    builder.AddAttribute(2, "height", "1em");
                    builder.AddAttribute(3, "viewBox", "0 0 15 10");
                    builder.OpenElement(4, "path");
                    builder.AddAttribute(5, "d", "M 1 9 L 1 1 A 8 8 0 0 1 9 9 Z");
                    builder.AddAttribute(6, "fill", Color.ToHex());
                    builder.CloseElement();
                    builder.CloseElement();
                };
            }
        }
    }
}
