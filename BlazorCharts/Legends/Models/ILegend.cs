namespace BlazorGraphs
{
    public interface ILegend
    {
        public IEnumerable<LegendItem> ToLegend();
    }
}
