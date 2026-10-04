using BlazorGraphs.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Components
{
    public partial class HorizontalGauge
    {
        private const int VIEW = 1000;
        private const int PADDING = 100;

        [Parameter] public Theme Theme { get; set; }
        [Parameter] public Boolean Reverse { get; set; }
        [Parameter] public Gaugegram Model { get; set; }
        private int width = VIEW;
        private int height = 3 * PADDING;
        private int padding = PADDING;
        private int offsetH => padding;
        private int offsetV => height - padding;
        private double scaleH => (width - 2 * padding) / Model.Axis.Size;
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
            AxisLayout = AxisLayout.HorizontalLayout()
                                   .WithTickSize(20)
                                   .WithTheme(Theme)
                                   .From(padding)
                                   .To(width - padding);

            LayoutTooltip = TooltipLayout.Default()
                                         .WithMarker(MarkerLayout.SquareLayout());

            TitleLayout = TextLayout.MiddleLayout().Medium().WithTheme(Theme);
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
