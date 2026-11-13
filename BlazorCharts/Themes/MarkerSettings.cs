namespace BlazorGraphs
{
    public struct MarkerSettings : IEquatable<MarkerSettings>
    {
        public DataMarker Data { get; set; }
        public SeriesMarker Series { get; set; }

        #region EQUALITY

        public override int GetHashCode()
        {
            return HashCode.Combine(Data, Series);
        }

        public override bool Equals(object obj)
        {
            return obj is MarkerSettings other && Equals(other);
        }

        public bool Equals(MarkerSettings other)
        {
            return Data == other.Data &&
                   Series == other.Series;
        }

        public static bool operator ==(MarkerSettings left, MarkerSettings right) => left.Equals(right);
        public static bool operator !=(MarkerSettings left, MarkerSettings right) => !left.Equals(right);

        #endregion
    }
}
