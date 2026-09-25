using System.Drawing;

namespace BlazorGraphs
{
    public sealed class RandomPalette : IColorStream
    {
        private const int MIN_LEVEL = 45;
        private const int MAX_LEVEL = 245;

        private int seed;
        private Random random;

        public RandomPalette(int _seed = default)
        {
            seed = _seed;
            random = new Random(seed);
        }

        public Color Next()
        {
            return Color.FromArgb((int)(MIN_LEVEL + (MAX_LEVEL - MIN_LEVEL) * random.NextDouble()),
                                  (int)(MIN_LEVEL + (MAX_LEVEL - MIN_LEVEL) * random.NextDouble()),
                                  (int)(MIN_LEVEL + (MAX_LEVEL - MIN_LEVEL) * random.NextDouble()));
        }

        public void Reset()
        {
            random = new Random(seed);
        }
    }
}
