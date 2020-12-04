using System;
using Raylib_cs;

namespace GameEngine
{
    public class StartScreen
    {
        Rectangle StartButton = new Rectangle();
        Rectangle EasyButton = new Rectangle();
        Rectangle MediumButton = new Rectangle();
        Rectangle HardButton = new Rectangle();

        private int[] ButtonHighlight;
        private int Difficulty;

        private int MousePosX;
        private int MousePosY;

        Color LightOrange;

        private string[] text;



        public StartScreen()
        {
            text = new string[5];
            ButtonHighlight = new int[3];
            Difficulty = 0;

            LightOrange = new Color(255,194,102,255);

            SetUpGraphics();
        }

        private void SetUpGraphics()
        {
            text[4] = "Flappy BloX";
            text[0] = "START";

            text[1] = "Easy";
            text[2] = "Medium";
            text[3] = "Hard";

            // Höjd och bredd för alla knappar
            StartButton.height = 100; 
            StartButton.width = 300;
            EasyButton.height = MediumButton.height = HardButton.height = 50;
            EasyButton.width = MediumButton.width = HardButton.width = 100;

            // X & Y position för knappen Start
            StartButton.x = 100;
            StartButton.y = 400;
            // X & Y position för knappen Easy
            EasyButton.x = 100;
            EasyButton.y = 525;
            // X & Y position för knappen Medium
            MediumButton.x = 200;
            MediumButton.y = 525;
            // X & Y position för knappen Hard
            HardButton.x = 300;
            HardButton.y = 525;            
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


                if (MousePosX > 100 && MousePosX < 200 && MousePosY > 525 && MousePosY < 575)
                {
                    Raylib.DrawRectangleRec(EasyButton, Color.LIGHTGRAY);
                }
                else if (ButtonHighlight [0] == 1)
                {
                    Raylib.DrawRectangleRec(EasyButton, Color.ORANGE);
                }
                Raylib.DrawText(text[1], 120, 535, 24, Color.BLACK);

                if (MousePosX > 200 && MousePosX < 300 && MousePosY > 525 && MousePosY < 575)
                {
                    Raylib.DrawRectangleRec(MediumButton, Color.LIGHTGRAY);
                }
                else if (ButtonHighlight [1] == 1)
                {
                    Raylib.DrawRectangleRec(MediumButton, Color.ORANGE);
                }
                Raylib.DrawText(text[2], 212, 535, 24, Color.BLACK);

                if (MousePosX > 300 && MousePosX < 400 && MousePosY > 525 && MousePosY < 575)
                {
                    Raylib.DrawRectangleRec(HardButton, Color.LIGHTGRAY);
                }
                else if (ButtonHighlight [2] == 1)
                {
                    Raylib.DrawRectangleRec(HardButton, Color.ORANGE);
                }
                Raylib.DrawText(text[3], 320, 535, 24, Color.BLACK);
                
  
        }

        public bool CheckPressStart()
        {
            if (MousePosX > 100 && MousePosX < 400 && MousePosY > 400 && MousePosY < 500 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CheckPressDifficulty()
        {
            if (MousePosX > 100 && MousePosX < 200 && MousePosY > 525 && MousePosY < 575 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                ChangeHighlight(0);
                return 0;
            }
            else if (MousePosX > 200 && MousePosX < 300 && MousePosY > 525 && MousePosY < 575 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                ChangeHighlight(1);
                return 1;
            }
            else if (MousePosX > 300 && MousePosX < 400 && MousePosY > 525 && MousePosY < 575 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                ChangeHighlight(2);
                return 2;
            }

            return 0;
        }
        private void ChangeHighlight(int button)
        {
            Difficulty = button;
            for (int i = 0; i < 3; i++)
            {
                ButtonHighlight[i] = 0;
            }

            ButtonHighlight[button] = 1;
        }

        public int GetDifficulty()
        {
            return Difficulty;
        }
    }
}
