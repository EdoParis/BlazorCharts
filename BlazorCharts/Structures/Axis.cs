namespace BlazorCharts.Structures
{
    public struct Axis
    {
        public int Step;
        public double Min;
        public double Max;
        public double Range;
        private bool IsDefault;

        public Axis()
        {
            IsDefault = true;
            Range = default;
            Step = default;
            Min = default;
            Max = default;
        }

        public void Update(double value)
        {
            if (IsDefault)
            {
                Min = value;
                Max = value;
                IsDefault = false;
            }
            else
            {
                Min = Math.Min(Min, value);
                Max = Math.Max(Max, value);
            }

            Range = Max - Min;

            Step = (int)((Max - Min) / 5);

            if (Step > 5)
                Step = Step - Step % 5;

            if (Step <= 0)
                Step = 1;
        }
    }
}
