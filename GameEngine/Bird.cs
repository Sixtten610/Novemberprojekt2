using System;
using Raylib_cs;

namespace GameEngine
{
    public class Bird
    {
        public float x;
        public float y;
        public KeyboardKey Space;

        public Bird(float xMove, float yMove, KeyboardKey upSpace)
        {
        
         y = yMove;
         Space = upSpace;
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(Space))
            {
                y -= 10f;
            }
            else if (y > 0 && y < 750)
            {
                y += 8f;
            }
        }
        public void Draw()
        {
            Raylib.DrawRectangle((int)x, (int)y, 50, 50, Color.BLACK);
        }


    }
}
