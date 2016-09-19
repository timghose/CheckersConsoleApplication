using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greeting Message
            Console.WriteLine("Welcome to Tim Ghose's Console Application Checkers!");
            Console.WriteLine();
            Console.WriteLine("Required Information: 0 = Red Kings, 1 = Black Kings.");
            Console.WriteLine("                      Add the columns together to get the position!");
            Console.WriteLine();

            //Create and set up board
            Board theBoard = new Board();
            theBoard.gameBoard = new string[64];
            theBoard.SetUpBoard();         

            //Formatting
            Console.WriteLine();

            //Set up boolean representing if game is running
            bool gameRunning = true;
            while(gameRunning)
            {
                theBoard.PrintBoard();
                GameLogic.TakeRedTurn(theBoard.gameBoard, "Red Player");
                theBoard.PrintBoard();
                GameLogic.TakeBlackTurn(theBoard.gameBoard, "Black Player");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
