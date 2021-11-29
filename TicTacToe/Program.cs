using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string playerSymbol = "X";
            string computerSymbol = "O";
            string[,] board = new string[3, 3];

            PrintBoard();
            GetUserInput();

            void GetUserInput()
            {
                //get player input
                Console.Write("Enter index: ");
                string input = Console.ReadLine();

                //convert char from input into int
                int index1 = input[0] - '0' - 1;
                int index2 = input[1] - '0' - 1;

                //check if space already taken
                if (index1 > 2 || index1 < 0 || index2 > 2 || index2 < 0 || board[index1, index2] != null)
                {
                    PrintBoard();
                    Console.WriteLine("Invalid position");
                    GetUserInput();
                }

                //add to board and print
                board[index1, index2] = playerSymbol;
                PrintBoard();

                //check if player win
                //if horizontal or vertical
                if ((board[index1, 0] == playerSymbol && board[index1, 1] == playerSymbol && board[index1, 2] == playerSymbol) || (board[0, index2] == playerSymbol && board[1, index2] == playerSymbol && board[2, index2] == playerSymbol))
                {
                    Console.WriteLine("You Win");
                    if (Convert.ToChar(Console.Read()) == 'e')
                    {
                        return;
                    } else
                    {
                        Reset();
                        return;
                    }
                } else 
                {
                    int singleIndex = index1 + index2;
                    if (singleIndex % 2 == 0) //check if even for diagonal check
                    {
                        if (board[1, 1] == playerSymbol && ((board[0, 0] == playerSymbol && board[2, 2] == playerSymbol) || (board[0, 2] == playerSymbol && board[2, 0] == playerSymbol)))
                        {
                            Console.WriteLine("You Win");
                            if (Convert.ToChar(Console.Read()) == 'e')
                            {
                                return;
                            } else
                            {
                                Reset();
                                return;
                            }
                        }
                    }
                }

                //check if draw
                if (!board.Cast<string>().Contains(null))
                {
                    Console.WriteLine("Draw");
                    if (Convert.ToChar(Console.Read()) == 'e')
                    {
                        return;
                    } else
                    {
                        Reset();
                        return;
                    }
                }

                //make computer move
                var nullIndices = board.Cast<string>().Select((value, index) => new { value, index })
                    .Where(a => a.value == null)
                    .Select(a => a.index);

                int[] indexArray = nullIndices.ToArray<int>();
                int index = indexArray[rnd.Next(indexArray.Length - 1)];
                int computerIndexX = index / 3;
                int computerIndexY = index % 3;

                board[computerIndexX, computerIndexY] = computerSymbol;
                PrintBoard();

                //check if computer win
                if ((board[computerIndexX, 0] == computerSymbol && board[computerIndexX, 1] == computerSymbol && board[computerIndexX, 2] == computerSymbol) || (board[0, computerIndexY] == computerSymbol && board[1, computerIndexY] == computerSymbol && board[2, computerIndexY] == computerSymbol))
                {
                    Console.WriteLine("You Lose");
                    if (Convert.ToChar(Console.Read()) == 'e')
                    {
                        return;
                    } else
                    {
                        Reset();
                        return;
                    }
                }
                else
                {
                    int singleIndex = computerIndexX + computerIndexY;
                    //check if even for diagonal check
                    if (singleIndex % 2 == 0)
                    {
                        if (board[1, 1] == computerSymbol && ((board[0, 0] == computerSymbol && board[2, 2] == computerSymbol) || (board[0, 2] == computerSymbol && board[2, 0] == computerSymbol)))
                        {
                            Console.WriteLine("You Lose");
                            if (Convert.ToChar(Console.Read()) == 'e')
                            {
                                return;
                            } else
                            {
                                Reset();
                                return;
                            }
                        }
                    }
                }

                //check if draw
                if (!board.Cast<string>().Contains(null))
                {
                    Console.WriteLine("Draw");
                    if (Convert.ToChar(Console.Read()) == 'e')
                    {
                        return;
                    } else
                    {
                        Reset();
                        return;
                    }
                }

                GetUserInput();
            }
            

            void PrintBoard()
            {
                Console.Clear();
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($" {board[i, 0] ?? " "}  |  {board[i, 1] ?? " "}  |  {board[i, 2] ?? " "} ");
                    if (i < 2) Console.WriteLine("---------------");
                }
            }

            void Reset()
            {
                ///Start process, friendly name is something like MyApp.exe (from current bin directory)
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.FriendlyName);

                //Close the current process
                Environment.Exit(0);
            }
        }
    }
}
