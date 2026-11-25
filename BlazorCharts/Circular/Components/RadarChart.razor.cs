using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Components
{
    public partial class RadarChart
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Boolean Circular { get; set; }
        [Parameter] public Radargram Model { get; set; }
        [Parameter] public EventCallback<Rating> OnClick { get; set; }
        private int width = VIEW;
        private int height = VIEW;
        private int padding = PADDING;
        private TextLayout LayoutLabels;
        private TextLayout LayoutTicks;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            LayoutLabels.WithTheme(Theme);
            LayoutTicks.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            LayoutLabels = TextLayout.MiddleLayout().Medium().WithTheme(Theme);
            LayoutTicks = TextLayout.EndLayout().Medium().WithTheme(Theme);
            LayoutTooltip = TooltipLayout.Default();
        }

        private string Path()
        {
            int i = 0;
            PathBuilder builder = PathBuilder.CreateBuilder();

            foreach (Rating rating in Model)
            {
                double r = rating.Value / Model.AxisR.Size * (Math.Min(width, height) - 2 * padding) / 2;
                double x = width / 2 + r * Math.Sin(2 * Math.PI / Model.Categories * i);
                double y = height / 2 - r * Math.Cos(2 * Math.PI / Model.Categories * i);

                if (i == 0)
                    builder.MoveTo(x, y);
                else
                    builder.LineTo(x, y);

                i++;
            }
            return builder.Close()
                          .Build();
        }

        private string Path(double radius)
        {
            PathBuilder builder = PathBuilder.CreateBuilder();

            for (int i = 0; i < Model.Categories; i++)
            {
                double r = radius * (Math.Min(width, height) / 2 - padding);
                double x = width / 2 + r * Math.Sin(2 * Math.PI / Model.Categories * i);
                double y = height / 2 - r * Math.Cos(2 * Math.PI / Model.Categories * i);

                if (i == 0)
                    builder.MoveTo(x, y);
                else
                    builder.LineTo(x, y);
            }
            return builder.Close()
                          .Build();
        }

        private void OnRatingEnter(Rating rating)
        {
            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = Theme.Markers.Series,
                Color = Model.Color
            })
            .WithTitle(rating.Label)
            .WithLabel(rating.Value.ToString("0.##"))
            .Show();
        }

        private void OnPathEnter()
        {
            if (string.IsNullOrWhiteSpace(Model.Title))
                return;

            LayoutTooltip.WithMarker(new Marker()
            {
                Symbol = Theme.Markers.Series,
                Color = Model.Color
            })
            .WithLabel(Model.Title)
            .WithoutTitle()
            .Show();
        }
    }
}
