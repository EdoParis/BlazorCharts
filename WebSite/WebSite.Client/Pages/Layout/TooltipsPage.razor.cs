using BlazorGraphs;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace WebApp.Pages.Layout
{
    public partial class TooltipsPage : ComponentBase
    {
        private Cartesiangram cartesiangram;
        private Theme theme;

        protected override void OnInitialized()
        {
            cartesiangram = new Cartesiangram("Axis-X", "Axis-Y");
            List<Datapoint> points1 = new();
            List<Datapoint> points2 = new();
            List<Datapoint> points3 = new();
            List<Datapoint> points4 = new();

            for (int i = 0; i <= 10; i++)
            {
                points1.Add(new Datapoint() { X = 2 * i, Y = 50 + i * i });
                points2.Add(new Datapoint() { X = 2 * i, Y = (i + 3) * (i + 2) });
                points3.Add(new Datapoint() { X = 2 * i, Y = (i + 5) * (i + 4) });
                points4.Add(new Datapoint() { X = 2 * i, Y = (i + 6) * (i + 6) });
            }

            cartesiangram.AddSerie("Fn-1", Color.LimeGreen, points1);
            cartesiangram.AddSerie("Fn-2", Color.OrangeRed, points2);
            cartesiangram.AddSerie("Fn-3", Color.CadetBlue, points3);
            cartesiangram.AddSerie("Fn-4", Color.DodgerBlue, points4);
        }

        private void OnChangeTooltipBackground(ChangeEventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(e?.Value?.ToString());
                theme.Tooltip = new TooltipStyle()
                {
                    BackgroundColor = color,
                    BorderColor = theme.Tooltip.BorderColor,
                    TextColor = theme.Tooltip.TextColor
                };
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid color");
            }
        }

        private void OnChangeTooltipBorder(ChangeEventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(e?.Value?.ToString());
                theme.Tooltip = new TooltipStyle()
                {
                    BackgroundColor = theme.Tooltip.BackgroundColor,
                    BorderColor = color,
                    TextColor = theme.Tooltip.TextColor
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid color");
            }
        }

        private void OnChangeTooltipTextColor(ChangeEventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(e?.Value?.ToString());
                theme.Tooltip = new TooltipStyle()
                {
                    BackgroundColor = theme.Tooltip.BackgroundColor,
                    BorderColor = theme.Tooltip.BorderColor,
                    TextColor = color
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid color");
            }
        }
    }
}
