using System;
using Raylib_cs;

namespace GameEngine
{
    public class Bird
    {
        private float x;
        private float y;
        private KeyboardKey Space;

        public Bird(float xMove, float yMove, KeyboardKey upSpace)
        {
            x = xMove;
            y = yMove;
            
            Space = upSpace;
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(Space) && y > 0)
            {
                y -= 10f;
            }
            else if (y < 750)
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
