using System;
using Raylib_cs;

namespace GameEngine
{
    public class Bird
    {
        public Rectangle rectBird = new Rectangle();
        private KeyboardKey Space;


        public Bird(float xMove, float yMove, KeyboardKey upSpace)
        {
            rectBird.x = xMove;
            rectBird.y = yMove;
            rectBird.width = rectBird.height = 50;
            
            Space = upSpace;
        }

        public void Update()
        {
            if (Raylib.IsKeyDown(Space) && rectBird.y > 0)
            {
                rectBird.y -= 10f;
            }
            else if (rectBird.y < 750)
            {
                rectBird.y += 8f;
            }

            Draw();


        }
        private void Draw()
        {
            Raylib.DrawRectangleRec(rectBird, Color.BLACK);
        }
        
        public void ResetClass()
        {
            rectBird.x = 100;
            rectBird.y = 250;
        }

    }
}
