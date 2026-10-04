using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class VerticalGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public bool Reverse { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = 3 * PADDING;
        private int height = VIEW;
        private int padding = PADDING;
        private int offsetV => height - padding;
        private double scaleV => (height - 2 * padding) / Model.Axis.Size;
        private AxisLayout AxisLayout;
        private TextLayout TitleLayout;
        private TooltipLayout LayoutTooltip;

        protected override void OnParametersSet()
        {
            AxisLayout.WithTheme(Theme);
            TitleLayout.WithTheme(Theme);
            LayoutTooltip.WithTheme(Theme);
        }

        protected override void OnInitialized()
        {
            AxisLayout = AxisLayout.VerticalLayout()
                                   .FullExternal()
                                   .WithTickSize(20)
                                   .WithTheme(Theme)
                                   .From(height - padding)
                                   .To(padding)
                                   .At(width / 2);

            TitleLayout = TextLayout.MiddleLayout()
                                    .Medium()
                                    .WithTheme(Theme)
                                    .At(width / 2, padding / 2);

            LayoutTooltip = TooltipLayout.Default()
                                         .WithMarker(MarkerLayout.SquareLayout());
        }

        private void OnMouseHandler(MouseEventArgs e)
        {
            if (e is null)
                return;

            LayoutTooltip.At(new Point()
            {
                X = (int)e.OffsetX + 10,
                Y = (int)e.OffsetY + 10
            });
        }

        private void OnGaugeEnter()
        {
            LayoutTooltip.Show()
                         .WithoutTitle()
                         .WithLabel(Model.Value.ToString("0.0#"))
                         .Marker.WithColor(Model.HasBreakPoints ? Color.White : Model.Color);
        }

        private void OnGaugeLeave()
        {
            LayoutTooltip.Hide();
        }

        private void OnBreakpointEnter(Breakpoint breakpoint)
        {
            LayoutTooltip.Show()
                         .WithTitle(breakpoint.Label)
                         .WithLabel($"< {breakpoint.Value.ToString("0.##")}")
                         .Marker.WithColor(breakpoint.Color);
        }

        private void OnBreakpointLeave()
        {
            LayoutTooltip.Hide();
        }

        private void OnSvgLeave()
        {
            LayoutTooltip.Hide();
        }
    }
}
