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
        public static List<Pipe> CheckCollisionList = new List<Pipe>();


        public Pipe()
        {
            x = new int[2];
            y = new int[2];

            int centerOfPipe = generator.Next(600);

            y[1] = -900 + centerOfPipe;
            y[0] = 200 + centerOfPipe;

            x[0] = x[1] = 300;

            CheckCollisionList.Add(this);
        }

        public void Update()
        {
            for (int i = 0; i < 1; i++)
            {
                x[i] += 3;

                y[i] += 3;
            }
        }
        public void Draw()
        {
            Raylib.DrawRectangle((int)x[1], (int)y[1], 100, 800, Color.RED);
            Raylib.DrawRectangle((int)x[0], (int)y[0], 100, 800, Color.BLUE);
            
        }

    }
}
