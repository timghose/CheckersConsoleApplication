using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Board
    {
        public string[] gameBoard { get; set; }

        public void SetUpBoard()
        {
            for (int i = 0; i < 64; i++)
            {
                if (i < 8)
                {
                    if (i % 2 != 0)
                    {
                        gameBoard[i] = "R";
                    }
                    else
                    {
                        gameBoard[i] = "*";
                    }
                }
                else if (i < 16)
                {
                    if (i % 2 == 0)
                    {
                        gameBoard[i] = "R";
                    }
                    else
                    {
                        gameBoard[i] = "*";
                    }
                }
                else if (i < 24)
                {
                    if (i % 2 != 0)
                    {
                        gameBoard[i] = "R";
                    }
                    else
                    {
                        gameBoard[i] = "*";
                    }
                }
                else if (i > 39 && i < 48)
                {
                    if (i % 2 == 0)
                    {
                        gameBoard[i] = "B";
                    }
                    else
                    {
                        gameBoard[i] = "*";
                    }
                }

                else if (i > 47 && i < 56)
                {
                    if (i % 2 != 0)
                    {
                        gameBoard[i] = "B";
                    }
                    else
                    {
                        gameBoard[i] = "*";
                    }
                }
                else if (i > 55)
                {
                    if (i % 2 == 0)
                    {
                        gameBoard[i] = "B";
                    }
                    else
                    {
                        gameBoard[i] = "*";
                    }
                }
                else
                {
                    gameBoard[i] = "*";
                }
            }
        }

        public void PrintBoard()
        {
            //List of numbers to represent columns
            List<int> TopRow = new List<int>();

            //Populating the list "TopRow"
            for (int i = 0; i < 8; i++)
            {
                TopRow.Add(i);
            }

            for (int i = 0; i < TopRow.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("    " + TopRow[i]);
                }
                else
                {
                    Console.Write(" " + TopRow[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("00  ");
                }
                if (i != 0 && i % 8 == 0)
                {
                    Console.WriteLine();
                    if (i == 8)
                    {
                        Console.Write("08  ");
                    }
                    if (i == 16)
                    {
                        Console.Write("16  ");
                    }
                    if (i == 24)
                    {
                        Console.Write("24  ");
                    }
                    if (i == 32)
                    {
                        Console.Write("32  ");
                    }
                    if (i == 40)
                    {
                        Console.Write("40  ");
                    }
                    if (i == 48)
                    {
                        Console.Write("48  ");
                    }
                    if (i == 56)
                    {
                        Console.Write("56  ");
                    }
                }
                Console.Write(gameBoard[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ChangeBoardForRedTurn(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            gameBoard[initialPosition] = "*";
            gameBoard[desiredPosition] = "R";
        }

        public void ChangeBoardForBlackTurn(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            gameBoard[initialPosition] = "*";
            gameBoard[desiredPosition] = "B";
        }

        public void ChangeBoardForRedJump(Dictionary<string, int> positionDict)
        {
            //int initialPosition
        }
    }
}
