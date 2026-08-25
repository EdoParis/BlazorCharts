using Microsoft.AspNetCore.Components;
using System.Drawing;
using BlazorGraphs;

namespace WebApp.Pages
{
    public partial class PageBubbleChart : ComponentBase
    {
        private Bubblegram model;

        protected override void OnInitialized()
        {
            model = new Bubblegram("AxisX", "AxisY");

            List<Bubblepoint> bubbles1 = new();
            List<Bubblepoint> bubbles2 = new();

            for (int i = 0; i <= 10; i++)
            {
                bubbles1.Add(new Bubblepoint() { X = 2 * i, Y = (i + 2) * (i + 2), Value = 25 + i });
                bubbles2.Add(new Bubblepoint() { X = 2 * i, Y = 50 + i * i, Value = 10 + i });
            }

            model.AddSerie("F1", Color.MediumPurple, bubbles1);
            model.AddSerie("F2", Color.OrangeRed, bubbles2);
        }
    }
}
