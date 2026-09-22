namespace BlazorGraphs.Core
{
    internal class ExceptionUtils
    {
        public static void ThrowIfInvalid<T>(T validable) where T : IValidable
        {
            if (!validable.IsValid())
                throw new ArgumentOutOfRangeException(validable.GetType().Name);
        }

        public static void ThrowIfNaN(double value)
        {
            if (double.IsNaN(value))
                throw new ArgumentException("NaN is not a valid value");
        }

        public static void ThrowIfInfinity(double value)
        {
            if (double.IsInfinity(value))
                throw new ArgumentException("Infinity is not a valid value");
        }
    }
}
