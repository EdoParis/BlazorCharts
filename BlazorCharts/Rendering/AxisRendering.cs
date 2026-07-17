using BlazorGraphs.Extensions;
using BlazorGraphs.Internal;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Rendering
{
    internal static class AxisRenderer
    {
        private const string CURRENT = "currentColor";

        public static RenderFragment RenderHorizontal(this Axis axis, AxisLayout layout, Theme theme)
        {
            return builder =>
            {
                builder.OpenElement(0, "line");
                builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                builder.AddAttribute(2, "stroke-width", "1px");
                builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                builder.AddAttribute(4, "x1", layout.StartingPoint);
                builder.AddAttribute(5, "x2", layout.EndingPoint);
                builder.AddAttribute(6, "y1", layout.Location);
                builder.AddAttribute(7, "y2", layout.Location);
                builder.CloseElement();

                if (layout.ShowTicks)
                {
                    int t = 0;
                    foreach (Tick tick in axis.Ticks(layout))
                    {
                        builder.OpenElement(2 * t, "line");
                        builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                        builder.AddAttribute(2, "stroke-width", "1px");
                        builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                        builder.AddAttribute(4, "x1", tick.Position);
                        builder.AddAttribute(5, "x2", tick.Position);
                        builder.AddAttribute(6, "y1", layout.IsTickInternal ? (layout.Location - (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)) : layout.Location);
                        builder.AddAttribute(7, "y2", layout.IsTickInternal ? layout.Location : (layout.Location + (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)));
                        builder.CloseElement();

                        if (tick.IsMaster)
                        {
                            builder.OpenElement(2 * t + 1, "text");
                            builder.AddAttribute(1, "x", tick.Position);
                            builder.AddAttribute(2, "y", layout.Location);
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

        public static RenderFragment RenderVertical(this Axis axis, AxisLayout layout, Theme theme)
        {
            return builder =>
            {
                builder.OpenElement(0, "line");
                builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                builder.AddAttribute(2, "stroke-width", "1px");
                builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                builder.AddAttribute(4, "x1", layout.Location);
                builder.AddAttribute(5, "x2", layout.Location);
                builder.AddAttribute(6, "y1", layout.StartingPoint);
                builder.AddAttribute(7, "y2", layout.EndingPoint);
                builder.CloseElement();

                if (layout.ShowTicks)
                {
                    int t = 0;
                    foreach (Tick tick in axis.Ticks(layout))
                    {
                        builder.OpenElement(2 * t, "line");
                        builder.AddAttribute(1, "stroke", theme.AxisColor?.ToHex() ?? CURRENT);
                        builder.AddAttribute(2, "stroke-width", "1px");
                        builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                        builder.AddAttribute(4, "y1", tick.Position);
                        builder.AddAttribute(5, "y2", tick.Position);
                        builder.AddAttribute(6, "x1", layout.IsTickInternal ? layout.Location : (layout.Location - (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)));
                        builder.AddAttribute(7, "x2", layout.IsTickInternal ? (layout.Location + (tick.IsMaster ? layout.TickSize : layout.TickSize / 2)) : layout.Location);
                        builder.CloseElement();

                        if (tick.IsMaster)
                        {
                            builder.OpenElement(2 * t + 1, "text");
                            builder.AddAttribute(1, "x", layout.Location);
                            builder.AddAttribute(2, "y", tick.Position);
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
