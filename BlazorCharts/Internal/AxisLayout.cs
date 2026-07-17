namespace BlazorGraphs.Internal
{
    internal class AxisLayout
    {
        private Func<int> location_delegate;
        public int Location { get => location_delegate is null ? default : location_delegate(); }
        public int TickSize { get; private set; }
        public int EndingPoint { get; private set; }
        public int StartingPoint { get; private set; }
        public bool IsTickInternal { get; private set; }
        public bool IsLabelInternal { get; private set; }
        public bool ShowTicks { get => TickSize > 0; }

        public static AxisLayout FullInternal()
        {
            return new AxisLayout()
            {
                TickSize = 0,
                IsTickInternal = true,
                IsLabelInternal = true,
            };
        }

        public static AxisLayout FullExternal()
        {
            return new AxisLayout()
            {
                TickSize = 0,
                IsTickInternal = false,
                IsLabelInternal = false,
            };
        }

        public static AxisLayout TicksInternal()
        {
            return new AxisLayout()
            {
                TickSize = 0,
                IsTickInternal = true,
                IsLabelInternal = false,
            };
        }

        public static AxisLayout LabelsInternal()
        {
            return new AxisLayout()
            {
                TickSize = 0,
                IsTickInternal = false,
                IsLabelInternal = true,
            };
        }

        public AxisLayout WithTickSize(int tick_size)
        {
            TickSize = tick_size;
            return this;
        }

        public AxisLayout From(int starting_point)
        {
            StartingPoint = starting_point;
            return this;
        }

        public AxisLayout To(int ending_point)
        {
            EndingPoint = ending_point;
            return this;
        }

        public AxisLayout At(int location)
        {
            location_delegate = () => location;
            return this;
        }

        public AxisLayout At(Func<int> loc_delegate)
        {
            location_delegate = loc_delegate;
            return this;
        }
    }
}
