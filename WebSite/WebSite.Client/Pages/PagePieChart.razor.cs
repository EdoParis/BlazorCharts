using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PagePieChart : ComponentBase
    {
        private Circulargram model;

        protected override void OnInitialized()
        {
            model = new Circulargram();
            model.Add(new Slice("S1", 5, Color.Purple));
            model.Add(new Slice("S2", 30, Color.OrangeRed));
            model.Add(new Slice("S3", 5, Color.Gold));
            model.Add(new Slice("S4", 40, Color.Aqua));
            model.Add(new Slice("S5", 15, Color.DodgerBlue));
        }

        private void OnSliceClick(Slice slice)
        {
            Console.WriteLine($"Clicked slice {slice.Label} with value {slice.Value}");
        }
    }
}
