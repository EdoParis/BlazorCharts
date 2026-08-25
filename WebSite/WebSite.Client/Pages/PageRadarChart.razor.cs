using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageRadarChart : ComponentBase
    {
        private Radargram model1;
        private Radargram model2;
        private Radargram model3;

        protected override void OnInitialized()
        {
            model1 = new Radargram("Ratings-1", Color.Purple);
            model1.Add(new Rating("R1", 25));
            model1.Add(new Rating("R2", 30));
            model1.Add(new Rating("R3", 10));
            model1.Add(new Rating("R4", 40));
            model1.Add(new Rating("R5", 15));

            model2 = new Radargram("Ratings-2", Color.MediumBlue);
            model2.Add(new Rating("R1", 25));
            model2.Add(new Rating("R2", 30));
            model2.Add(new Rating("R3", 10));
            model2.Add(new Rating("R4", 40));
            model2.Add(new Rating("R5", 15));
            model2.Add(new Rating("R6", 20));

            model3 = new Radargram("Ratings-3", Color.Green);
            model3.Add(new Rating("C1", 140));
            model3.Add(new Rating("C2", 130));
            model3.Add(new Rating("C3", 90));
            model3.Add(new Rating("C4", 80));
            model3.Add(new Rating("C5", 120));
            model3.Add(new Rating("C6", 175));
            model3.Add(new Rating("B9", 150));
            model3.Add(new Rating("D1", 100));
        }
    }
}
