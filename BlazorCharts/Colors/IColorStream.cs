using System.Drawing;

namespace BlazorGraphs
{
    public interface IColorStream
    {
        public Color Next();

        public void Reset();
    }
}
