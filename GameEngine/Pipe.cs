using System;
using Raylib_cs;

namespace GameEngine
{
    public class Pipe
    {
        private int difficulty;
        private Random generator = new Random();
        public Rectangle rectPipeTop = new Rectangle();
        public Rectangle rectPipeBottom = new Rectangle();
        private int NumberOfPassedPipes;

        public Pipe()
        {
            rectPipeBottom.height = rectPipeTop.height = 800;
            rectPipeBottom.width = rectPipeTop.width = 80;

            NewPipe();
            NumberOfPassedPipes = 0;
        }
        private void NewPipe()
        {
            int centerOfPipe = generator.Next(600);

            rectPipeTop.y = -900 + centerOfPipe + difficulty * 75;
            rectPipeBottom.y = 200 + centerOfPipe;

            rectPipeTop.x = rectPipeBottom.x = 500;
        }

        public void Update()
        {
            if (difficulty == 0)
            {
                rectPipeTop.x -= 3;
                rectPipeBottom.x -= 3;
            }
            else if (difficulty == 1)
            {
                rectPipeTop.x -= 5;
                rectPipeBottom.x -= 5;
            }
            else if (difficulty == 2)
            {
                rectPipeTop.x -= 6;
                rectPipeBottom.x -= 6;
            }

            if (rectPipeBottom.x < -120)
            {
                NewPipe();
            }
            if (rectPipeBottom.x == 50)
            {
                NumberOfPassedPipes ++;
            }
        }

        public int PipesPassed()
        {
            return NumberOfPassedPipes;
        }

        public void Draw()
        {
            //Raylib.DrawRectangle((int)x[i], (int)y[i], 80, 800, Raylib_cs.Color.BLACK);  
            Raylib.DrawRectangleRec(rectPipeTop, Color.BLACK);
            Raylib.DrawRectangleRec(rectPipeBottom, Color.BLACK);
        }

        public void ChangeDifficulty(int NewDifficulty)
        {
            difficulty = NewDifficulty;
        }

    }
}
