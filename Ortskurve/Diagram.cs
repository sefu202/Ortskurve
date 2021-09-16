using Raylib_cs;
using System;
using System.Collections.Generic;



namespace Ortskurve
{
    /**
     * <summary>
     * This Class can be used to draw a XY Plot
     * </summary>
     */
    class Diagram
    {
        public Diagram(int x, int y, int width, int height, Color color, int dotSize)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            this.color = color;
            this.dots = new List<Tuple<double, double>>();
            this.dotsize = dotSize;
        }

        /**
         * <summary>
         * Draws the Plot to the UI
         * </summary>
         */
        public void Draw()
        {
            Raylib.DrawRectangle(x, y, width, height, color);
            foreach(var dot in dots)
            {
                var dotabs = getDotPositionAbsolute(dot);
                int dotx = dotabs.Item1;
                int doty = dotabs.Item2;
                Raylib.DrawCircle(dotx, doty, dotsize, Color.BLACK);
            }
        }

        /**
         * <summary>
         * Adds a Dot to the draw buffer, the dots are internally stored in a List
         * </summary>
         * <param name="x">X Position of the Dot</param>
         * <param name="y">Y Position of the Dot</param>
         */
        public void addDot(double x, double y)
        {
            if (x > maxX)
                maxX = x;
            else if (x < minX)
                minX = x;

            if (y >  maxY)
                maxY = y;
            else if (y < minY)
                minY = y;
            dots.Add(new Tuple<double, double>(x, y));
        }

        /**
         * <summary>
         * Private method to get the absolute xy coordinates of a dot from the relative ones (relative to the graph)
         * </summary>
         */
        private Tuple<int, int> getDotPositionAbsolute(Tuple<double, double> dot)
        {
            var stepx = width / (maxX - minX);
            var stepy = -(height / (maxY - minY));
            var posx = stepx * (dot.Item1 - minX);
            var posy = stepy * (dot.Item2 - minY) + height;

            return new Tuple<int, int>((int)posx + x, (int)posy + y);;
        }

        int width;
        int height;
        int x;
        int y;
        Color color;
        List<Tuple<double, double>> dots;
        double minY;
        double minX;
        double maxY;
        double maxX;
        int dotsize;
    }
}
