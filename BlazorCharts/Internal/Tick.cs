namespace BlazorGraphs.Internal
{
    internal struct Tick
    {
        public int Position { get; set; }
        public string Label { get; set; }
        public bool IsMaster { get; set; }
    }
}
