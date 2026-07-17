using BlazorGraphs.Extensions;
using BlazorGraphs.Internal;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Rendering
{
    internal static class AxisRenderer
    {
        private const string CURRENT = "currentColor";

        public static RenderFragment Render(this Axis axis, AxisLayout layout, Theme theme)
        {
            switch (layout)
            {
                case AxisLayout.Horizontal horizontal_layout:
                    return Render(axis, horizontal_layout, theme);

                case AxisLayout.Vertical vertical_layout:
                    return Render(axis, vertical_layout, theme);

                default:
                    throw new ArgumentException(nameof(AxisLayout));
            }
        }

        public static RenderFragment Render(this Axis axis, AxisLayout.Horizontal layout, Theme theme)
        {
            return builder =>
            {
                builder.OpenElement(0, "line");
                builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                builder.AddAttribute(2, "stroke-width", "1px");
                builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                builder.AddAttribute(4, "x1", layout.HorizontalStartingPoint);
                builder.AddAttribute(5, "x2", layout.HorizontalEndingPoint);
                builder.AddAttribute(6, "y1", layout.VerticalLocation);
                builder.AddAttribute(7, "y2", layout.VerticalLocation);
                builder.CloseElement();

                if (layout.ShowTicks)
                {
                    int t = 0;
                    foreach (Tick tick in axis.Ticks())
                    {
                        if (tick.IsStartTick && !layout.ShowStartTick)
                            continue;

                        if (tick.IsEndTick && !layout.ShowEndTick)
                            continue;

                        builder.OpenElement(2 * t, "line");
                        builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                        builder.AddAttribute(2, "stroke-width", "1px");
                        builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                        builder.AddAttribute(4, "x1", (int)(layout.HorizontalStartingPoint + tick.RelativePosition * layout.Lenght));
                        builder.AddAttribute(5, "x2", (int)(layout.HorizontalStartingPoint + tick.RelativePosition * layout.Lenght));
                        builder.AddAttribute(6, "y1", layout.IsTickInternal ? (layout.VerticalLocation - (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)) : layout.VerticalLocation);
                        builder.AddAttribute(7, "y2", layout.IsTickInternal ? layout.VerticalLocation : (layout.VerticalLocation + (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)));
                        builder.CloseElement();

                        if (tick.IsMaster)
                        {
                            builder.OpenElement(2 * t + 1, "text");
                            builder.AddAttribute(1, "x", (int)(layout.HorizontalStartingPoint + tick.RelativePosition * layout.Lenght));
                            builder.AddAttribute(2, "y", layout.VerticalLocation);
                            builder.AddAttribute(3, "dy", layout.IsLabelInternal ? "-1em" : "1em");
                            builder.AddAttribute(4, "style", $"font-size: {2 * layout.TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                            builder.AddContent(5, tick.Label);
                            builder.CloseElement();
                        }
                        t++;
                    }
                }
            };
        }

        public static RenderFragment Render(this Axis axis, AxisLayout.Vertical layout, Theme theme)
        {
            return builder =>
            {
                builder.OpenElement(0, "line");
                builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                builder.AddAttribute(2, "stroke-width", "1px");
                builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                builder.AddAttribute(4, "x1", layout.HorizontalLocation);
                builder.AddAttribute(5, "x2", layout.HorizontalLocation);
                builder.AddAttribute(6, "y1", layout.VerticalStartingPoint);
                builder.AddAttribute(7, "y2", layout.VerticalEndingPoint);
                builder.CloseElement();

                if (layout.ShowTicks)
                {
                    int t = 0;
                    foreach (Tick tick in axis.Ticks())
                    {
                        if (tick.IsStartTick && !layout.ShowStartTick)
                            continue;

                        if (tick.IsEndTick && !layout.ShowEndTick)
                            continue;

                        builder.OpenElement(2 * t, "line");
                        builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                        builder.AddAttribute(2, "stroke-width", "1px");
                        builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                        builder.AddAttribute(4, "y1", (int)(layout.VerticalStartingPoint + tick.RelativePosition * layout.Lenght));
                        builder.AddAttribute(5, "y2", (int)(layout.VerticalStartingPoint + tick.RelativePosition * layout.Lenght));
                        builder.AddAttribute(6, "x1", layout.IsTickInternal ? layout.HorizontalLocation : (layout.HorizontalLocation - (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)));
                        builder.AddAttribute(7, "x2", layout.IsTickInternal ? (layout.HorizontalLocation + (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)) : layout.HorizontalLocation);
                        builder.CloseElement();

                        if (tick.IsMaster)
                        {
                            builder.OpenElement(2 * t + 1, "text");
                            builder.AddAttribute(1, "x", layout.HorizontalLocation);
                            builder.AddAttribute(2, "y", (int)(layout.VerticalStartingPoint + tick.RelativePosition * layout.Lenght));
                            builder.AddAttribute(3, "dx", layout.IsLabelInternal ? layout.IsTickInternal ? "1em" : "0.5em" : layout.IsTickInternal ? "-0.5em" : "-1em");
                            builder.AddAttribute(4, "style", $"font-size: {2 * layout.TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: {(layout.IsLabelInternal ? "start" : "end")}; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                            builder.AddContent(5, tick.Label);
                            builder.CloseElement();
                        }
                        t++;
                    }
                }
            };
        }
    }
}
