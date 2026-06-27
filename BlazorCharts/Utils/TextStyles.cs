namespace BlazorGraphs.Static
{
    internal static class TextStyles
    {
        private static string Default()
        {
            return "font-size: 40px;" +
                "pointer-events: none;" +
                "dominant-baseline: central;";
        }

        public static string Start()
        {
            return Default() +
                "text-anchor: start;" +
                "transform: translateX(0.5em);";
        }

        public static string Middle()
        {
            return Default() +
                "text-anchor: middle;";
        }

        public static string End()
        {
            return Default() +
                "text-anchor: end;" +
                "transform: translateX(-0.5em);";
        }

        public static string Large()
        {
            return "font-size: 100px;" +
                "pointer-events: none;" +
                "text-anchor: middle;" +
                "dominant-baseline: central";
        }

        public static string LargeTop()
        {
            return "font-size: 100px;" +
                "pointer-events: none;" +
                "text-anchor: middle;";
        }

        public static string Rotated45()
        {
            return Default() + 
                "transform: rotate(-45deg);" +
                "transform-box: fill-box;" +
                "transform-origin: center;";
        }

        public static string Rotated90()
        {
            return Default() +
                "text-anchor: end;" +
                "transform: rotate(-90deg) translateX(-0.5em);" +
                "transform-box: fill-box;" +
                "transform-origin: right;";
        }

        public static string Rotated270()
        {
            return Default() + 
                "text-anchor: start;" +
                "transform: rotate(270deg) translateX(0.5em);" +
                "transform-box: fill-box;" +
                "transform-origin: left;";
        }
    }
}
