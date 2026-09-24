using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal abstract class AxisLayout
    {
        protected const string CURRENT = "currentColor";
        public Theme Theme { get; private set; }
        public Int32 TickSize { get; private set; }
        public Boolean IsTickInternal { get; private set; }
        public Boolean IsLabelInternal { get; private set; }
        public Boolean ShowStartTick { get; private set; }
        public Boolean ShowEndTick { get; private set; }
        public Boolean ShowTicks { get => TickSize > 0; }

        public Point StartingPoint { get; protected set; }
        public Point EndingPoint { get; protected set; }
        public Double Amplitude { get; protected set; }

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

        public abstract RenderFragment Render(NumericAxis axis);

        public class Horizontal : AxisLayout
        {
            public override Horizontal From(int value)
            {
                StartingPoint = new Point()
                {
                    X = value,
                    Y = StartingPoint.Y
                };
                Amplitude = EndingPoint.X - StartingPoint.X;
                return this;
            }

            public override Horizontal To(int value)
            {
                EndingPoint = new Point()
                {
                    X = value,
                    Y = EndingPoint.Y
                };
                Amplitude = EndingPoint.X - StartingPoint.X;
                return this;
            }

            public override Horizontal At(int value)
            {
                StartingPoint = new Point()
                {
                    X = StartingPoint.X,
                    Y = value
                };
                EndingPoint = new Point()
                {
                    X = EndingPoint.X,
                    Y = value
                };
                return this;
            }

            public override RenderFragment Render(NumericAxis axis)
            {
                return builder =>
                {
                    builder.OpenElement(0, "line");
                    builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(2, "stroke-width", "1px");
                    builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(4, "x1", StartingPoint.X);
                    builder.AddAttribute(5, "y1", StartingPoint.Y);
                    builder.AddAttribute(6, "x2", EndingPoint.X);
                    builder.AddAttribute(7, "y2", EndingPoint.Y);
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        int t = 1;
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
                            builder.AddAttribute(4, "x1", (int)(StartingPoint.X + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(5, "x2", (int)(StartingPoint.X + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(6, "y1", IsTickInternal ? StartingPoint.Y - (tick.IsMaster ? TickSize : TickSize / 2) : StartingPoint.Y);
                            builder.AddAttribute(7, "y2", IsTickInternal ? StartingPoint.Y : StartingPoint.Y + (tick.IsMaster ? TickSize : TickSize / 2));
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(2 * t + 1, "text");
                                builder.AddAttribute(1, "x", (int)(StartingPoint.X + tick.RelativePosition * Amplitude));
                                builder.AddAttribute(2, "y", StartingPoint.Y);
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
            public override Vertical From(int value)
            {
                StartingPoint = new Point()
                {
                    X = StartingPoint.X,
                    Y = value
                };
                Amplitude = EndingPoint.Y - StartingPoint.Y;
                return this;
            }

            public override Vertical To(int value)
            {
                EndingPoint = new Point()
                {
                    X = EndingPoint.X,
                    Y = value
                };
                Amplitude = EndingPoint.Y - StartingPoint.Y;
                return this;
            }

            public override Vertical At(int value)
            {
                StartingPoint = new Point()
                {
                    X = value,
                    Y = StartingPoint.Y
                };
                EndingPoint = new Point()
                {
                    X = value,
                    Y = EndingPoint.Y
                };
                return this;
            }

            public override RenderFragment Render(NumericAxis axis)
            {
                return builder =>
                {
                    builder.OpenElement(0, "line");
                    builder.AddAttribute(1, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(2, "stroke-width", "1px");
                    builder.AddAttribute(3, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(4, "x1", StartingPoint.X);
                    builder.AddAttribute(5, "y1", StartingPoint.Y);
                    builder.AddAttribute(6, "x2", EndingPoint.X);
                    builder.AddAttribute(7, "y2", EndingPoint.Y);
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        int t = 1;
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
                            builder.AddAttribute(4, "y1", (int)(StartingPoint.Y + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(5, "y2", (int)(StartingPoint.Y + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(6, "x1", IsTickInternal ? StartingPoint.X : StartingPoint.X - (tick.IsMaster ? TickSize : TickSize / 2));
                            builder.AddAttribute(7, "x2", IsTickInternal ? StartingPoint.X + (tick.IsMaster ? TickSize : TickSize / 2) : StartingPoint.X);
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(2 * t + 1, "text");
                                builder.AddAttribute(1, "x", StartingPoint.X);
                                builder.AddAttribute(2, "y", (int)(StartingPoint.Y + tick.RelativePosition * Amplitude));
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
            public Int32 EndingAngle { get; protected set; }
            public Int32 StartingAngle { get; protected set; }
            public Boolean IsLargeAngle { get; protected set; }

            public override Circular From(int degree)
            {
                StartingAngle = degree % 360;
                StartingPoint = new Point()
                {
                    X = (int)Math.Round(Center.X - Radius * Math.Cos(Math.PI * StartingAngle / 180)),
                    Y = (int)Math.Round(Center.Y - Radius * Math.Sin(Math.PI * StartingAngle / 180))
                };
                Amplitude = EndingAngle - StartingAngle;
                IsLargeAngle = Math.Abs(Amplitude) > 180;
                return this;
            }

            public override Circular To(int degree)
            {
                EndingAngle = degree % 360;
                EndingPoint = new Point()
                {
                    X = (int)Math.Round(Center.X - Radius * Math.Cos(Math.PI * EndingAngle / 180)),
                    Y = (int)Math.Round(Center.Y - Radius * Math.Sin(Math.PI * EndingAngle / 180))
                };
                Amplitude = EndingAngle - StartingAngle;
                IsLargeAngle = Math.Abs(Amplitude) > 180;
                return this;
            }

            public override Circular At(int loc) => At(new Point(loc, loc));

            public Circular At(Point point)
            {
                Center = point;
                StartingPoint = new Point()
                {
                    X = (int)Math.Round(Center.X - Radius * Math.Cos(Math.PI * StartingAngle / 180)),
                    Y = (int)Math.Round(Center.Y - Radius * Math.Sin(Math.PI * StartingAngle / 180))
                };
                EndingPoint = new Point()
                {
                    X = (int)Math.Round(Center.X - Radius * Math.Cos(Math.PI * EndingAngle / 180)),
                    Y = (int)Math.Round(Center.Y - Radius * Math.Sin(Math.PI * EndingAngle / 180))
                };
                return this;
            }

            public Circular WithRadius(int radius)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(radius, 0);
                Radius = radius;
                StartingPoint = new Point()
                {
                    X = (int)Math.Round(Center.X - Radius * Math.Cos(Math.PI * StartingAngle / 180)),
                    Y = (int)Math.Round(Center.Y - Radius * Math.Sin(Math.PI * StartingAngle / 180))
                };
                EndingPoint = new Point()
                {
                    X = (int)Math.Round(Center.X - Radius * Math.Cos(Math.PI * EndingAngle / 180)),
                    Y = (int)Math.Round(Center.Y - Radius * Math.Sin(Math.PI * EndingAngle / 180))
                };
                return this;
            }

            public override RenderFragment Render(NumericAxis axis)
            {
                return builder =>
                {
                    builder.OpenElement(0, "path");
                    builder.AddAttribute(1, "fill", "none");
                    builder.AddAttribute(2, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(3, "stroke-width", "1px");
                    builder.AddAttribute(4, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(5, "d", $"M {StartingPoint.X} {StartingPoint.Y} A {Radius} {Radius} 0 {(IsLargeAngle ? 1 : 0)} 1 {EndingPoint.X} {EndingPoint.Y}");
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        int t = 1;
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
                            builder.AddAttribute(4, "x1", (int)(Center.X - (IsTickInternal ? Radius - (tick.IsMaster ? TickSize : TickSize / 2) : Radius) * Math.Cos((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.AddAttribute(5, "y1", (int)(Center.Y - (IsTickInternal ? Radius - (tick.IsMaster ? TickSize : TickSize / 2) : Radius) * Math.Sin((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.AddAttribute(6, "x2", (int)(Center.X - (IsTickInternal ? Radius : Radius + (tick.IsMaster ? TickSize : TickSize / 2)) * Math.Cos((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.AddAttribute(7, "y2", (int)(Center.Y - (IsTickInternal ? Radius : Radius + (tick.IsMaster ? TickSize : TickSize / 2)) * Math.Sin((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(2 * t + 1, "text");
                                builder.AddAttribute(1, "x", (int)(Center.X - (IsLabelInternal ? Radius - 3 * TickSize : Radius + 3 * TickSize) * Math.Cos((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                                builder.AddAttribute(2, "y", (int)(Center.Y - (IsLabelInternal ? Radius - 3 * TickSize : Radius + 3 * TickSize) * Math.Sin((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
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
