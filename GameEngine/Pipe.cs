using System;
using Raylib_cs;

namespace GameEngine
{
    public class Pipe
    {
        private int[] x;
        private int[] y;
        private int difficulty;
        private Random generator = new Random();
        private int NumberOfPassedPipes;

        public Pipe(int d)
        {
            x = new int[2];
            y = new int[2];
            difficulty = d;

            NewPipe();
            NumberOfPassedPipes = 0;
        }
        private void NewPipe()
        {
            int centerOfPipe = generator.Next(600);

            y[1] = -900 + centerOfPipe + difficulty * 75;
            y[0] = 200 + centerOfPipe;

            x[0] = x[1] = 500;
        }

        public void Update()
        {
            
            for (int i = 0; i < 2; i++)
            {
                if (difficulty == 0)
                {
                    x[i] -= 3;
                }
                else if (difficulty == 1)
                {
                    x[i] -= 5;
                }
                else if (difficulty == 2)
                {
                    x[i] -= 6;
                }
            }

            if (x[0] < -120)
            {
                NewPipe();
            }
            if (x[0] == 50)
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
            for (int i = 0; i < 2; i++)
            {
                Raylib.DrawRectangle((int)x[i], (int)y[i], 80, 800, Raylib_cs.Color.BLACK);  
            }
        }

    }
}
