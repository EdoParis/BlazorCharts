using BlazorGraphs.Extensions;
using BlazorGraphs.Internal;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Rendering
{
    internal static class AxisRenderer
    {
        private const string CURRENT = "currentColor";

        public static RenderFragment Render(this NumeriAxis axis, AxisLayout layout, Theme theme)
        {
            switch (layout)
            {
                case AxisLayout.Horizontal horizontal_layout:
                    return Render(axis, horizontal_layout, theme);

                case AxisLayout.Vertical vertical_layout:
                    return Render(axis, vertical_layout, theme);

                case AxisLayout.Circular circular_layout:
                    return Render(axis, circular_layout, theme);

                default:
                    throw new ArgumentException(nameof(AxisLayout));
            }
        }

        public static RenderFragment Render(this NumeriAxis axis, AxisLayout.Horizontal layout, Theme theme)
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

        public static RenderFragment Render(this NumeriAxis axis, AxisLayout.Vertical layout, Theme theme)
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

        public static RenderFragment Render(this NumeriAxis axis, AxisLayout.Circular layout, Theme theme)
        {
            return builder =>
            {
                int startpoint_x = (int)Math.Round(layout.Center.X - layout.Radius * Math.Cos(layout.StartingAngle));
                int startpoint_y = (int)Math.Round(layout.Center.Y - layout.Radius * Math.Sin(layout.StartingAngle));
                int endpoint_x = (int)Math.Round(layout.Center.X - layout.Radius * Math.Cos(layout.EndingAngle));
                int endpoint_y = (int)Math.Round(layout.Center.X - layout.Radius * Math.Sin(layout.EndingAngle));

                builder.OpenElement(0, "path");
                builder.AddAttribute(1, "fill", "none");
                builder.AddAttribute(2, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                builder.AddAttribute(3, "stroke-width", "1px");
                builder.AddAttribute(4, "vector-effect", "non-scaling-stroke");
                builder.AddAttribute(5, "d", $"M {startpoint_x} {startpoint_y} A {layout.Radius} {layout.Radius} 0 {(layout.IsLargeAngle ? 1 : 0)} 1 {endpoint_x} {endpoint_y}");
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

                        double degree = layout.StartingAngle + tick.RelativePosition * layout.Amplitude;

                        builder.OpenElement(2 * t, "line");
                        builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                        builder.AddAttribute(2, "stroke-width", "1px");
                        builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                        builder.AddAttribute(4, "x1", (int)(layout.Center.X - (layout.IsTickInternal ? (layout.Radius - (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)) : layout.Radius) * Math.Cos(degree)));
                        builder.AddAttribute(5, "y1", (int)(layout.Center.Y - (layout.IsTickInternal ? (layout.Radius - (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)) : layout.Radius) * Math.Sin(degree)));
                        builder.AddAttribute(6, "x2", (int)(layout.Center.X - (layout.IsTickInternal ? layout.Radius : (layout.Radius + (tick.IsMaster ? layout.TickSize : layout.TickSize / 2))) * Math.Cos(degree)));
                        builder.AddAttribute(7, "y2", (int)(layout.Center.Y - (layout.IsTickInternal ? layout.Radius : (layout.Radius + (tick.IsMaster ? layout.TickSize : layout.TickSize / 2))) * Math.Sin(degree)));
                        builder.CloseElement();

                        if (tick.IsMaster)
                        {
                            builder.OpenElement(2 * t + 1, "text");
                            builder.AddAttribute(1, "x", (int)(layout.Center.X - (layout.IsLabelInternal ? layout.Radius - 3 * layout.TickSize : layout.Radius + 3 * layout.TickSize) * Math.Cos(degree)));
                            builder.AddAttribute(2, "y", (int)(layout.Center.Y - (layout.IsLabelInternal ? layout.Radius - 3 * layout.TickSize : layout.Radius + 3 * layout.TickSize) * Math.Sin(degree)));
                            builder.AddAttribute(3, "style", $"font-size: {2 * layout.TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {theme.TextColor?.ToHex() ?? CURRENT};");
                            builder.AddContent(4, tick.Label);
                            builder.CloseElement();
                        }
                        t++;
                    }
                }
            };
        }
    }
}
