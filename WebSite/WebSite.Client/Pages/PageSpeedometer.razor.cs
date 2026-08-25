using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageSpeedometer : ComponentBase
    {
        Gaugegram model1;
        Gaugegram model2;

        protected override void OnInitialized()
        {
            model1 = new Gaugegram(700, 1000, "G1", Color.RoyalBlue);
            model2 = new Gaugegram(0, 500, "G2", Color.Navy);
            model1.Value = 800;
            model2.Value = 170;

            model2.AddBreakpoint(new Breakpoint()
            {
                Value = 150,
                Color = Color.Green,
                Label = "LV-1"
            });
            model2.AddBreakpoint(new Breakpoint()
            {
                Value = 250,
                Color = Color.Gold,
                Label = "LV-2"
            });
            model2.AddBreakpoint(new Breakpoint()
            {
                Value = 500,
                Color = Color.Red,
                Label = "LV-3"
            });
        }
    }
}
