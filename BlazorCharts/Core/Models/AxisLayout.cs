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
                int sequence = 0;
                return builder =>
                {
                    builder.OpenElement(sequence++, "line");
                    builder.AddAttribute(sequence++, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(sequence++, "stroke-width", "1px");
                    builder.AddAttribute(sequence++, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(sequence++, "x1", StartingPoint.X);
                    builder.AddAttribute(sequence++, "y1", StartingPoint.Y);
                    builder.AddAttribute(sequence++, "x2", EndingPoint.X);
                    builder.AddAttribute(sequence++, "y2", EndingPoint.Y);
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        foreach (Tick tick in axis.Ticks())
                        {
                            if (tick.IsStartTick && !ShowStartTick)
                                continue;

                            if (tick.IsEndTick && !ShowEndTick)
                                continue;

                            builder.OpenElement(sequence++, "line");
                            builder.AddAttribute(sequence++, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                            builder.AddAttribute(sequence++, "stroke-width", "1px");
                            builder.AddAttribute(sequence++, "vector-effect", "non-scaling-stroke");
                            builder.AddAttribute(sequence++, "x1", (int)(StartingPoint.X + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(sequence++, "x2", (int)(StartingPoint.X + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(sequence++, "y1", IsTickInternal ? StartingPoint.Y - (tick.IsMaster ? TickSize : TickSize / 2) : StartingPoint.Y);
                            builder.AddAttribute(sequence++, "y2", IsTickInternal ? StartingPoint.Y : StartingPoint.Y + (tick.IsMaster ? TickSize : TickSize / 2));
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(sequence++, "text");
                                builder.AddAttribute(sequence++, "x", (int)(StartingPoint.X + tick.RelativePosition * Amplitude));
                                builder.AddAttribute(sequence++, "y", StartingPoint.Y);
                                builder.AddAttribute(sequence++, "dy", IsLabelInternal ? "-1em" : "1em");
                                builder.AddAttribute(sequence++, "style", $"font-size: {2 * TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                                builder.AddContent(sequence++, tick.Label);
                                builder.CloseElement();
                            }
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
                int sequence = 0;
                return builder =>
                {
                    builder.OpenElement(sequence++, "line");
                    builder.AddAttribute(sequence++, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(sequence++, "stroke-width", "1px");
                    builder.AddAttribute(sequence++, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(sequence++, "x1", StartingPoint.X);
                    builder.AddAttribute(sequence++, "y1", StartingPoint.Y);
                    builder.AddAttribute(sequence++, "x2", EndingPoint.X);
                    builder.AddAttribute(sequence++, "y2", EndingPoint.Y);
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        foreach (Tick tick in axis.Ticks())
                        {
                            if (tick.IsStartTick && !ShowStartTick)
                                continue;

                            if (tick.IsEndTick && !ShowEndTick)
                                continue;

                            builder.OpenElement(sequence++, "line");
                            builder.AddAttribute(sequence++, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                            builder.AddAttribute(sequence++, "stroke-width", "1px");
                            builder.AddAttribute(sequence++, "vector-effect", "non-scaling-stroke");
                            builder.AddAttribute(sequence++, "y1", (int)(StartingPoint.Y + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(sequence++, "y2", (int)(StartingPoint.Y + tick.RelativePosition * Amplitude));
                            builder.AddAttribute(sequence++, "x1", IsTickInternal ? StartingPoint.X : StartingPoint.X - (tick.IsMaster ? TickSize : TickSize / 2));
                            builder.AddAttribute(sequence++, "x2", IsTickInternal ? StartingPoint.X + (tick.IsMaster ? TickSize : TickSize / 2) : StartingPoint.X);
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(sequence++, "text");
                                builder.AddAttribute(sequence++, "x", StartingPoint.X);
                                builder.AddAttribute(sequence++, "y", (int)(StartingPoint.Y + tick.RelativePosition * Amplitude));
                                builder.AddAttribute(sequence++, "dx", IsLabelInternal ? IsTickInternal ? "1em" : "0.5em" : IsTickInternal ? "-0.5em" : "-1em");
                                builder.AddAttribute(sequence++, "style", $"font-size: {2 * TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: {(IsLabelInternal ? "start" : "end")}; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                                builder.AddContent(sequence++, tick.Label);
                                builder.CloseElement();
                            }
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
                int sequence = 0;
                return builder =>
                {
                    builder.OpenElement(sequence++, "path");
                    builder.AddAttribute(sequence++, "fill", "none");
                    builder.AddAttribute(sequence++, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                    builder.AddAttribute(sequence++, "stroke-width", "1px");
                    builder.AddAttribute(sequence++, "vector-effect", "non-scaling-stroke");
                    builder.AddAttribute(sequence++, "d", $"M {StartingPoint.X} {StartingPoint.Y} A {Radius} {Radius} 0 {(IsLargeAngle ? 1 : 0)} 1 {EndingPoint.X} {EndingPoint.Y}");
                    builder.CloseElement();

                    if (ShowTicks)
                    {
                        foreach (Tick tick in axis.Ticks())
                        {
                            if (tick.IsStartTick && !ShowStartTick)
                                continue;

                            if (tick.IsEndTick && !ShowEndTick)
                                continue;

                            builder.OpenElement(sequence++, "line");
                            builder.AddAttribute(sequence++, "stroke", Theme.AxisColor?.ToHex() ?? CURRENT);
                            builder.AddAttribute(sequence++, "stroke-width", "1px");
                            builder.AddAttribute(sequence++, "vector-effect", "non-scaling-stroke");
                            builder.AddAttribute(sequence++, "x1", (int)(Center.X - (IsTickInternal ? Radius - (tick.IsMaster ? TickSize : TickSize / 2) : Radius) * Math.Cos((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.AddAttribute(sequence++, "y1", (int)(Center.Y - (IsTickInternal ? Radius - (tick.IsMaster ? TickSize : TickSize / 2) : Radius) * Math.Sin((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.AddAttribute(sequence++, "x2", (int)(Center.X - (IsTickInternal ? Radius : Radius + (tick.IsMaster ? TickSize : TickSize / 2)) * Math.Cos((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.AddAttribute(sequence++, "y2", (int)(Center.Y - (IsTickInternal ? Radius : Radius + (tick.IsMaster ? TickSize : TickSize / 2)) * Math.Sin((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                            builder.CloseElement();

                            if (tick.IsMaster)
                            {
                                builder.OpenElement(sequence++, "text");
                                builder.AddAttribute(sequence++, "x", (int)(Center.X - (IsLabelInternal ? Radius - 3 * TickSize : Radius + 3 * TickSize) * Math.Cos((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                                builder.AddAttribute(sequence++, "y", (int)(Center.Y - (IsLabelInternal ? Radius - 3 * TickSize : Radius + 3 * TickSize) * Math.Sin((StartingAngle + tick.RelativePosition * Amplitude) / 180 * Math.PI)));
                                builder.AddAttribute(sequence++, "style", $"font-size: {2 * TickSize}px; pointer-events: none; dominant-baseline: central; text-anchor: middle; fill: {Theme.TextColor?.ToHex() ?? CURRENT};");
                                builder.AddContent(sequence++, tick.Label);
                                builder.CloseElement();
                            }
                        }
                    }
                };
            }
        }
    }
}
