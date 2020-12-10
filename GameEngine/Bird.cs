using System;
using Raylib_cs;

namespace GameEngine
{
    public class Bird
    {
        // skapar en rektangel(hitbox) för spelaren
        public Rectangle rectBird = new Rectangle();
        // skapar en enum för KeyBoardKey.Space
        private KeyboardKey Space;

        // konstruktor för klassen Bird, här hämtas parametrar för x & y position samt KeyBoardKey.Space
        // även bestäms rektangelns storlek till 50x50
        public Bird(float xMove, float yMove, KeyboardKey upSpace)
        {
            rectBird.x = xMove;
            rectBird.y = yMove;
            rectBird.width = rectBird.height = 50;
            
            Space = upSpace;
        }

        // klassmetoden Updates syfte är att förflytta spelaren upp eller ned beroende på om spelaren trycker på mellanslag
        public void Update()
        {
            // om spelaren trycker på mellanslag minskas y värdet vilket i sin tur leder till att spelaren höjer positionen på bird
            if (Raylib.IsKeyDown(Space) && rectBird.y > 0)
            {
                rectBird.y -= 10f;
            }
            // annars ökas y värdet vilket gör att spelaren sjunker
            else if (rectBird.y < 750)
            {
                rectBird.y += 8f;
            }
            // Update tillkallar också metoden Draw i slutet
            Draw();
        }

        // i metoden Draw ritas rektangeln för spelaren ut i färgen svart
        private void Draw()
        {
            Raylib.DrawRectangleRec(rectBird, Color.GOLD);
        }
        
        // reset-metoden återställer spelarens x och y position till ursprungsplatsen
        public void ResetClass()
        {
            rectBird.x = 100;
            rectBird.y = 250;
        }

    }
}
