using BlazorGraphs;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;

namespace WebApp.Pages
{
    public partial class PageRadarChart : ComponentBase
    {
        private Radargram model1;
        private Random random;
        private Double offset;
        private Boolean circular;

        protected override void OnInitialized()
        {
            random = new Random();
            offset = Math.Round(50 * (2 * random.NextDouble() + 1));
            model1 = new Radargram("Ratings", Color.Purple);
            model1.Add(new Rating("R1", Math.Round(offset * (0.5 + random.NextDouble()))));
            model1.Add(new Rating("R2", Math.Round(offset * (0.5 + random.NextDouble()))));
            model1.Add(new Rating("R3", Math.Round(offset * (0.5 + random.NextDouble()))));
            model1.Add(new Rating("R4", Math.Round(offset * (0.5 + random.NextDouble()))));
            model1.Add(new Rating("R5", Math.Round(offset * (0.5 + random.NextDouble()))));
        }

        private void OnChartClear()
        {
            model1?.Clear();
            offset = Math.Round(50 * (2 * random.NextDouble() + 1));
        }

        private void OnRatingAdd()
        {
            if (model1 is null)
                return;

            model1.Add(new Rating()
            {
                Value = Math.Round(offset * (0.5 + random.NextDouble())),
                Label = $"R{model1.Categories + 1}"
            });
        }
    }
}
