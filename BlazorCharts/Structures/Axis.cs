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

        public Axis Update(double value)
        {
            if (IsDefault)
            {
                return new Axis()
                {
                    Min = value,
                    Max = value,
                    Range = Max - Min,
                    IsDefault = false
                };
            }
            else
            {
                return new Axis()
                {
                    Min = Math.Min(Min, value),
                    Max = Math.Max(Max, value),
                    Range = Math.Max(Max, value) - Math.Min(Min, value),
                    IsDefault = false
                };
            }

            /*Step = (int)((Max - Min) / 5);

            if (Step > 5)
                Step = Step - Step % 5;

            if (Step <= 0)
                Step = 1;*/
        }
    }
}
