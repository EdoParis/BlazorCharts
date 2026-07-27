using System.Drawing;

namespace BlazorGraphs.Internal
{
    internal class TextLayout
    {
        public Int32 Size { get; private set; }
        public Point Location { get; private set; }

        public static Middle MiddleLayout() => new Middle();
        public static Bottom BottomLayout() => new Bottom();
        public static Start StartLayout() => new Start();
        public static End EndLayout() => new End();
        public static Top TopLayout() => new Top();
        public static VerticalTop VerticalTopLayout() => new VerticalTop();
        public static VerticalBottom VerticalBottomLayout() => new VerticalBottom();

        public TextLayout Small() => WithSize(20);
        public TextLayout Medium() => WithSize(40);
        public TextLayout Large() => WithSize(100);
        public TextLayout WithSize(int size)
        {
            Size = size;
            return this;
        }

        public TextLayout At(int x, int y) => At(new Point(x, y));
        public TextLayout At(Point p)
        {
            Location = p;
            return this;
        }

        public class Middle : TextLayout
        {
        }

        public class Start : TextLayout
        {
        }

        public class End : TextLayout
        {
        }

        public class Top : TextLayout
        {
        }

        public class Bottom : TextLayout
        {
        }

        public class VerticalTop : TextLayout
        {
        }

        public class VerticalBottom : TextLayout
        {
        }
    }
}
