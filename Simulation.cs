using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Simulation
    {
        
            private int Heigth;
            private int Width;
            private bool[,] cells;

            /// <summary>
            /// Initializes a new Game of Life.
            /// </summary>
            /// <param name="Heigth">Heigth of the cell field.</param>
            /// <param name="Width">Width of the cell field.</param>

            public Simulation(int Heigth, int Width)
            {
                this.Heigth = Heigth;
                this.Width = Width;
                cells = new bool[Heigth, Width];
                GenerateField();
            }

            /// <summary>
            /// Advances the game by one generation and prints the current state to console.
            /// </summary>
            public void DrawAndGrow()
            {
                DrawGame();
                Grow();
            }

            /// <summary>
            /// Advances the game by one generation according to GoL's ruleset.
            /// </summary>

            private void Grow()
            {
                for (int i = 0; i < Heigth; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        int numOfAliveNeighbours = GetNeighbours(i, j);

                        if (cells[i, j])
                        {
                            if (numOfAliveNeighbours < 2)//constraint : any live cell with fewer than two live neighbours dies
                            {
                                cells[i, j] = false;
                            }

                            if (numOfAliveNeighbours > 3)//constraint : any live cell with two or three live neighbours dies
                            {
                                cells[i, j] = false;
                            }
                            if (numOfAliveNeighbours == 2)
                        {
                            cells[i, j] = true;
                        }
                        if (numOfAliveNeighbours == 3)
                        {
                            cells[i, j] = true;
                        }
                    }
                        else
                        {
                            if (numOfAliveNeighbours == 3)//constraint : any cell with axactly three live neighbours becomes a live cell
                            {
                                cells[i, j] = true;
                            }
                        }
                    }
                }
            }

        #region GetNeighbours
        private int GetNeighbours(int x, int y)//return the number of alive neighbours for checks how many alive nighbors are in the vicinity of a cell
            {
                int NumOfAliveNeighbours = 0;

                for (int i = x - 1; i < x + 2; i++)//X coordinate of the cell
            {
                    for (int j = y - 1; j < y + 2; j++)//Y coordinate of the cell
                {
                        if (!((i < 0 || j < 0) || (i >= Heigth || j >= Width)))
                        {
                            if (cells[i, j] == true) NumOfAliveNeighbours++;
                        }
                    }
                }
                return NumOfAliveNeighbours;
            }

        #endregion

        #region DrawGame
        private void DrawGame()//draws the game to the console 
            {
                for (int i = 0; i < Heigth; i++)//heigth draw
                {
                    for (int j = 0; j < Width; j++)//width draw
                    {
                        Console.Write(cells[i, j] ? "*" : " ");
                        if (j == Width - 1) Console.WriteLine("");//Return to the line
                    }
                 }
                Console.SetCursorPosition(0, Console.WindowTop);//does not display the previous generation by changing the position of the cursor
        }

        #endregion

        #region GenerateField
        private void GenerateField()//Initializes the field with random boolean values.
        {
                Random generator = new Random();
                int number;
                for (int i = 0; i < Heigth; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        number = generator.Next(2);
                        cells[i, j] = ((number == 0) ? false : true);
                    }
                }
        }

        #endregion
    }
}
