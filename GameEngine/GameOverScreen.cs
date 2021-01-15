using System;
using Raylib_cs;

namespace GameEngine
{
    public class GameOverScreen
    {
        // string-array som lagrar txten på knapparna
        private string[] text;
        // int-variabel som lagrar poängen som spelaren hade när den dog
        private int score = 0;

        // i konstruktorn skapas string-arrayen och texten förs in
        public GameOverScreen()
        {
            text = new string[3];
            text[0] = "Game Over";
            text[1] = "Main Menu";
            text[2] = "Score:";
        }

        // I denna metod är all kod för att rita ut det grafiska på skärmen. Samt registrera om spelaren hovrar över en knapp.
        public void DrawGameOverScreen()
        {
            Raylib.DrawText(text[2] + " " + score, 70, 100, 32, Color.BLACK);

            Raylib.DrawText(text[0], 70, 300, 70, Color.BLACK);

            if (Raylib.GetMouseX() > 100 && Raylib.GetMouseX() < 400 && Raylib.GetMouseY() > 500 && Raylib.GetMouseY() < 600)
            {
                Raylib.DrawRectangle(100, 500, 300, 100, Color.GOLD);
            }
            else
            {
                Raylib.DrawRectangle(100, 500, 300, 100, Color.LIGHTGRAY);
            }
            Raylib.DrawText(text[1], 130, 530, 48, Color.BLACK);

        }

        // metod som returnerar true/false om spelaren tryckt på main menu knappen
        public bool CheckPressButton()
        {
            if (Raylib.GetMouseX() > 100 && Raylib.GetMouseX() < 400 && Raylib.GetMouseY() > 500 && Raylib.GetMouseY() < 600 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // metoden tar emot en parameter som int-variabeln score ändras till
        public void SetScore(int s)
        {
            score = s;
        }

        // syftet med ResetClass är att återställa GameOverScreens variabel så att spelaren kan börja om
        public void ResetClass()
        {
            score = 0;
        }
    }
}
