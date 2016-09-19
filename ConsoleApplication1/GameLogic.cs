using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class GameLogic
    {
        //Normal Move From Red
        public static bool CheckForPlusNine(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == 9)
            {
                return true;
            }
            return false;
        }

        //Normal Move From Red
        public static bool CheckForPlusSeven(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == 7)
            {
                return true;
            }
            return false;
        }

        //Normal Move From Black
        public static bool CheckForMinusNine(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == -9)
            {
                return true;
            }
            return false;
        }

        //Normal Move From Black
        public static bool CheckForMinusSeven(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == -7)
            {
                return true;
            }
            return false;
        }

        //Normal Jump From Red
        public static bool CheckForPlusEighteen(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == 18)
            {
                return true;
            }
            return false;
        }

        //Normal Jump From Red
        public static bool CheckForPlusFourteen(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == 14)
            {
                return true;
            }
            return false;
        }

        //Normal Black Jump
        public static bool CheckForMinusFourteen(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == 14)
            {
                return true;
            }
            return false;
        }

        //Normal Black Jump
        public static bool CheckForMinusEighteen(Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition - initialPosition == 18)
            {
                return true;
            }
            return false;
        }

        public static bool CheckForValidPlusFourteenJump(string[] gameBoard, Dictionary<string, int> positionDict, bool isRedTurn)
        {
            int initialPosition = positionDict["InitialPosition"];

            if (isRedTurn)
            {
                if (gameBoard[initialPosition + 7] == "B" || gameBoard[initialPosition + 7] == "1")
                {
                    return true;
                }
            }

            if (!isRedTurn)
            {
                if (gameBoard[initialPosition + 7] == "R" || gameBoard[initialPosition + 7] == "0")
                {
                    return true;
                }
            }
            Console.WriteLine("Not a valid jump");
            return false; ;
        }

        public static bool CheckForValidPlusEighteenJump(string[] gameBoard, Dictionary<string, int> positionDict, bool isRedTurn)
        {
            int initialPosition = positionDict["InitialPosition"];

            if (isRedTurn)
            {
                if (gameBoard[initialPosition + 9] == "B" || gameBoard[initialPosition + 9] == "1")
                {
                    return true;
                }
            }

            if (!isRedTurn)
            {
                if (gameBoard[initialPosition + 9] == "R" || gameBoard[initialPosition + 9] == "0")
                {
                    return true;
                }
            }
            Console.WriteLine("Not a valid jump");
            return false;
        }

        public static bool CheckForValidMinusFourteenJump(string[] gameBoard, Dictionary<string, int> positionDict, bool isRedTurn)
        {
            int initialPosition = positionDict["InitialPosition"];

            if (isRedTurn)
            {
                if (gameBoard[initialPosition - 7] == "B" || gameBoard[initialPosition - 7] == "1")
                {
                    return true;
                }
            }

            if (!isRedTurn)
            {
                if (gameBoard[initialPosition - 7] == "R" || gameBoard[initialPosition - 7] == "0")
                {
                    return true;
                }
            }
            Console.WriteLine("Not a valid jump");
            return false;
        }

        public static bool CheckForValidMinusEighteenJump(string[] gameBoard, Dictionary<string, int> positionDict, bool isRedTurn)
        {
            int initialPosition = positionDict["InitialPosition"];

            if (isRedTurn)
            {
                if (gameBoard[initialPosition - 9] == "B" || gameBoard[initialPosition - 9] == "1")
                {
                    return true;
                }
            }

            if (!isRedTurn)
            {
                if (gameBoard[initialPosition - 9] == "R" || gameBoard[initialPosition - 9] == "0")
                {
                    return true;
                }
            }
            Console.WriteLine("Not a valid jump");
            return false;
        }

        public static void CheckIfNeedsCrowningAndThenCrown(Dictionary<string, int> positionDict, string[] gameBoard)
        {
            int desiredPosition = positionDict["DesiredPosition"];

            if (desiredPosition >= 0 && desiredPosition <= 7)
            {
                gameBoard[desiredPosition] = "0";
            }
            else if (desiredPosition <= 63 && desiredPosition >= 56)
            {
                gameBoard[desiredPosition] = "1";
            }
        }
        public static Dictionary<string, int> GetInitialAndDesiredPositions(string[] gameBoard, bool isRedTurn)
        {

            //Set up position variables
            int initialPosition = 0;
            int desiredPosition = 0;

            //Set up booleans representing valid position is entered
            bool isValidInitialPosition = false;
            bool isValidDesiredPosition = false;

            while (isValidInitialPosition == false)
            {
                bool hadError = false;
                Console.Write("Move from position: ");
                initialPosition = int.Parse(Console.ReadLine());
                if (initialPosition < 0 || initialPosition > 63)
                {
                    Console.WriteLine("Position entered is outside the boundaries of the board.");
                    Console.WriteLine();
                    hadError = true;
                }
                else if (isRedTurn)
                {
                    if (gameBoard[initialPosition] != "R" && gameBoard[initialPosition] != "0")
                    {
                        Console.WriteLine("You are the red pieces, and selected a black piece or an asterisk, please reselect.");
                        Console.WriteLine();
                        hadError = true;
                    }
                }
                else if (!isRedTurn)
                {
                    if (gameBoard[initialPosition] != "B" && gameBoard[initialPosition] != "1")
                    {
                        Console.WriteLine("You are the black pieces, and selected a red piece or an asterisk, please reselect.");
                        Console.WriteLine();
                        hadError = true;
                    }
                }
                if (!hadError)
                {
                    isValidInitialPosition = true;
                }
            }

            while (isValidDesiredPosition == false)
            {
                Console.Write("Move to position: ");
                desiredPosition = int.Parse(Console.ReadLine());
                if (desiredPosition < 0 || desiredPosition > 63)
                {
                    Console.WriteLine("Position entered is outside the boundaries of the board.");
                    Console.WriteLine();
                }
                if (gameBoard[desiredPosition] != "*")
                {
                    Console.WriteLine("Your desired position is already occupied, please reselect.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    //Console.WriteLine();
                    isValidDesiredPosition = true;
                }
            }

            //Set up dictionary to hold position values
            Dictionary<string, int> positionDict = new Dictionary<string, int>();
            positionDict.Add("InitialPosition", initialPosition);
            positionDict.Add("DesiredPosition", desiredPosition);

            return positionDict;
        }
        public static bool checkIfIsKing(string[] gameBoard, Dictionary<string, int> positionDict)
        {
            int initialPosition = positionDict["InitialPosition"];
            string pieceType = gameBoard[initialPosition];
            if (pieceType == "0" || pieceType == "1")
            {
                return true;
            }
            return false;
        }
        public static void TakeRedTurn(string[] gameBoard, string playerName)
        {
            bool takingTurn = true;
            while (takingTurn)
            {
                Dictionary<string, int> positionDict = new Dictionary<string, int>();
                Console.WriteLine(playerName + "'s" + " " + "Turn!");
                positionDict = GetInitialAndDesiredPositions(gameBoard, true);
                //Check if the piece is a king
                bool isPieceKing = checkIfIsKing(gameBoard, positionDict);
                if (CheckForPlusSeven(positionDict))
                {
                    gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                    gameBoard[positionDict["InitialPosition"]] = "*";
                    CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                    takingTurn = false;
                }
                else if (CheckForPlusNine(positionDict))
                {
                    gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                    gameBoard[positionDict["InitialPosition"]] = "*";
                    CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                    takingTurn = false;
                }
                else if (CheckForPlusFourteen(positionDict))
                {
                    if (CheckForValidPlusFourteenJump(gameBoard, positionDict, true))
                    {
                        Console.WriteLine("Black Piece Jumped!");
                        Console.WriteLine();
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"] + 7] = "*";
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForPlusEighteen(positionDict))
                {
                    if (CheckForValidPlusEighteenJump(gameBoard, positionDict, true))
                    {
                        Console.WriteLine("Black Piece Jumped!");
                        Console.WriteLine();
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"] + 9] = "*";
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForMinusSeven(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can move backwards");
                    }
                    else
                    {
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForMinusNine(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can move backwards");
                    }
                    else
                    {
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForMinusFourteen(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can jump backwards");
                    }
                    else
                    {
                        if (CheckForValidMinusFourteenJump(gameBoard, positionDict, true))
                        {
                            Console.WriteLine("Black Piece Jumped!");
                            gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                            gameBoard[positionDict["InitialPosition"] - 7] = "*";
                            gameBoard[positionDict["initialPosition"]] = "*";
                            CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                            takingTurn = false;
                        }
                    }
                }
                else if (CheckForMinusEighteen(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can jump backwards");
                    }
                    else
                    {
                        if (CheckForValidMinusEighteenJump(gameBoard, positionDict, true))
                        {
                            Console.WriteLine("Black Piece Jumped!");
                            gameBoard[positionDict["InitialPosition"] - 9] = "*";
                            gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                            gameBoard[positionDict["InitialPosition"]] = "*";
                            CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                            takingTurn = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Was not valid move, please reselect.");
                    Console.WriteLine();
                }
            }
        }
        public static void TakeBlackTurn(string[] gameBoard, string playerName)
        {
            bool takingTurn = true;
            while (takingTurn)
            {
                Dictionary<string, int> positionDict = new Dictionary<string, int>();
                Console.WriteLine(playerName + "'s" + " " + "Turn!");
                positionDict = GetInitialAndDesiredPositions(gameBoard, false);
                //Check if the piece is a king
                bool isPieceKing = checkIfIsKing(gameBoard, positionDict);
                if (CheckForPlusSeven(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can move backwards");
                    }
                    else
                    {
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForPlusNine(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can move backwards");
                    }
                    else
                    {
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForPlusFourteen(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can move backwards");
                    }
                    else if (CheckForValidPlusFourteenJump(gameBoard, positionDict, false))
                    {
                        Console.WriteLine("Black Piece Jumped!");
                        Console.WriteLine();
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"] + 7] = "*";
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForPlusEighteen(positionDict))
                {
                    if (!isPieceKing)
                    {
                        Console.WriteLine("Only kings can move backwards");
                    }

                    else if (CheckForValidPlusEighteenJump(gameBoard, positionDict, false))
                    {
                        Console.WriteLine("Black Piece Jumped!");
                        Console.WriteLine();
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"] + 9] = "*";
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForMinusSeven(positionDict))
                {
                    gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                    gameBoard[positionDict["InitialPosition"]] = "*";
                    CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                    takingTurn = false;
                }
                else if (CheckForMinusNine(positionDict))
                {
                    gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                    gameBoard[positionDict["InitialPosition"]] = "*";
                    takingTurn = false;
                }
                else if (CheckForMinusFourteen(positionDict))
                {
                    if (CheckForValidMinusFourteenJump(gameBoard, positionDict, false))
                    {
                        Console.WriteLine("Black Piece Jumped!");
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"] - 7] = "*";
                        gameBoard[positionDict["initialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else if (CheckForMinusEighteen(positionDict))
                {
                    if (CheckForValidMinusEighteenJump(gameBoard, positionDict, false))
                    {
                        Console.WriteLine("Black Piece Jumped!");
                        gameBoard[positionDict["InitialPosition"] - 9] = "*";
                        gameBoard[positionDict["DesiredPosition"]] = gameBoard[positionDict["InitialPosition"]];
                        gameBoard[positionDict["InitialPosition"]] = "*";
                        CheckIfNeedsCrowningAndThenCrown(positionDict, gameBoard);
                        takingTurn = false;
                    }
                }
                else
                {
                    Console.WriteLine("Was not valid move, please reselect.");
                    Console.WriteLine();
                }
            }
        }
    }
}
