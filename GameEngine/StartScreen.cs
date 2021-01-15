using System;
using Raylib_cs;


namespace GameEngine
{
    public class StartScreen
    {
        // rektanglarna(hitboxes) för startknappen och svårighetsgrad-knapparna
        Rectangle startButton = new Rectangle();
        Rectangle easyButton = new Rectangle();
        Rectangle mediumButton = new Rectangle();
        Rectangle hardButton = new Rectangle();

        // int-array med syfte att lagra vilken knapp som ska vara highlightad
        private int[] buttonHighlight;
        // int-variabel för difficulty
        private int difficulty;

        // int-variabler för att lagra muspekarens position, syftet med dessa är att kunna jämnföra om musen är ovanpå en hitbox
        private int mousePosX;
        private int mousePosY;

        // färg orandge
        Color lightOrange;

        // string-arrayen lagrar namnen för de olika knapparna
        private string[] text;
        // int-varriabel för att lagra nedräkningsnummret
        private int smallCountDown;
        // lagrar ett nummer för att start-knapps-animationen ska fungerar korrekt
        private int startButtonFlash;


        // konstruktorn för StartScreen definierar först String-arrayen text och buttonHighlight
        // sedan ändras difficulty smallCountDown och startButtonFlash till korrekta konstanter.
        // färg deffinieras också & en metod tillkallas
        public StartScreen()
        {
            text = new string[5];
            buttonHighlight = new int[3];
            difficulty = 0;
            smallCountDown = 240;
            startButtonFlash = 50;

            lightOrange = new Color(255,194,102,120);

            SetUpGraphics();
        }
        
        // syftet med denna metod är att sprida ut koden och göra klassen mer väldisponerad och sorterad.
        // här deffinieras text och höjd & bredd samt position för objekten i spelet
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

        // Denna metod ritar ut hella startskärmen
        public void DrawStartScreen()
        {
                // Här är koden för Rubriken
                Raylib.DrawText(text[4], 30, 100, 72, Color.BLACK);
                Raylib.DrawText(text[4], 25, 105, 72, Color.GOLD);
                // muspositionen uppdateras också
                mousePosX = Raylib.GetMouseX();
                mousePosY = Raylib.GetMouseY();

                // om musen är över x & y kordinat kommer z knapp att bli orange för att highlighta och visa spelaren
                // att knappen kan interageras med 
                if (mousePosX > 100 && mousePosX < 400 && mousePosY > 400 && mousePosY < 500)
                {
                    Raylib.DrawRectangleRec(startButton, lightOrange);
                }
                
                if (startButtonFlash > 50)
                {
                    Raylib.DrawText(text[0], 150, 425, 60, Color.BLACK);
                }
                else
                {
                    Raylib.DrawText(text[0], 150, 425, 60, Color.GOLD);
                } 
                if (startButtonFlash != 100)
                {
                    startButtonFlash++;
                }
                else
                {
                    startButtonFlash = 0;
                }
                // om spelaren trycker på en knapp blir den grå när spelaren lämnar med musen
                // vilket indikerar att et alternativ är valt
                if (mousePosX > 100 && mousePosX < 200 && mousePosY > 525 && mousePosY < 575)
                {
                    Raylib.DrawRectangleRec(easyButton, Color.LIGHTGRAY);
                }
                else if (buttonHighlight [0] == 1)
                {
                    Raylib.DrawRectangleRec(easyButton, Color.GOLD);
                }
                Raylib.DrawText(text[1], 120, 535, 24, Color.BLACK);

                if (mousePosX > 200 && mousePosX < 300 && mousePosY > 525 && mousePosY < 575)
                {
                    Raylib.DrawRectangleRec(mediumButton, Color.LIGHTGRAY);
                }
                else if (buttonHighlight [1] == 1)
                {
                    Raylib.DrawRectangleRec(mediumButton, Color.GOLD);
                }
                Raylib.DrawText(text[2], 212, 535, 24, Color.BLACK);

                if (mousePosX > 300 && mousePosX < 400 && mousePosY > 525 && mousePosY < 575)
                {
                    Raylib.DrawRectangleRec(hardButton, Color.LIGHTGRAY);
                }
                else if (buttonHighlight [2] == 1)
                {
                    Raylib.DrawRectangleRec(hardButton, Color.GOLD);
                }
                Raylib.DrawText(text[3], 320, 535, 24, Color.BLACK);
                
  
        }
        
        // returnerar true eller false ifall spelaren tryckt på start
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

        //
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

        // metod för nedräkning, körs 60gng/sekunden och för vare 60 räknar den från 3..2..1..
        public bool DrawCountDownScreen()
        {
            smallCountDown--;

            string bigNumber = (smallCountDown / 60).ToString();
            Raylib.DrawText(bigNumber, 225, 300, 100, Color.BLACK);
            Raylib.DrawText(bigNumber, 230, 305, 100, Color.GOLD);

            if (smallCountDown == 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // returnerar int-variabeln difficulty
        public int GetDifficulty()
        {
            return difficulty;
        }

        // syftet med ResetClass är att återställa Startscreen variabler så att spelaren kan börja om
        public void ResetClass()
        {
            difficulty = 0;
            smallCountDown = 240;

            for (int i = 0; i < 3; i++)
            {
                buttonHighlight[i] = 0;   
            }
        }
    }
}
