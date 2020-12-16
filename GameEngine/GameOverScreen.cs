using System;
using Raylib_cs;

namespace GameEngine
{
    public class GameOverScreen
    {
        private string[] text;

        private int score = 0;


        public GameOverScreen()
        {
            text = new string[3];
            text[0] = "Game Over";
            text[1] = "Main Menu";
            text[2] = "Score:";
        }

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

        public void SetScore(int s)
        {
            score = s;
        }

        public void ResetClass()
        {
            score = 0;
        }
    }
}
