using System.Drawing;

namespace BlazorGraphs.Internal
{
    internal abstract class AxisLayout
    {
        public Int32 TickSize { get; protected set; }
        public Boolean IsTickInternal { get; protected set; }
        public Boolean IsLabelInternal { get; protected set; }
        public Boolean ShowStartTick { get; protected set; }
        public Boolean ShowEndTick { get; protected set; }
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

        public abstract AxisLayout At(int loc);

        public abstract AxisLayout From(int starting_point);

        public abstract AxisLayout To(int ending_point);

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
        }
    }
}
