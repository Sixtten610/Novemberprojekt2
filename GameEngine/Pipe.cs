using System;
using Raylib_cs;

namespace GameEngine
{
    public class Pipe
    {
        // int-variabeln defficulty lagrar vilken svårighetsgrad spelet (i det här fallet pipes) har.
        private int difficulty;
        // generator är en slumpgenerator med syfte att slumpa fram y position för rören när det skapas ett nytt.
        private Random generator = new Random();
        // detta är rektangeln för den övre biten av röret.
        public Rectangle rectPipeTop = new Rectangle();
        // samt undre delen av röret för att kunna skapa en glipa mellan dem.
        public Rectangle rectPipeBottom = new Rectangle();
        // numberOfPassedPipes lagrar antal rör spelaren paserat. Detta med syfte att räk na poäng.
        private int numberOfPassedPipes;

        // I konstruktorn Pipe bestäms höjd och bredd för den övre & undre biten av röret. 
        // Även tillkallas metoden NewPipe() som kort, skapar ett nytt rör. Även definieras int-variabeln till 0.
        // med syfte att sätta upp Pipes för att vara redo att användas.
        public Pipe()
        {
            rectPipeBottom.height = rectPipeTop.height = 800;
            rectPipeBottom.width = rectPipeTop.width = 80;

            NewPipe();
            numberOfPassedPipes = 0;
        }
        
        // I NewPipe slumpas y-positionen för röret med syfte att skapa variation när man tar sig igenom nivån.
        private void NewPipe()
        {
            // här slumpas centerpositionen som båda delarna av rören utgår från.
            int centerOfPipe = generator.Next(600);

            // rörets höjd tas till hänsyn, sedan adderas den slumpade talet för att få y-positionen röret ska få.
            // Samt beroende på vilken svårighetsgrad spelet har ändras glipan mellan rören. 
            rectPipeTop.y = -900 + centerOfPipe + difficulty * 75;
            // 200 adderas med det slumpade talet för att positionera den undre delen av röret på rätt plats.
            rectPipeBottom.y = 200 + centerOfPipe;

            // sedan definieras x-position precis utanför view-port.
            // Med syfte att användaren inte ska se när det skapas ett nytt rör
            rectPipeTop.x = rectPipeBottom.x = 500;
        }
        
        // I Update förflyttas rören bakåt i banan (men framåt för spelaren).
        public void Update()
        {
            // Beroende på vilken svårighetsgrad spelaren valt förflyttas rören olika snabbt.
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

            // När röret åker utanför view-port skapas ett nytt, dessutom får spelaren ett poäng om den paserar ett rör.
            if (rectPipeBottom.x < -120)
            {
                NewPipe();
            }
            if (rectPipeBottom.x == 50)
            {
                numberOfPassedPipes ++;
            }

            // Sedan tillkallas metoden Draw. 
            Draw();
        }

        // Denna metod returnerar antalet passerade rör med syfte att hämta poängen.
        public int PipesPassed()
        {
            return numberOfPassedPipes;
        }

        // Metoden ritar ut den övre och undre rektangeln i svart.
        private void Draw()
        {  
            Raylib.DrawRectangleRec(rectPipeTop, Color.BLACK);
            Raylib.DrawRectangleRec(rectPipeBottom, Color.BLACK);
        }

        // Denna metod har syftet att ändra på svårighetsgraden.
        public void ChangeDifficulty(int newDifficulty)
        {
            difficulty = newDifficulty;
        }

        // syftet med ResetClass är att återställa Pipes variabler så att spelaren kan börja om.
        public void ResetClass()
        {
            difficulty = 0;
            NewPipe();
            rectPipeTop.x = 500;
            rectPipeBottom.x = 500;
            numberOfPassedPipes = 0;
        }

    }
}
