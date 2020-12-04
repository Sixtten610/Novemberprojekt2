using System;
using Raylib_cs;

namespace GameEngine
{
    public class StartScreen
    {
        Rectangle StartButton = new Rectangle();

        Rectangle Ebutton = new Rectangle();
        Rectangle Mbutton = new Rectangle();
        Rectangle Hbutton = new Rectangle();

        private int MousePosX;
        private int MousePosY;

        Color LightOrange;

        private string[] text;



        public StartScreen()
        {
            text = new string[5];

            LightOrange = new Color(255,194,102,255);

            SetUpGraphics();

        }

        private void SetUpGraphics()
        {
            text[4] = "Flappy BloX";
            text[0] = "START";


            StartButton.height = 100; 
            StartButton.width = 300;

            StartButton.x = 100;
            StartButton.y = 400;

            Ebutton.height = Mbutton.height = Hbutton.height = 100;
            Ebutton.width = Mbutton.width = Hbutton.width = 100;            
        }

        public void DrawStartScreen()
        {
                Raylib.DrawText(text[4], 30, 100, 72, Color.BLACK);
                Raylib.DrawText(text[4], 25, 105, 72, Color.GOLD);


                MousePosX = Raylib.GetMouseX();
                MousePosY = Raylib.GetMouseY();

                if (MousePosX > 100 && MousePosX < 400 && MousePosY > 400 && MousePosY < 500)
                {
                    Raylib.DrawRectangleRec(StartButton, LightOrange);
                }
                Raylib.DrawText(text[0], 150, 425, 60, Color.BLACK);
                
  
        }

        public bool CheckPressStart()
        {
            if (MousePosX > 100 && MousePosX < 400 && MousePosY > 400 && MousePosY < 500 && 
            Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
