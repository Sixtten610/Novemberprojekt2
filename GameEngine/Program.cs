using System;
using Raylib_cs;

namespace GameEngine
{
    class Program
    {

        enum GameScreens 
        {
            Start,
            Game,
            GameOver
        }

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


                StartScreen startScreen = new StartScreen();

                Point Points = new Point(difficulty);


                GameScreens screen = GameScreens.Start;

                // LOGIK
                while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    if (screen == GameScreens.Start)
                    {
                        startScreen.DrawStartScreen();

                        if (startScreen.CheckPressStart() == true)
                        {
                            screen = GameScreens.Game;
                        } 

                    }
                    else if (screen == GameScreens.Game)
                    {
                        if (Raylib.CheckCollisionRecs(Bird.rectBird, Pipe.rectPipeBottom) == true || 
                        Raylib.CheckCollisionRecs(Bird.rectBird, Pipe.rectPipeTop) == true)
                        {
                            //screen = GameScreens.GameOver;
                            System.Console.WriteLine("Hej");
                        }

                        Bird.Update();
                        Pipe.Update();

                        Bird.Draw();
                        Pipe.Draw();

                        Points.Draw(Pipe.PipesPassed());




                    }
                    else if (screen == GameScreens.GameOver)
                    {
                         
                    }
                    

                    Raylib.EndDrawing();
                }
            }
        }
    }
}
