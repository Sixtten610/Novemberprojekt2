using System;
using Raylib_cs;

namespace GameEngine
{
    public class Point
    {
        private int points;
        private int difficulty;
        private string number;


        public Point()
        {
            Draw(0);
        }

        public void Draw(int p)
        {
            points = p;

            number = Convert.ToString(points);

            Raylib.DrawLine((int)0, (int)100, (int)500, (int)100, Color.GRAY);
  
            Raylib.DrawText(number, 225, 25, 72, Color.GRAY);

            if (difficulty == 0)
            {
                Raylib.DrawText("E", 450, 35, 32, Color.GREEN);
            }
            if (difficulty == 1)
            {
                Raylib.DrawText("M", 450, 35, 32, Color.YELLOW);
            }
            else if (difficulty == 2)
            {
                Raylib.DrawText("H", 450, 35, 32, Color.RED);
            }
        }
        public void ChangeDifficulty(int NewDifficulty)
        {
            difficulty = NewDifficulty;
        }
    }
}
