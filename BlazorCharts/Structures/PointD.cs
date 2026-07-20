namespace BlazorGraphs.Structures
{
    public struct PointD
    {
        private double x;
        private double y;

        public double X 
        { 
            get => x;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentException(nameof(X));

                x = value;
            }
        }

        public double Y
        {
            get => y;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                    throw new ArgumentException(nameof(Y));

                y = value;
            }
        }

        public PointD(double value_x, double value_y)
        {
            X = value_x;
            Y = value_y;
        }
    }
}
