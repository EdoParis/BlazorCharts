namespace BlazorGraphs.Internal
{
    internal struct Tick
    {
        public double RelativePosition { get; set; }
        public string Label { get; set; }
        public bool IsMaster { get; set; }
        public bool IsStartTick { get => RelativePosition == 0; }
        public bool IsEndTick { get => RelativePosition == 1; }
    }
}
