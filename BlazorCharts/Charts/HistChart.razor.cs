using BlazorGraphs.Models;
using BlazorGraphs.Structures;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Charts
{
    public partial class HistChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Histogram Model { get; set; }
        [Parameter] public EventCallback<Bin> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private int originH => Model is null ? offsetH : offsetH - (int)(Model.AxisX.Min * scaleH);
        private int originV => Model is null ? offsetV : offsetV + (int)(Model.AxisY.Min * scaleV);
        private double scaleH => (width - 2 * padding) / Model.AxisX.Size;
        private double scaleV => (height - 2 * padding) / Model.AxisY.Size;
    }
}
