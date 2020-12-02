using System;
using Raylib_cs;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                // Temporary code
                int difficulty = 1;

                // WINDOW
                Raylib.InitWindow(500, 800, "Game window");
                Raylib.SetTargetFPS(60);

                // OBJEKT
                Bird Bird = new Bird(100, 250, KeyboardKey.KEY_SPACE);

                Pipe Pipe = new Pipe(difficulty);

                Point Points = new Point(difficulty);


                // LOGIK
                while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    Bird.Update();
                    Pipe.Update();

                    Bird.Draw();
                    Pipe.Draw();

                    Points.Draw(Pipe.PipesPassed());


                    Raylib.EndDrawing();
                }
            }
        }
    }
}
