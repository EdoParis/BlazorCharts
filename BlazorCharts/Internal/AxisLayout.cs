namespace BlazorGraphs.Internal
{
    internal abstract class AxisLayout
    {
        public int TickSize { get; protected set; }
        public bool IsTickInternal { get; protected set; }
        public bool IsLabelInternal { get; protected set; }
        public bool ShowStartTick { get; protected set; }
        public bool ShowEndTick { get; protected set; }
        public bool ShowTicks { get => TickSize > 0; }

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
            public int VerticalLocation { get; protected set; }
            public int HorizontalEndingPoint { get; protected set; }
            public int HorizontalStartingPoint { get; protected set; }
            public int Lenght { get => HorizontalEndingPoint - HorizontalStartingPoint; }

            public override AxisLayout From(int starting_point)
            {
                HorizontalStartingPoint = starting_point;
                return this;
            }

            public override AxisLayout To(int ending_point)
            {
                HorizontalEndingPoint = ending_point;
                return this;
            }

            public override AxisLayout At(int location)
            {
                VerticalLocation = location;
                return this;
            }
        }

        public class Vertical : AxisLayout
        {
            public int HorizontalLocation { get; protected set; }
            public int VerticalEndingPoint { get; protected set; }
            public int VerticalStartingPoint { get; protected set; }
            public int Lenght { get => VerticalEndingPoint - VerticalStartingPoint; }

            public override AxisLayout From(int starting_point)
            {
                VerticalStartingPoint = starting_point;
                return this;
            }

            public override AxisLayout To(int ending_point)
            {
                VerticalEndingPoint = ending_point;
                return this;
            }

            public override AxisLayout At(int location)
            {
                HorizontalLocation = location;
                return this;
            }
        }
    }
}
