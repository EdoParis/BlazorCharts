using System.Text;

namespace BlazorGraphs.Core
{
    internal class PathBuilder
    {
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

        public PathBuilder MoveTo(int x, int y)
        {
            string_builder.Append('M');
            string_builder.Append(' ');
            string_builder.Append(x);
            string_builder.Append(' ');
            string_builder.Append(y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LineTo(int x, int y)
        {
            string_builder.Append('L');
            string_builder.Append(' ');
            string_builder.Append(x);
            string_builder.Append(' ');
            string_builder.Append(y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder Horizontal(int h)
        {
            string_builder.Append('H');
            string_builder.Append(' ');
            string_builder.Append(h);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder Vertical(int v)
        {
            string_builder.Append('V');
            string_builder.Append(' ');
            string_builder.Append(v);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallArcClockwise(int rx, int ry, int x, int y, int axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(x);
            string_builder.Append(' ');
            string_builder.Append(y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeArcClockwise(int rx, int ry, int x, int y, int axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(x);
            string_builder.Append(' ');
            string_builder.Append(y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallArcCounterclockwise(int rx, int ry, int x, int y, int axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(x);
            string_builder.Append(' ');
            string_builder.Append(y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeArcCounterclockwise(int rx, int ry, int x, int y, int axis_rotation = 0)
        {
            string_builder.Append('A');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(x);
            string_builder.Append(' ');
            string_builder.Append(y);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder RelativeTo(int dx, int dy)
        {
            string_builder.Append('l');
            string_builder.Append(' ');
            string_builder.Append(dx);
            string_builder.Append(' ');
            string_builder.Append(dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder RelativeHorizontal(int dh)
        {
            string_builder.Append('h');
            string_builder.Append(' ');
            string_builder.Append(dh);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder RelativeVertical(int dv)
        {
            string_builder.Append('v');
            string_builder.Append(' ');
            string_builder.Append(dv);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallRelativeArcClockwise(int rx, int ry, int dx, int dy, int axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(dx);
            string_builder.Append(' ');
            string_builder.Append(dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeRelativeArcClockwise(int rx, int ry, int dx, int dy, int axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(dx);
            string_builder.Append(' ');
            string_builder.Append(dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder SmallRelativeArcCounterclockwise(int rx, int ry, int dx, int dy, int axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(dx);
            string_builder.Append(' ');
            string_builder.Append(dy);
            string_builder.Append(' ');
            return this;
        }

        public PathBuilder LargeRelativeArcCounterclockwise(int rx, int ry, int dx, int dy, int axis_rotation = 0)
        {
            string_builder.Append('a');
            string_builder.Append(' ');
            string_builder.Append(rx);
            string_builder.Append(' ');
            string_builder.Append(ry);
            string_builder.Append(' ');
            string_builder.Append(axis_rotation);
            string_builder.Append(' ');
            string_builder.Append(1);
            string_builder.Append(' ');
            string_builder.Append(0);
            string_builder.Append(' ');
            string_builder.Append(dx);
            string_builder.Append(' ');
            string_builder.Append(dy);
            string_builder.Append(' ');
            return this;
        }
    }
}
