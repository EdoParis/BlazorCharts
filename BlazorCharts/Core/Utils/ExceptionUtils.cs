namespace BlazorGraphs.Core
{
    internal class ExceptionUtils
    {
        public static void ThrowIfInvalid<T>(T validable) where T : IValidable
        {
            if (!validable.IsValid())
                throw new ArgumentOutOfRangeException(validable.GetType().Name);
        }
    }
}
