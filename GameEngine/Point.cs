using System;
using Raylib_cs;

namespace GameEngine
{
    public class Point
    {
        private int points;
        private int difficulty;
        private string number;


        public Point(int d)
        {
            difficulty = d;

            Draw(0);
        }

        public void Draw(int p)
        {
            points = p;

            number = Convert.ToString(points);

            Raylib.DrawLine((int)0, (int)100, (int)500, (int)100, Color.GRAY);
  
            Raylib.DrawText(number, 225, 25, 72, Color.GRAY);
            
            if (difficulty == 1)
            {
                Raylib.DrawText("H", 450, 35, 32, Color.RED);
            }
            else if (difficulty == 2)
            {
                Raylib.DrawText("I", 450, 35, 32, Color.YELLOW);
            }
        }






    }
}
