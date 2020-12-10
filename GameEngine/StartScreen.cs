using System.Threading;
using System;
using Raylib_cs;
using System.Threading.Tasks;


namespace GameEngine
{
    public class StartScreen
    {
        Rectangle startButton = new Rectangle();
        Rectangle easyButton = new Rectangle();
        Rectangle mediumButton = new Rectangle();
        Rectangle hardButton = new Rectangle();

        private int[] buttonHighlight;
        private int difficulty;

        private int mousePosX;
        private int mousePosY;

        Color lightOrange;

        private string[] text;
        private int smallcountdown;



        public StartScreen()
        {
            text = new string[5];
            buttonHighlight = new int[3];
            difficulty = 0;
            smallcountdown = 240;

            lightOrange = new Color(255,194,102,255);

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
            startButton.height = 100; 
            startButton.width = 300;
            easyButton.height = mediumButton.height = hardButton.height = 50;
            easyButton.width = mediumButton.width = hardButton.width = 100;

            // X & Y position för knappen Start
            startButton.x = 100;
            startButton.y = 400;
            // X & Y position för knappen Easy
            easyButton.x = 100;
            easyButton.y = 525;
            // X & Y position för knappen Medium
            mediumButton.x = 200;
            mediumButton.y = 525;
            // X & Y position för knappen Hard
            hardButton.x = 300;
            hardButton.y = 525;            
        }

        public void DrawStartScreen()
        {
                Raylib.DrawText(text[4], 30, 100, 72, Color.BLACK);
                Raylib.DrawText(text[4], 25, 105, 72, Color.GOLD);

                mousePosX = Raylib.GetMouseX();
                mousePosY = Raylib.GetMouseY();


                if (mousePosX > 100 && mousePosX < 400 && mousePosY > 400 && mousePosY < 500)
                {
                    Raylib.DrawRectangleRec(startButton, lightOrange);
                }
                Raylib.DrawText(text[0], 150, 425, 60, Color.BLACK);


                if (mousePosX > 100 && mousePosX < 200 && mousePosY > 525 && mousePosY < 575)
                {
                    Raylib.DrawRectangleRec(easyButton, Color.LIGHTGRAY);
                }
                else if (buttonHighlight [0] == 1)
                {
                    Raylib.DrawRectangleRec(easyButton, Color.ORANGE);
                }
                Raylib.DrawText(text[1], 120, 535, 24, Color.BLACK);

                if (mousePosX > 200 && mousePosX < 300 && mousePosY > 525 && mousePosY < 575)
                {
                    Raylib.DrawRectangleRec(mediumButton, Color.LIGHTGRAY);
                }
                else if (buttonHighlight [1] == 1)
                {
                    Raylib.DrawRectangleRec(mediumButton, Color.ORANGE);
                }
                Raylib.DrawText(text[2], 212, 535, 24, Color.BLACK);

                if (mousePosX > 300 && mousePosX < 400 && mousePosY > 525 && mousePosY < 575)
                {
                    Raylib.DrawRectangleRec(hardButton, Color.LIGHTGRAY);
                }
                else if (buttonHighlight [2] == 1)
                {
                    Raylib.DrawRectangleRec(hardButton, Color.ORANGE);
                }
                Raylib.DrawText(text[3], 320, 535, 24, Color.BLACK);
                
  
        }

        public bool CheckPressStart()
        {
            if (mousePosX > 100 && mousePosX < 400 && mousePosY > 400 && mousePosY < 500 
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
            if (mousePosX > 100 && mousePosX < 200 && mousePosY > 525 && mousePosY < 575 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                ChangeHighlight(0);
                return 0;
            }
            else if (mousePosX > 200 && mousePosX < 300 && mousePosY > 525 && mousePosY < 575 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                ChangeHighlight(1);
                return 1;
            }
            else if (mousePosX > 300 && mousePosX < 400 && mousePosY > 525 && mousePosY < 575 
            && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) == true)
            {
                ChangeHighlight(2);
                return 2;
            }

            return 0;
        }
        private void ChangeHighlight(int button)
        {
            difficulty = button;
            for (int i = 0; i < 3; i++)
            {
                buttonHighlight[i] = 0;
            }

            buttonHighlight[button] = 1;
        }

        public bool DrawCountDownScreen()
        {
            smallcountdown--;

            string bigNumber = (smallcountdown / 60).ToString();
            Raylib.DrawText(bigNumber, 30, 300, 100, Color.BLACK);
            Raylib.DrawText(bigNumber, 35, 305, 100, Color.GOLD);

            if (smallcountdown == 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetDifficulty()
        {
            return difficulty;
        }

        public void ResetClass()
        {
            difficulty = 0;
            smallcountdown = 240;

            for (int i = 0; i < 3; i++)
            {
                buttonHighlight[i] = 0;   
            }
        }
    }
}
