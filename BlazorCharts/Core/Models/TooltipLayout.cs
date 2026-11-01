using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal class TooltipLayout
    {
        public Marker? Marker { get; private set; }
        public Point Position { get; private set; }
        public String Label { get; private set; }
        public String Title { get; private set; }
        public Boolean Visible { get; private set; }
        public Boolean HasMarker { get => Marker.HasValue; }

        private TooltipLayout() 
        {
        }

        public static TooltipLayout Default()
        {
            return new TooltipLayout();
        }

        public TooltipLayout Show()
        {
            Visible = true;
            return this;
        }

        public TooltipLayout Hide()
        {
            Visible = false;
            return this;
        }

        public TooltipLayout Move(MouseEventArgs e)
        {
            if (e is not null)
            {
                Position = new Point()
                {
                    X = (int)e.ClientX,
                    Y = (int)e.ClientY
                };
            }
            return this;
        }

        public TooltipLayout WithLabel(string label)
        {
            Label = label;
            return this;
        }

        public TooltipLayout WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public TooltipLayout WithMarker(Marker marker)
        {
            Marker = marker;
            return this;
        }

        public TooltipLayout WithoutMarker()
        {
            Marker = null;
            return this;
        }

        public TooltipLayout WithoutTitle()
        {
            Title = null;
            return this;
        }

        public TooltipLayout WithoutLabel()
        {
            Label = null;
            return this;
        }
    }
}
