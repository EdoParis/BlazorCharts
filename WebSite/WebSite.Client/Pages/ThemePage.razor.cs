using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class ThemePage : ComponentBase
    {
        private Histogram model;

        protected override void OnInitialized()
        {
            model = new Histogram("Axis-X", "Axis-Y", Color.RoyalBlue, Color.MediumOrchid);

            for (int i = 0; i < 10; i++)
            {
                model.Add(new Bin()
                {
                    Min = 2 * i,
                    Max = 2 * i + 2,
                    Value = 5 - Math.Pow(i - 4, 2)
                });
            }
        }
    }
}
