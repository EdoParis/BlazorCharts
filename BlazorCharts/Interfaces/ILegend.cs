using BlazorGraphs.Legends;

namespace BlazorGraphs.Interfaces
{
    public interface ILegend
    {
        public IEnumerable<LegendItem> ToLegend();
    }
}
