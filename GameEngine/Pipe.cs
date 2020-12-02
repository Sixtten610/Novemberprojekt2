using System;
using System.Collections.Generic;
using Raylib_cs;

namespace GameEngine
{
    public class Pipe
    {
        private int[] x;
        private int[] y;
        private Random generator = new Random();

        private int NumberOfPassedPipes;

        public Pipe()
        {
            x = new int[2];
            y = new int[2];

            NewPipe();

            NumberOfPassedPipes = 0;
        }

        private void NewPipe()
        {
            int centerOfPipe = generator.Next(600);

            y[1] = -900 + centerOfPipe;
            y[0] = 200 + centerOfPipe;

            x[0] = x[1] = 500;
        }

        public void Update()
        {
            for (int i = 0; i < 2; i++)
            {
                x[i] -= 3;
            }

            if (x[0] < -100)
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
                Raylib.DrawRectangle((int)x[i], (int)y[i], 100, 800, Color.BLACK);    
            }
        }

    }
}
