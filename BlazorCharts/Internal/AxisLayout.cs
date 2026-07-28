using BlazorGraphs.Structures;
using BlazorGraphs.Extensions;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Internal
{
    internal abstract class AxisLayout
    {
        protected const string CURRENT = "currentColor";
        public Int32 TickSize { get; private set; }
        public Theme Theme { get; private set; }
        public Boolean IsTickInternal { get; private set; }
        public Boolean IsLabelInternal { get; private set; }
        public Boolean ShowStartTick { get; private set; }
        public Boolean ShowEndTick { get; private set; }
        public Boolean ShowTicks { get => TickSize > 0; }

        public AxisLayout()
        {
            ShowStartTick = true;
            ShowEndTick = true;
        }

        public static Horizontal HorizontalLayout()
        {
            return new Horizontal();
        }

        public static Vertical VerticalLayout()
        {
            return new Vertical();
        }

        public static Circular CircularLayout()
        {
            return new Circular();
        }

        public AxisLayout FullInternal()
        {
            IsTickInternal = true;
            IsLabelInternal = true;
            return this;
        }

        public AxisLayout FullExternal()
        {
            IsTickInternal = false;
            IsLabelInternal = false;
            return this;
        }

        public AxisLayout TicksInternal()
        {
            IsTickInternal = true;
            IsLabelInternal = false;
            return this;
        }

        public AxisLayout LabelsInternal()
        {
            IsTickInternal = false;
            IsLabelInternal = true;
            return this;
        }

        public AxisLayout WithoutStartTick()
        {
            ShowStartTick = false;
            return this;
        }

        public AxisLayout WithoutEndTick()
        {
            ShowEndTick = false;
            return this;
        }

        public AxisLayout WithStartTick()
        {
            ShowStartTick = true;
            return this;
        }

        public AxisLayout WithEndTick()
        {
            ShowEndTick = true;
            return this;
        }

        public AxisLayout WithTickSize(int tick_size)
        {
            TickSize = tick_size;
            return this;
        }

        public AxisLayout WithTheme(Theme theme)
        {
            Theme = theme;
            return this;
        }

        public abstract AxisLayout At(int loc);

        public abstract AxisLayout From(int starting_point);

        public abstract AxisLayout To(int ending_point);

        public abstract RenderFragment Render(NumeriAxis axis);

        public class Horizontal : AxisLayout
        {
            public Int32 VerticalLocation { get; protected set; }
            public Int32 HorizontalEndingPoint { get; protected set; }
            public Int32 HorizontalStartingPoint { get; protected set; }
            public Int32 Lenght { get => HorizontalEndingPoint - HorizontalStartingPoint; }

            public override Horizontal From(int starting_point)
            {
                HorizontalStartingPoint = starting_point;
                return this;
            }

            public override Horizontal To(int ending_point)
            {
                HorizontalEndingPoint = ending_point;
                return this;
            }

            public override Horizontal At(int location)
            {
                VerticalLocation = location;
                return this;
            }

            public override RenderFragment Render(NumeriAxis axis)
            {
                return builder =>
                {
                    builder.OpenElement(0, "line");
                    builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(2, "stroke-width", "1px");
                    builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(4, "x1", HorizontalStartingPoint);
                    builder.AddAttribute(5, "x2", HorizontalEndingPoint);
                    builder.AddAttribute(6, "y1", VerticalLocation);
                    builder.AddAttribute(7, "y2", VerticalLocation);
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        int t = 0;
                        foreach (Tick tick in axis.Ticks())
                        {
                            if (tick.IsStartTick && !ShowStartTick)
                                continue;

                            if (tick.IsEndTick && !ShowEndTick)
                                continue;

                            builder.OpenElement(2 * t, "line");
                            builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                            builder.AddAttribute(2, "stroke-width", "1px");
                            builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                            builder.AddAttribute(4, "x1", (int)(HorizontalStartingPoint + tick.RelativePosition * Lenght));
                            builder.AddAttribute(5, "x2", (int)(HorizontalStartingPoint + tick.RelativePosition * Lenght));
                            builder.AddAttribute(6, "y1", IsTickInternal ? (VerticalLocation - (tick.IsMaster ? TickSize : TickSize / 2)) : VerticalLocation);
                            builder.AddAttribute(7, "y2", IsTickInternal ? VerticalLocation : (VerticalLocation + (tick.IsMaster ? TickSize : TickSize / 2)));
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(2 * t + 1, "text");
                                builder.AddAttribute(1, "x", (int)(HorizontalStartingPoint + tick.RelativePosition * Lenght));
                                builder.AddAttribute(2, "y", VerticalLocation);
                                builder.AddAttribute(3, "dy", IsLabelInternal ? "-1em" : "1em");
                                builder.AddAttribute(4, "style", $"font-size: {2 * TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                                builder.AddContent(5, tick.Label);
                                builder.CloseElement();
                            }
                            t++;
                        }
                    }
                };
            }
        }

        public class Vertical : AxisLayout
        {
            public Int32 HorizontalLocation { get; protected set; }
            public Int32 VerticalEndingPoint { get; protected set; }
            public Int32 VerticalStartingPoint { get; protected set; }
            public Int32 Lenght { get => VerticalEndingPoint - VerticalStartingPoint; }

            public override Vertical From(int starting_point)
            {
                VerticalStartingPoint = starting_point;
                return this;
            }

            public override Vertical To(int ending_point)
            {
                VerticalEndingPoint = ending_point;
                return this;
            }

            public override Vertical At(int location)
            {
                HorizontalLocation = location;
                return this;
            }

            public override RenderFragment Render(NumeriAxis axis)
            {
                return builder =>
                {
                    builder.OpenElement(0, "line");
                    builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(2, "stroke-width", "1px");
                    builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(4, "x1", HorizontalLocation);
                    builder.AddAttribute(5, "x2", HorizontalLocation);
                    builder.AddAttribute(6, "y1", VerticalStartingPoint);
                    builder.AddAttribute(7, "y2", VerticalEndingPoint);
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        int t = 0;
                        foreach (Tick tick in axis.Ticks())
                        {
                            if (tick.IsStartTick && !ShowStartTick)
                                continue;

                            if (tick.IsEndTick && !ShowEndTick)
                                continue;

                            builder.OpenElement(2 * t, "line");
                            builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                            builder.AddAttribute(2, "stroke-width", "1px");
                            builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                            builder.AddAttribute(4, "y1", (int)(VerticalStartingPoint + tick.RelativePosition * Lenght));
                            builder.AddAttribute(5, "y2", (int)(VerticalStartingPoint + tick.RelativePosition * Lenght));
                            builder.AddAttribute(6, "x1", IsTickInternal ? HorizontalLocation : (HorizontalLocation - (tick.IsMaster ? TickSize : TickSize / 2)));
                            builder.AddAttribute(7, "x2", IsTickInternal ? (HorizontalLocation + (tick.IsMaster ? TickSize : TickSize / 2)) : HorizontalLocation);
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(2 * t + 1, "text");
                                builder.AddAttribute(1, "x", HorizontalLocation);
                                builder.AddAttribute(2, "y", (int)(VerticalStartingPoint + tick.RelativePosition * Lenght));
                                builder.AddAttribute(3, "dx", IsLabelInternal ? IsTickInternal ? "1em" : "0.5em" : IsTickInternal ? "-0.5em" : "-1em");
                                builder.AddAttribute(4, "style", $"font-size: {2 * TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: {(IsLabelInternal ? "start" : "end")}; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                                builder.AddContent(5, tick.Label);
                                builder.CloseElement();
                            }
                            t++;
                        }
                    }
                };
            }
        }

        public class Circular : AxisLayout
        {
            public Point Center { get; protected set; }
            public Int32 Radius { get; protected set; }
            public Double EndingAngle { get; protected set; }
            public Double StartingAngle { get; protected set; }
            public Double Amplitude { get => EndingAngle - StartingAngle; }
            public Boolean IsLargeAngle { get => Math.Abs(EndingAngle - StartingAngle) > Math.PI; }

            public override Circular From(int starting_degree)
            {
                StartingAngle = starting_degree % 360 * Math.PI / 180;
                return this;
            }

            public override Circular To(int ending_degree)
            {
                EndingAngle = ending_degree % 360 * Math.PI / 180;
                return this;
            }

            public override Circular At(int loc)
            {
                Center = new Point(loc, loc);
                return this;
            }

            public Circular At(Point point)
            {
                Center = point;
                return this;
            }

            public Circular WithRadius(int radius)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(radius, 0);
                Radius = radius;
                return this;
            }

            public override RenderFragment Render(NumeriAxis axis)
            {
                return builder =>
                {
                    int startpoint_x = (int)Math.Round(Center.X - Radius * Math.Cos(StartingAngle));
                    int startpoint_y = (int)Math.Round(Center.Y - Radius * Math.Sin(StartingAngle));
                    int endpoint_x = (int)Math.Round(Center.X - Radius * Math.Cos(EndingAngle));
                    int endpoint_y = (int)Math.Round(Center.X - Radius * Math.Sin(EndingAngle));

                    builder.OpenElement(0, "path");
                    builder.AddAttribute(1, "fill", "none");
                    builder.AddAttribute(2, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(3, "stroke-width", "1px");
                    builder.AddAttribute(4, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(5, "d", $"M {startpoint_x} {startpoint_y} A {Radius} {Radius} 0 {(IsLargeAngle ? 1 : 0)} 1 {endpoint_x} {endpoint_y}");
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        int t = 0;
                        foreach (Tick tick in axis.Ticks())
                        {
                            if (tick.IsStartTick && !ShowStartTick)
                                continue;

                            if (tick.IsEndTick && !ShowEndTick)
                                continue;

                            double degree = StartingAngle + tick.RelativePosition * Amplitude;

                            builder.OpenElement(2 * t, "line");
                            builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                            builder.AddAttribute(2, "stroke-width", "1px");
                            builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                            builder.AddAttribute(4, "x1", (int)(Center.X - (IsTickInternal ? (Radius - (tick.IsMaster ? TickSize : TickSize / 2)) : Radius) * Math.Cos(degree)));
                            builder.AddAttribute(5, "y1", (int)(Center.Y - (IsTickInternal ? (Radius - (tick.IsMaster ? TickSize : TickSize / 2)) : Radius) * Math.Sin(degree)));
                            builder.AddAttribute(6, "x2", (int)(Center.X - (IsTickInternal ? Radius : (Radius + (tick.IsMaster ? TickSize : TickSize / 2))) * Math.Cos(degree)));
                            builder.AddAttribute(7, "y2", (int)(Center.Y - (IsTickInternal ? Radius : (Radius + (tick.IsMaster ? TickSize : TickSize / 2))) * Math.Sin(degree)));
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(2 * t + 1, "text");
                                builder.AddAttribute(1, "x", (int)(Center.X - (IsLabelInternal ? Radius - 3 * TickSize : Radius + 3 * TickSize) * Math.Cos(degree)));
                                builder.AddAttribute(2, "y", (int)(Center.Y - (IsLabelInternal ? Radius - 3 * TickSize : Radius + 3 * TickSize) * Math.Sin(degree)));
                                builder.AddAttribute(3, "style", $"font-size: {2 * TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
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
}
