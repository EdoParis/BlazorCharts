using Microsoft.AspNetCore.Components;

namespace BlazorGraphs.Core
{
    internal static class TooltipRenderer
    {
        public static RenderFragment Render(this TooltipLayout layout, Theme theme)
        {
            int sequence = 0;
            return builder =>
            {
                builder.OpenElement(sequence++, "div");
                builder.AddAttribute(sequence++, "style", @$"top: {layout.Position.Y}px; 
                                                             left: {layout.Position.X}px; 
                                                             padding: 0.2em;
                                                             position: fixed;
                                                             border: 1px solid;
                                                             border-radius: 0.2em;
                                                             pointer-events: none;
                                                             transform: translate(-50%, -110%);
                                                             backdrop-filter: blur(5px) brightness(0.85) hue-rotate(15deg);
                                                             box-shadow: 2px 2px 4px rgba(0, 0, 0, 0.2);
                                                             color: {theme.TextColorString()}; 
                                                             font-family: {theme.FontString()}; 
                                                             border-color: {theme.AxisColorString()}; 
                                                             background-color: {theme.BackgroundString()};
                                                             display: {(layout.Visible ? "block" : "none")}");
                builder.OpenElement(sequence++, "table");
                if (!string.IsNullOrWhiteSpace(layout.Title))
                {
                    builder.OpenElement(sequence++, "tr");
                    builder.OpenElement(sequence++, "td");
                    builder.AddAttribute(sequence++, "colspan", layout.HasMarker ? 2 : 1);
                    builder.AddAttribute(sequence++, "style", "text-align: center; white-space: nowrap;");
                    builder.AddContent(sequence++, layout.Title);
                    builder.CloseElement();
                    builder.CloseElement();
                }
                builder.OpenElement(sequence++, "tr");
                if (layout.HasMarker)
                {
                    builder.OpenElement(sequence++, "td");
                    builder.AddContent(sequence++, layout.Marker.Value.Render());
                    builder.CloseElement();
                }
                builder.OpenElement(sequence++, "td");
                builder.AddAttribute(sequence++, "style", "white-space: nowrap;");
                builder.AddContent(sequence++, layout.Label);
                builder.CloseElement();
                builder.CloseElement();
                builder.CloseElement();
                builder.CloseElement();
            };
        }
    }
}
