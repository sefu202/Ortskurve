using System;
using System.Numerics;
using Raylib_cs;


namespace Ortskurve
{
    class Program
    {
        /**
         * <summary>
         * This program plots locus diagrams. 
         * It was written by me to try C# and learn something about complex numbers
         * </summary>
         */
        public static void Main(string[] args)
        {
            Diagram myDiagram = new Diagram(0, 0, 1000, 1000, Color.RAYWHITE, 2);
            Raylib.InitWindow(1200, 1000, "Hello World");
            Complex j = Complex.ImaginaryOne;
            Complex myComplex = new Complex();

            for (int i = 0; i < 3600; i++){
                myComplex = Complex.Exp(j * i / 500);
                myDiagram.addDot(myComplex.Real, myComplex.Imaginary);
            }

            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.DrawFPS(10,10);
                Raylib.ClearBackground(Color.WHITE);

                myDiagram.Draw();

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
