using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PagePolarAreaChart : ComponentBase
    {
        private Circulargram model;

        protected override void OnInitialized()
        {
            model = new Circulargram();
            model.Add(new Slice("S1", 25, Color.Purple));
            model.Add(new Slice("S2", 35, Color.Red));
            model.Add(new Slice("S3", 15, Color.Gold));
            model.Add(new Slice("S4", 25, Color.Aqua));
            model.Add(new Slice("S5", 45, Color.DodgerBlue));
        }

        private void OnSliceClick(Slice slice)
        {
            Console.WriteLine($"Clicked slice {slice.Label} with value {slice.Value}");
        }
    }
}
