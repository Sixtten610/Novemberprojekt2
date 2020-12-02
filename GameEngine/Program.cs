using System;
using Raylib_cs;

namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Raylib.InitWindow(500, 800, "Game window");
                Raylib.SetTargetFPS(60);

                Bird BirdPlayer = new Bird(100, 250, KeyboardKey.KEY_SPACE);

                Pipe Pipe = new Pipe();

                



                while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    BirdPlayer.Update();
                    Pipe.Update();

                    BirdPlayer.Draw();
                    Pipe.Draw();

                    Raylib.EndDrawing();
                }
            }
        }
    }
}
