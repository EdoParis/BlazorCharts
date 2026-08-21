using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageLineChart : ComponentBase
    {
        private Cartesiangram model;

        protected override void OnInitialized()
        {
            model = new Cartesiangram("AxisX", "AxisY");

            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            List<Datapoint> points4 = new();

            for (int i = 0; i <= 10; i++)
            {
                points1.Add(new Datapoint() { X = 2 * i, Y = 50 + i * i });
                points2.Add(new Datapoint() { X = 2 * i, Y = (i + 2) * (i + 2) });
                points3.Add(new Datapoint() { X = 2 * i, Y = (i + 4) * (i + 4) });
                points4.Add(new Datapoint() { X = 2 * i, Y = (i + 6) * (i + 6) });
            }

            model.AddSerie("F1", Color.LimeGreen, points1);
            model.AddSerie("F2", Color.OrangeRed, points2);
            model.AddSerie("F3", Color.CadetBlue, points3);
            model.AddSerie("F4", Color.DodgerBlue, points4);
        }
    }
}
