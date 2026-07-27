using BlazorGraphs.Internal;
using BlazorGraphs.Extensions;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Rendering
{
    internal static class TextRendering
    {
        private const string CURRENT = "currentColor";

        public static RenderFragment Render(this string text, TextLayout layout, Theme theme)
        {
            switch (layout)
            {
                case TextLayout.Middle middle_layout:
                    return Render(text, middle_layout, theme);

                case TextLayout.Bottom bottom_layout:
                    return Render(text, bottom_layout, theme);

                case TextLayout.Start start_layout:
                    return Render(text, start_layout, theme);

                case TextLayout.End end_layout:
                    return Render(text, end_layout, theme);

                case TextLayout.Top top_layout:
                    return Render(text, top_layout, theme);

                case TextLayout.VerticalTop topvertical_layout:
                    return Render(text, topvertical_layout, theme);

                case TextLayout.VerticalBottom bottomvertical_layout:
                    return Render(text, bottomvertical_layout, theme);

                default:
                    throw new ArgumentException(nameof(TextLayout));
            }
        }

        public static RenderFragment Render(this string text, TextLayout.Middle layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddContent(4, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment Render(this string text, TextLayout.Bottom layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "dy", "1em");
                builder.AddAttribute(4, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment Render(this string text, TextLayout.Start layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "dx", "0.5em");
                builder.AddAttribute(4, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: start; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment Render(this string text, TextLayout.Top layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "dy", "-1em");
                builder.AddAttribute(4, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment Render(this string text, TextLayout.End layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "dx", "-0.5em");
                builder.AddAttribute(4, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: end; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment Render(this string text, TextLayout.VerticalBottom layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "dx", "-0.5em");
                builder.AddAttribute(4, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: end; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddAttribute(4, "transform", $"rotate(-90, {layout.Location.X}, {layout.Location.Y})");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }

        public static RenderFragment Render(this string text, TextLayout.VerticalTop layout, Theme theme)
        {
            return builder =>
            {
                if (string.IsNullOrWhiteSpace(text))
                    return;

                builder.OpenElement(0, "text");
                builder.AddAttribute(1, "x", layout.Location.X);
                builder.AddAttribute(2, "y", layout.Location.Y);
                builder.AddAttribute(3, "dx", "0.5em");
                builder.AddAttribute(4, "style", $"font-size: {layout.Size}px; pointer-events: none; dominant-baseline: central; text-anchor: start; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                builder.AddAttribute(4, "transform", $"rotate(270, {layout.Location.X}, {layout.Location.Y})");
                builder.AddContent(5, text);
                builder.CloseElement();
            };
        }
    }
}
