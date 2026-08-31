using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageHorizontalBarChart : ComponentBase
    {
        private Bargram model1;
        private Random random;
        private Double offset;

        protected override void OnInitialized()
        {
            random = new Random();
            offset = Math.Round(50 * (2 * random.NextDouble() - 1));
            model1 = new Bargram("Axis-2", Color.MediumPurple, Color.CadetBlue);

            for (int i = 0; i < 10; i++)
            {
                model1.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = Math.Round(offset * Math.Cos(model1.BarsCount / 3d))
                });
            }
        }

        private void OnChartClear()
        {
            model1?.Clear();
            offset = Math.Round(50 * (2 * random.NextDouble() - 1));
        }

        private void OnBarAdd()
        {
            if (model1 is null)
                return;

            model1.Add(new Bar()
            {
                Value = Math.Round(offset * Math.Cos(model1.BarsCount / 3d)),
                Label = DateOnly.FromDateTime(DateTime.Now).AddDays(model1.BarsCount).ToString("dd/MM")
            });
        }

        private void OnBarClick(Bar bar)
        {
            Console.WriteLine($"Clicked bar with label: {bar.Label}");
        }
    }
}
