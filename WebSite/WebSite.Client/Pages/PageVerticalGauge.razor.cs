using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageVerticalGauge : ComponentBase
    {
        Gaugegram model1;
        Gaugegram model2;
        Gaugegram model3;

        protected override void OnInitialized()
        {
            model1 = new Gaugegram(700, 1000, "G1", Color.RoyalBlue);
            model2 = new Gaugegram(500, 1000, "G2", Color.LimeGreen);
            model3 = new Gaugegram(0, 500, "G3", Color.Navy);
            model1.Value = 800;
            model2.Value = 800;
            model3.Value = 170;

            model3.AddBreakpoint(new Breakpoint()
            {
                Value = 150,
                Color = Color.Green,
                Label = "LV-1" 
            });
            model3.AddBreakpoint(new Breakpoint()
            {
                Value = 250,
                Color = Color.Gold,
                Label = "LV-2"
            });
            model3.AddBreakpoint(new Breakpoint()
            {
                Value = 500,
                Color = Color.Red,
                Label = "LV-3"
            });
        }
    }
}
