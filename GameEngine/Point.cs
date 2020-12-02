using System;
using Raylib_cs;

namespace GameEngine
{
    public class Point
    {
        private int points;
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
  
            Raylib.DrawText(number, 200, 25, 64, Color.GRAY);
        }






    }
}
