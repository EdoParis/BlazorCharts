using BlazorGraphs.Interfaces;

namespace BlazorGraphs.Exceptions
{
    internal class InvalidArgumentException : ArgumentOutOfRangeException
    {
        public InvalidArgumentException(string param) : base($"Invalid {param} parameter")
        { }

        public InvalidArgumentException(string param, Exception innerException) : base($"Invalid {param} parameter", innerException)
        { }

        public static void ThrowIfInvalid(IValidable validable)
        {
            if (!validable.IsValid())
                throw new InvalidArgumentException(validable.GetType().Name);
        }
    }
}
