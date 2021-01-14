using System;
using Raylib_cs;

namespace GameEngine
{
    public class Point
    {
        // int-variabel för att lagra antalet poäng spelaren har
        private int points;
        // variabel för att lagra vilken svårighetsgrad för att användas i UI;t
        private int difficulty;
        // string variabel som lagrar points som har blivit konverterade för att skrivas ut på skärmen
        private string number;

        // Point;s konstruktor, poängen (unintentional pun) med denna är att skriva ut nummer 0 och alla andra element i UI;t
        public Point()
        {
            Draw(0);
        }

        // Draw metoden tar emot 0 eftersom det är startvärdet för poäng-räknaren
        public void Draw(int p)
        {
            // för in p i int-variabeln points
            points = p;

            // konverterar även points till en string för att kunna skriva ut den
            number = Convert.ToString(points);

            // (Grafiskt element) linje för att separera UI;t och spelet i spelet
            Raylib.DrawLine((int)0, (int)100, (int)500, (int)100, Color.GRAY);
  
            // poängen ritas ut
            Raylib.DrawText(number, 225, 25, 72, Color.GRAY);

            // beroende på vilken svårighetsgrad spelaren kör ritar spelet ut olika bokstäver i olika färger
            if (difficulty == 0)
            {
                Raylib.DrawText("E", 450, 35, 32, Color.GREEN);
            }
            else if (difficulty == 1)
            {
                Raylib.DrawText("M", 450, 35, 32, Color.YELLOW);
            }
            else if (difficulty == 2)
            {
                Raylib.DrawText("H", 450, 35, 32, Color.RED);
            }
        }

        // om spelaren väljer att ändra svårighetsgrad under att spelet är uppe tar denna metod emot en ny svårighetsgrad
        // och ändrar klassens difficulty
        public void ChangeDifficulty(int newDifficulty)
        {
            difficulty = newDifficulty;
        }

        // klassen returnerar antalet poäng
        public int GetPoints()
        {
            return points;
        }

        // syftet med ResetClass är att återställa Points variabler så att spelaren kan börja om
        public void ResetClass()
        {
            points = 0;

            difficulty = 0;

            number = "";
        }
    }
}
