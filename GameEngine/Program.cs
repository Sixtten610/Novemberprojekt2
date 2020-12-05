using System;
using Raylib_cs;

namespace GameEngine
{
    class Program
    {
        enum GameScreens 
        {
            Start, Game, GameOver
        }
        static void Main(string[] args)
        {
            {
                // WINDOW
                Raylib.InitWindow(500, 800, "Game window");
                Raylib.SetTargetFPS(60);

                // SCREENS
                StartScreen startScreen = new StartScreen();
                GameOverScreen gameOverScreen = new GameOverScreen();
                
                // OBJEKT
                Bird bird = new Bird(100, 250, KeyboardKey.KEY_SPACE);
                Pipe pipe = new Pipe();
                Point points = new Point();

                GameScreens screen = GameScreens.Start;

                // LOGIK
                while (!Raylib.WindowShouldClose())
                {
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                    if (screen == GameScreens.Start)
                    {
                        startScreen.DrawStartScreen();

                        startScreen.CheckPressDifficulty();

                        if (startScreen.CheckPressStart() == true)
                        {
                            pipe.ChangeDifficulty(startScreen.GetDifficulty());
                            points.ChangeDifficulty(startScreen.GetDifficulty());
                            screen = GameScreens.Game;
                        } 
                    }
                    else if (screen == GameScreens.Game)
                    {
                        if (Raylib.CheckCollisionRecs(bird.rectBird, pipe.rectPipeBottom) == true || 
                        Raylib.CheckCollisionRecs(bird.rectBird, pipe.rectPipeTop) == true)
                        {
                            screen = GameScreens.GameOver;
                        }

                        bird.Update();
                        pipe.Update();

                        points.Draw(pipe.PipesPassed());

                        if (bird.rectBird.y >= 750)
                        {
                            screen = GameScreens.GameOver;
                        }
                    }
                    else if (screen == GameScreens.GameOver)
                    {
                        gameOverScreen.GetScore(points.GetPoints());
                        gameOverScreen.DrawGameOverScreen();

                        if (gameOverScreen.CheckPressButton() == true)
                        {
                            bird.ResetClass();
                            pipe.ResetClass();
                            points.ResetClass();
                            startScreen.ResetClass();

                            screen = GameScreens.Start;
                        }
                    }
                    
                    Raylib.EndDrawing();
                }
            }
        }
    }
}
