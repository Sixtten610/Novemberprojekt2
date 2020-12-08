using System;
using Raylib_cs;

namespace GameEngine
{
    class Program
    {
        // enum för de olika skärmarna i game-whileloopen
        enum GameScreens 
        {
            Start, Game, GameOver
        }
        static void Main(string[] args)
        {
            {
                // WINDOW ###################################################################################

                // bestämmer höjd och bredd i antalet pixlar för speletrutan och ger det titeln 'Game Window'
                Raylib.InitWindow(500, 800, "Game window");
                // sätter också ett låst på 60 fps
                Raylib.SetTargetFPS(60);

                // SCREENS ###################################################################################

                // skapar en instans av klassen StartScreen för att kunna använda klassens funktioner
                StartScreen startScreen = new StartScreen();
                // skapar en instans av klassen gameOverScreen för att kunna använda klassens funktioner
                GameOverScreen gameOverScreen = new GameOverScreen();
                
                // OBJEKT ###################################################################################

                // skapar även en instans av klassen Bird och för int tre parametrar, en för Pipe och en för Point
                Bird bird = new Bird(100, 250, KeyboardKey.KEY_SPACE);
                Pipe pipe = new Pipe();
                Point points = new Point();

                // sätter också enum GameScreens till .Start för att köra start loopen i Window
                GameScreens screen = GameScreens.Start;

                // LOGIK ###################################################################################

                // spel-loop med syfte att köra kod beroende på vad enum variabeln är.
                // Här är all kod för spelet i Main 
                while (!Raylib.WindowShouldClose())
                {
                    // ber Raylib att börja rita
                    Raylib.BeginDrawing();
                    // rensar skärmen med färgen vit
                    Raylib.ClearBackground(Color.WHITE);

                    // om enum = .start ska koden köras för denna if-sats. Här är logiken för introskärmen
                    if (screen == GameScreens.Start)
                    {
                        // efterfrågar metoden i klassen StartScreen att köra kodblocket
                        startScreen.DrawStartScreen();

                        // efterfrågar metoden i klassen StartScreen vilken svårighetsgrad spelaren har tryckt
                        startScreen.CheckPressDifficulty();

                        // om spelaren tryckt på start körs detta kodblock med syfte att preppa för att ta spelaren till game screen
                        if (startScreen.CheckPressStart() == true)
                        {
                            // frågar metod GetDifficulty från startScreen som returnerar ett int-värde vilken är en parameter som sätts
                            // in i klass-metoden ChangeDifficlty i klassen Pipe
                            pipe.ChangeDifficulty(startScreen.GetDifficulty());
                            // samma sak görs även här endast skillnade är att klassmetoden i Point tar emot parametern.
                            points.ChangeDifficulty(startScreen.GetDifficulty());

                            // enum screen ändras sedan till .Game för att låta spelaren starta spelet
                            screen = GameScreens.Game;
                        } 
                    }
                    // if-sats för att rita ut spelet i game-loop
                    else if (screen == GameScreens.Game)
                    {
                        // om rekangeln i klassen bird och botten eller toppen av rektangeln från klassen Pipe
                        // krockar med varandra körs denna if-sats vilket avsluta spelet och startar gameover skärmen.
                        if (Raylib.CheckCollisionRecs(bird.rectBird, pipe.rectPipeBottom) == true || 
                        Raylib.CheckCollisionRecs(bird.rectBird, pipe.rectPipeTop) == true)
                        {
                            screen = GameScreens.GameOver;
                        }

                        // tillkallar klassmetoden Update i både Pipe och Bird med syfte att uppdatera spelet så att
                        // saker och ting händer.
                        bird.Update();
                        pipe.Update();
                        
                        // tillkallar metoden PipesPassed som returnerar en intvariabel vilken sätts in i klassmetoden Draw i Points
                        // med syfte att uppdatera poäng när spelaren passerar ett rör i spelet
                        points.Draw(pipe.PipesPassed());

                        // om spelaren nuddar botten(golvet) av spelet dör den därmed ändras screens till game over
                        if (bird.rectBird.y >= 750)
                        {
                            screen = GameScreens.GameOver;
                        }
                    }
                    // if-sats för Game Over skärmen som visas när spelaren förlorat.
                    else if (screen == GameScreens.GameOver)
                    {
                        // poängen spelaren fick under spelets gång hämtas från klassmetoden GetPoints i klassen Points
                        // parametern sätts sedan in i klassen gameOverScreen med syfte att rita ut (Score; x)
                        gameOverScreen.GetScore(points.GetPoints());
                        // tillkallar klassmetod Draw för att rita ut game over skärmen och dess knappar
                        gameOverScreen.DrawGameOverScreen();
                        
                        // om spelaren väljer att gå tillbaka till menyn för att spela en gång till tillkallas
                        // reset-klassmetoderna för alla klasser med variabler vilka måste återställas och sedan ändras
                        // skärmen till .Start
                        if (gameOverScreen.CheckPressButton() == true)
                        {
                            bird.ResetClass();
                            pipe.ResetClass();
                            points.ResetClass();
                            startScreen.ResetClass();

                            screen = GameScreens.Start;
                        }
                    }
                    
                    // ber Raylib att sluta rita
                    Raylib.EndDrawing();
                }
            }
        }
    }
}
