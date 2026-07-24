using BlazorGraphs.Interfaces;

namespace BlazorGraphs.Exceptions
{
    public class InvalidArgumentException : ArgumentOutOfRangeException
    {
        internal InvalidArgumentException(string param) : base($"Invalid {param} parameter")
        { }

        internal InvalidArgumentException(string param, Exception innerException) : base($"Invalid {param} parameter", innerException)
        { }

        internal static void ThrowIfInvalid<T>(T validable) where T : IValidable
        {
            if (!validable.IsValid())
                throw new InvalidArgumentException(validable.GetType().Name);
        }
    }
}
