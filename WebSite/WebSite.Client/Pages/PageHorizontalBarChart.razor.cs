using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageHorizontalBarChart : ComponentBase
    {
        private Bargram model1;
        private Bargram model2;
        private Bargram model3;

        protected override void OnInitialized()
        {
            model1 = new Bargram("Axis-2", Color.MediumPurple);
            model2 = new Bargram("Axis-2", Color.MediumPurple);
            model3 = new Bargram("Axis-2", Color.MediumOrchid, Color.MediumSlateBlue);

            for (int i = 5; i < 15; i++)
            {
                model1.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = 200 - i * i
                });

                model2.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = -i * i
                });

                model3.Add(new Bar()
                {
                    Label = DateOnly.FromDateTime(DateTime.Now).AddDays(i).ToString("dd/MM"),
                    Value = 90 - i * i
                });
            }
        }

        private void OnBarClick(Bar bar)
        {
            Console.WriteLine($"Clicked bar with label: {bar.Label}");
        }
    }
}
