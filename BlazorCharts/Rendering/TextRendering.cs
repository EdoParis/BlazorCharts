using BlazorGraphs.Extensions;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Rendering
{
    internal static class TextRendering
    {
        private const string CURRENT = "currentColor";

        public static RenderFragment RenderMiddle(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddContent(4, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment RenderStart(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "dx", "0.5em");
                builder.AddAttribute(4, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: start; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment RenderEnd(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "dx", "-0.5em");
                builder.AddAttribute(4, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: end; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment RenderTop(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "dy", "-1em");
                builder.AddAttribute(4, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment RenderBottom(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "dy", "1em");
                builder.AddAttribute(4, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment RenderRotated90(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "dx", "-0.5em");
                builder.AddAttribute(4, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: end; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddAttribute(4, "transform", $"rotate(-90, {x}, {y})");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment RenderRotated270(this string text, int x, int y, int size, Color? color)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", x);
                builder.AddAttribute(2, "y", y);
                builder.AddAttribute(3, "dx", "0.5em");
                builder.AddAttribute(4, "style", $"font-size: {size}px; pointer-events: none; dominant-baseline: central; text-anchor: start; fill: {color?.ToHex() ?? CURRENT};");
                builder.AddAttribute(4, "transform", $"rotate(270, {x}, {y})");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }
    }
}
