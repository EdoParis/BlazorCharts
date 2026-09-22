namespace BlazorGraphs.Core
{
    internal class ViewLayout
    {
        private const int SIZE = 1000;
        private const int PADDING = 100;

        public double Ratio { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Padding { get; private set; }
        public int InternalWidth { get; private set; }
        public int InternalHeight { get; private set; }

        private ViewLayout()
        {
        }

        public static ViewLayout Default()
        {
            return new ViewLayout().WithAspectRatio(AspectRatio.Square);
        }

        public ViewLayout WithAspectRatio(double aspect_ratio)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(aspect_ratio, AspectRatio.Maximum);
            ArgumentOutOfRangeException.ThrowIfLessThan(aspect_ratio, AspectRatio.Minimum);
            ExceptionUtils.ThrowIfInfinity(aspect_ratio);
            ExceptionUtils.ThrowIfNaN(aspect_ratio);

            Ratio = aspect_ratio;
            Width = SIZE;
            Height = 2 * PADDING + (int)((SIZE - 2 * PADDING) / aspect_ratio);
            Padding = PADDING;
            InternalWidth = Width - 2 * Padding;
            InternalHeight = Height - 2 * Padding;
            return this;
        } 
    }
}
