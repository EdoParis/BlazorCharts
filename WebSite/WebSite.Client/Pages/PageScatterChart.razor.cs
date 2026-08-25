using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageScatterChart : ComponentBase
    {
        private Cartesiangram model;

        protected override void OnInitialized()
        {
            model = new Cartesiangram("AxisX", "AxisY");
            Random rnd = new Random();

            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            for (int i = 0; i < 20; i++)
            {
                points1.Add(new Datapoint() { X = 10 * rnd.NextDouble(), Y = 10 * rnd.NextDouble() });
                points2.Add(new Datapoint() { X = 5 + 20 * rnd.NextDouble(), Y = 5 + 20 * rnd.NextDouble() });
                points3.Add(new Datapoint() { X = 50 * rnd.NextDouble(), Y = 20 + 5 * rnd.NextDouble() });
            }

            model.AddSerie("F1", Color.LimeGreen, points1);
            model.AddSerie("F2", Color.OrangeRed, points2);
            model.AddSerie("F3", Color.RoyalBlue, points3);
        }
    }
}
