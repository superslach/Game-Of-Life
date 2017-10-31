using System;

namespace Game_of_Life
{



    internal class Program
    {

        private const int Heigth = 40;//heigth of grid
        private const int Width = 70;//width of grid
        private const uint MaxGenerations = 500;//number of generations

        private static void Main(string[] args)
        {

            int Generations = 0;
            Console.ReadKey();

            Simulation sim = new Simulation(Heigth, Width);

            while (Generations++ < MaxGenerations)
            {
                sim.DrawAndGrow();
                System.Threading.Thread.Sleep(50);//time to get another generation
                Console.WriteLine();
            }
        }
    }
}

//penser a retirer 2 affichage sur heigth et weigth afin de mettre des cellules mortes sur les cotés