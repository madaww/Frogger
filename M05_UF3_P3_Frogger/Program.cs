using System;
using System.Collections.Generic;
using System.Linq;
using static M05_UF3_P3_Frogger.Utils;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Utils.MAP_WIDTH, Utils.MAP_HEIGHT);
            bool[] speedPlayer = { false, false, false, false, false, false, false, false, false, false, false, false, false };
            ConsoleColor[] colorsLine = { ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Black, ConsoleColor.Green };
            bool[] damageElement = { false, false, false, false, false, false, false, true, true, true, true, true, false };
            bool[] damageBackground = { false, true, true, true, true, true, false, false, false, false, false, false, false };
            float[] elementsPercents = { 0, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0, 0.5f, 0.4f, 0.3f, 0.2f, 0.2f, 0 };
            char[] elementsChar = { ' ', Utils.charLogs, Utils.charLogs, Utils.charLogs, Utils.charLogs, Utils.charLogs, ' ', Utils.charCars, Utils.charCars, Utils.charCars, Utils.charCars, Utils.charCars, ' ' };
            List<Lane> lineas = new List<Lane>();
            for (int i = 0; i < Utils.MAP_HEIGHT;i++)
            {
                if (i < 7)
                {
                    lineas.Add(new Lane(i, speedPlayer[i], colorsLine[i], damageElement[i], damageBackground[i], elementsPercents[i], elementsChar[i], Utils.colorsLogs.ToList()));
                }
                else
                {
                    lineas.Add(new Lane(i, speedPlayer[i], colorsLine[i], damageElement[i], damageBackground[i], elementsPercents[i], elementsChar[i], Utils.colorsCars.ToList()));
                }
            }
            Player player= new Player();
            bool finish = false;
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;
            while (!finish)
            {
                foreach(Lane lane in lineas)
                {
                    lane.Update();
                    lane.Draw();
                }
                player.Draw(lineas);
                gameState = player.Update(Utils.Input(),lineas);
                if (gameState.Equals(Utils.GAME_STATE.LOOSE))
                {
                    finish = true;
                } 
                else if (gameState.Equals(Utils.GAME_STATE.WIN))
                {
                    finish= true;
                }
                TimeManager.NextFrame();
            }
            if (gameState.Equals(Utils.GAME_STATE.WIN))
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won");
            }
            else
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lost");
            }
        }
    }
}
