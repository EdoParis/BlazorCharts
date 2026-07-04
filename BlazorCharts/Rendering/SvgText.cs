using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using BlazorGraphs.Extensions;

namespace BlazorGraphs.Rendering
{
    public class SvgText : ComponentBase
    {
        protected const string CURRENT = "currentColor";

        [Parameter] public string Text { get; set; }
        [Parameter] public int Size { get; set; }
        [Parameter] public int X { get; set; }
        [Parameter] public int Y { get; set; }
        [Parameter] public Color? Fill { get; set; }

        protected virtual string Style
        {
            get => $"font-size: {Size}px;" +
                   "pointer-events: none;" +
                   "dominant-baseline: central;" +
                   $"fill: {Fill?.ToHex() ?? CURRENT};";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "style", Style);
            builder.AddContent(4, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextStart : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: start";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "dx", "0.5em");
            builder.AddAttribute(4, "style", Style);
            builder.AddContent(5, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextMiddle : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: middle";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "style", Style);
            builder.AddContent(4, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextEnd : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: end";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "dx", "-0.5em");
            builder.AddAttribute(4, "style", Style);
            builder.AddContent(5, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextTop : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: middle";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "dy", "-1em");
            builder.AddAttribute(4, "style", Style);
            builder.AddContent(5, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextBottom : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: middle";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "dy", "1em");
            builder.AddAttribute(4, "style", Style);
            builder.AddContent(5, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextRotated90 : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: end";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "dx", "-0.5em");
            builder.AddAttribute(4, "style", Style);
            builder.AddAttribute(4, "transform", $"rotate(-90, {X}, {Y})");
            builder.AddContent(5, Text);
            builder.CloseElement();
        }
    }

    public class SvgTextRotated270 : SvgText
    {
        protected override string Style
        {
            get => base.Style +
                   "text-anchor: start";
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "text");
            builder.AddAttribute(1, "x", X);
            builder.AddAttribute(2, "y", Y);
            builder.AddAttribute(3, "dx", "0.5em");
            builder.AddAttribute(4, "style", Style);
            builder.AddAttribute(4, "transform", $"rotate(270, {X}, {Y})");
            builder.AddContent(5, Text);
            builder.CloseElement();
        }
    }
}
