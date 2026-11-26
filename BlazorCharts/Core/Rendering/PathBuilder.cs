using System.Globalization;
using System.Text;

namespace BlazorGraphs.Core
{
    internal class PathBuilder
    {
        private const string FORMAT = "{0:0.#}";
        private StringBuilder string_builder;

        private PathBuilder()
        {
            string_builder = new StringBuilder();
        }

        public static PathBuilder CreateBuilder()
        {
            return new PathBuilder();
        }

        public void Clear()
        {
            string_builder.Clear();
        }

        public string Build()
        {
            return string_builder.ToString();
        }

        public PathBuilder Close()
        {
            string_builder.Append('Z');
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder MoveTo(double x, double y)
        {
            string_builder.Append('M');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, x);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LineTo(double x, double y)
        {
            string_builder.Append('L');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, x);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder Horizontal(double h)
        {
            string_builder.Append('H');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, h);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder Vertical(double v)
        {
            string_builder.Append('V');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, v);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallArcClockwise(double r, double x, double y) => SmallArcClockwise(r, r, x, y, 0);

        public PathBuilder SmallArcClockwise(double rx, double ry, double x, double y, double axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, x);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeArcClockwise(double r, double x, double y) => LargeArcClockwise(r, r, x, y, 0);

        public PathBuilder LargeArcClockwise(double rx, double ry, double x, double y, double axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, x);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallArcCounterclockwise(double r, double x, double y) => SmallArcCounterclockwise(r, r, x, y, 0);

        public PathBuilder SmallArcCounterclockwise(double rx, double ry, double x, double y, double axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, x);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeArcCounterclockwise(double r, double x, double y) => LargeArcCounterclockwise(r, r, x, y, 0);

        public PathBuilder LargeArcCounterclockwise(double rx, double ry, double x, double y, double axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, x);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder RelativeTo(double dx, double dy)
        {
            string_builder.Append('l');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder RelativeHorizontal(double dh)
        {
            string_builder.Append('h');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dh);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder RelativeVertical(double dv)
        {
            string_builder.Append('v');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dv);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallRelativeArcClockwise(double r, double dx, double dy) => SmallRelativeArcClockwise(r, r, dx, dy, 0);

        public PathBuilder SmallRelativeArcClockwise(double rx, double ry, double dx, double dy, double axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeRelativeArcClockwise(double r, double dx, double dy) => LargeRelativeArcClockwise(r, r, dx, dy, 0);

        public PathBuilder LargeRelativeArcClockwise(double rx, double ry, double dx, double dy, double axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallRelativeArcCounterclockwise(double r, double dx, double dy) => SmallRelativeArcCounterclockwise(r, r, dx, dy, 0);

        public PathBuilder SmallRelativeArcCounterclockwise(double rx, double ry, double dx, double dy, double axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeRelativeArcCounterclockwise(double r, double dx, double dy) => LargeRelativeArcCounterclockwise(r, r, dx, dy, 0);

        public PathBuilder LargeRelativeArcCounterclockwise(double rx, double ry, double dx, double dy, double axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, rx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, ry);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dx);
            string_builder.Append(' ');
            string_builder.AppendFormat(CultureInfo.InvariantCulture, FORMAT, dy);
            string_builder.Append(' ');
            return this;
        }
    }
}
