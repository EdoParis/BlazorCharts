using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal abstract class TextLayout
    {
        protected const string CURRENT = "currentColor";
        public int Size { get; private set; }
        public Theme Theme { get; private set; }
        public Point Location { get; private set; }

        public static End EndLayout() => new End();
        public static Top TopLayout() => new Top();
        public static Middle MiddleLayout() => new Middle();
        public static Bottom BottomLayout() => new Bottom();
        public static Start StartLayout() => new Start();
        public static VerticalTop VerticalTopLayout() => new VerticalTop();
        public static VerticalBottom VerticalBottomLayout() => new VerticalBottom();

        public TextLayout Small() => WithSize(20);
        public TextLayout Medium() => WithSize(40);
        public TextLayout Large() => WithSize(100);
        public TextLayout WithSize(int size)
        {
            Size = size;
            return this;
        }

        public TextLayout WithTheme(Theme theme)
        {
            Theme = theme;
            return this;
        }

        public TextLayout At(int x, int y) => At(new Point(x, y));
        public TextLayout At(Point p)
        {
            Location = p;
            return this;
        }

        public RenderFragment Render(double value) => Render(value.ToString("0.##"));

        public abstract RenderFragment Render(string text);

        public class Middle : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddContent(4, text);
                    builder.CloseElement();
                };
            }
        }

        public class Start : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "dx", "0.5em");
                    builder.AddAttribute(4, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: start; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddContent(5, text);
                    builder.CloseElement();
                };
            }
        }

        public class End : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "dx", "-0.5em");
                    builder.AddAttribute(4, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: end; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddContent(5, text);
                    builder.CloseElement();
                };
            }
        }

        public class Top : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "dy", "-1em");
                    builder.AddAttribute(4, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddContent(5, text);
                    builder.CloseElement();
                };
            }
        }

        public class Bottom : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "dy", "1em");
                    builder.AddAttribute(4, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddContent(5, text);
                    builder.CloseElement();
                };
            }
        }

        public class VerticalTop : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "dx", "0.5em");
                    builder.AddAttribute(4, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: start; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddAttribute(5, "transform", $"rotate(270, {Location.X}, {Location.Y})");
                    builder.AddContent(6, text);
                    builder.CloseElement();
                };
            }
        }

        public class VerticalBottom : TextLayout
        {
            public override RenderFragment Render(string text)
            {
                return builder =>
                {
                    if (string.IsNullOrWhiteSpace(text))
                        return;

                    builder.OpenElement(0, "text");
                    builder.AddAttribute(1, "x", Location.X);
                    builder.AddAttribute(2, "y", Location.Y);
                    builder.AddAttribute(3, "dx", "-0.5em");
                    builder.AddAttribute(4, "style", $"font-size: {Size}px; pointer-events: none; dominant-baseline: central; text-anchor: end; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                    builder.AddAttribute(5, "transform", $"rotate(-90, {Location.X}, {Location.Y})");
                    builder.AddContent(6, text);
                    builder.CloseElement();
                };
            }
        }
    }
}
