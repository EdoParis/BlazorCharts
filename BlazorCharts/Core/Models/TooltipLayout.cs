using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Drawing;

namespace BlazorGraphs.Core
{
    internal class TooltipLayout
    {
        public MarkerLayout Marker { get; private set; }
        public Point Position { get; private set; }
        public Theme Theme { get; private set; }
        public String Label { get; private set; }
        public String Title { get; private set; }
        public Boolean Visible { get; private set; }

        private TooltipLayout() 
        { }

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

        public TooltipLayout WithTheme(Theme theme)
        {
            Theme = theme;
            return this;
        }

        public TooltipLayout WithMarker(MarkerLayout marker)
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

        public RenderFragment Render()
        {
            return builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "style", @$"top: {Position.Y}px; 
                                                   left: {Position.X}px; 
                                                   padding: 0.2em;
                                                   position: fixed;
                                                   border: 1px solid;
                                                   border-radius: 0.2em;
                                                   pointer-events: none;
                                                   transform: translate(-50%, -110%);
                                                   backdrop-filter: blur(5px) brightness(0.85) hue-rotate(15deg);
                                                   box-shadow: 2px 2px 4px rgba(0, 0, 0, 0.2);
                                                   color: {Theme.TextColorString()}; 
                                                   font-family: {Theme.FontString()}; 
                                                   border-color: {Theme.AxisColorString()}; 
                                                   background-color: {Theme.BackgroundString()};
                                                   display: {(Visible ? "block" : "none")}");
                builder.OpenElement(2, "table");
                if (!string.IsNullOrWhiteSpace(Title))
                {
                    builder.OpenElement(3, "tr");
                    builder.OpenElement(4, "td");
                    builder.AddAttribute(5, "colspan", 2);
                    builder.AddAttribute(6, "style", "text-align: center; white-space: nowrap;");
                    builder.AddContent(7, Title);
                    builder.CloseElement();
                    builder.CloseElement();
                }
                builder.OpenElement(8, "tr");
                builder.OpenElement(9, "td");
                builder.AddContent(10, Marker?.Render());
                builder.CloseElement();
                builder.OpenElement(11, "td");
                builder.AddAttribute(12, "style", "white-space: nowrap;");
                builder.AddContent(13, Label);
                builder.CloseElement();
                builder.CloseElement();
                builder.CloseElement();
                builder.CloseElement();
            };
        }
    }
}
