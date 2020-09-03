using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    public class Game
    {
        public int Counter { get; set; }
        public string[,] Board { get; set; }
        public bool isComputerTurn { get; set; }
        private enum RowNumber
        {
            FirstRow = 1,
            SecondRow = 3,
            ThirdRow = 5
        }
        private enum ColumnNumber
        {
            FirstColumn = 1,
            SecondColumn = 3,
            ThirdColumn = 5
        }


        /// <summary>
        /// Initialize variables and print the board
        /// </summary>
        public Game()
        {
            Board = new string[7, 7];
            SetBoard();
            PrintBoard();
            isComputerTurn = false;
            Counter = 0;
            logToFile("Data rozpoczecia gry: ");
        }

        /// <summary>
        /// Print the board to the console
        /// </summary>
        private void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine();
            for(int i = 0; i < Board.GetLength(0); i++)
            {
                Console.Write("\t\t\t\t\t\t");
                for(int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write($"{Board[i, j]}");
                }
                Console.WriteLine();
            }
            logBoardToFile();
        }

        /// <summary>
        /// Set the characters of the board
        /// </summary>
        private void SetBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (i % 2 == 0)
                    {
                        Board[i, j] = "--";
                    }
                    else if (j % 2 == 0)
                    {
                        Board[i, j] = "|";
                    }
                    else
                    {
                        Board[i, j] = "  ";
                    }
                }
            }
            Board[(int)RowNumber.FirstRow, (int)ColumnNumber.FirstColumn] = " 1 ";
            Board[(int)RowNumber.FirstRow, (int)ColumnNumber.SecondColumn] = " 2 ";
            Board[(int)RowNumber.FirstRow, (int)ColumnNumber.ThirdColumn] = " 3 ";

            Board[(int)RowNumber.SecondRow, (int)ColumnNumber.FirstColumn] = " 4 ";
            Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn] = " 5 ";
            Board[(int)RowNumber.SecondRow, (int)ColumnNumber.ThirdColumn] = " 6 ";

            Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.FirstColumn] = " 7 ";
            Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.SecondColumn] = " 8 ";
            Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.ThirdColumn] = " 9 ";

            Console.WriteLine("\n\n\t\t\t\tPress number (1-9) to do a move! Enjoy! :) :) :)\n\n");

        }

        /// <summary>
        /// Generate position of the computer move
        /// </summary>
        /// <returns></returns>
        private int generateRandomPosition()
        {
            int position = 0;
            var random = new Random();

            do
            {
                position = random.Next(9) + 1;

            } while (!isPositionCorrect(position));

            return position;
        }

        /// <summary>
        /// Check if the position is correct
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool isPositionCorrect(int position)
        {

            int i = 0, j = 0;
            if(position == 1)
            {
                i = (int)RowNumber.FirstRow; j = (int)ColumnNumber.FirstColumn;
            }
            else if(position == 2)
            {
                i = (int)RowNumber.FirstRow; j = (int)ColumnNumber.SecondColumn;
            }
            else if (position == 3)
            {
                i = (int)RowNumber.FirstRow; j = (int)ColumnNumber.ThirdColumn;
            }
            else if (position == 4)
            {
                i = (int)RowNumber.SecondRow; j = (int)ColumnNumber.FirstColumn;
            }
            else if (position == 5)
            {
                i = (int)RowNumber.SecondRow; j = (int)ColumnNumber.SecondColumn;
            }
            else if (position == 6)
            {
                i = (int)RowNumber.SecondRow; j = (int)ColumnNumber.ThirdColumn;
            }
            else if (position == 7)
            {
                i = (int)RowNumber.ThirdRow; j = (int)ColumnNumber.FirstColumn;
            }
            else if (position == 8)
            {
                i = (int)RowNumber.ThirdRow; j = (int)ColumnNumber.SecondColumn;
            }
            else if (position == 9)
            {
                i = (int)RowNumber.ThirdRow; j = (int)ColumnNumber.ThirdColumn;
            }
            else
            {
                return false;
            }

            if(Board[i,j].Trim().Equals("X") || Board[i, j].Trim().Equals("O"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Do one move 
        /// </summary>
        private void DoMove()
        {
            Counter++;
            string sign;
            int position;

            if (isComputerTurn)
            {
                sign = " O ";
                position = generateRandomPosition();
            }
            else
            {
                sign = " X ";
                bool isCorrect = false;
                do
                {
                    Console.Write($"\n\t\t\t\t\tType position: ");
                    isCorrect = int.TryParse(Console.ReadLine(), out position);
                } while (!isPositionCorrect(position) || isCorrect == false);
            }

            switch (position)
            {
                case 1:
                    Board[(int)RowNumber.FirstRow, (int)ColumnNumber.FirstColumn] = sign;
                    break;
                case 2:
                    Board[(int)RowNumber.FirstRow, (int)ColumnNumber.SecondColumn] = sign;
                    break;
                case 3:
                    Board[(int)RowNumber.FirstRow, (int)ColumnNumber.ThirdColumn] = sign;
                    break;
                case 4:
                    Board[(int)RowNumber.SecondRow, (int)ColumnNumber.FirstColumn] = sign;
                    break;
                case 5:
                    Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn] = sign;
                    break;
                case 6:
                    Board[(int)RowNumber.SecondRow, (int)ColumnNumber.ThirdColumn] = sign;
                    break;
                case 7:
                    Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.FirstColumn] = sign;
                    break;
                case 8:
                    Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.SecondColumn] = sign;
                    break;
                case 9:
                    Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.ThirdColumn] = sign;
                    break;
            }

            isComputerTurn = !isComputerTurn;
        }

        /// <summary>
        /// Start the game
        /// </summary>
        public void Start()
        {
            while (!isWinner())
            {
                DoMove();
                PrintBoard();
            }

            Console.WriteLine("\n\t\t\t\t\t  Thanks for playing :)\n");
            Console.ResetColor();
            logToFile("Data zakonczenia gry: ");
        }

        /// <summary>
        /// Check if the game ends
        /// </summary>
        /// <returns></returns>
        private bool isWinner()
        {
            bool isWin = false;

            if (Counter >= 9)
            {
                return true;
            }
            else if (Board[(int)RowNumber.FirstRow, (int)ColumnNumber.FirstColumn]
                .Equals(Board[(int)RowNumber.FirstRow, (int)ColumnNumber.SecondColumn]) &&
                Board[(int)RowNumber.FirstRow, (int)ColumnNumber.SecondColumn].Equals(Board[(int)RowNumber.FirstRow, (int)ColumnNumber.ThirdColumn]))
            {
                isWin = true;
            }
            else if (Board[(int)RowNumber.SecondRow, (int)ColumnNumber.FirstColumn]
                .Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn]) &&
                Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn].Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.ThirdColumn]))
            {
                isWin = true;
            }
            else if (Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.FirstColumn]
                .Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.SecondColumn]) &&
                Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.SecondColumn].Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.ThirdColumn]))
            {
                isWin = true;
            }
            else if (Board[(int)RowNumber.FirstRow, (int)ColumnNumber.FirstColumn]
                .Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.FirstColumn]) &&
                Board[(int)RowNumber.SecondRow, (int)ColumnNumber.FirstColumn].Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.FirstColumn]))
            {
                isWin = true;
            }
            else if (Board[(int)RowNumber.FirstRow, (int)ColumnNumber.SecondColumn]
                .Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn]) &&
                Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn].Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.SecondColumn]))
            {
                isWin = true;
            }
            else if (Board[(int)RowNumber.FirstRow, (int)ColumnNumber.ThirdColumn]
                .Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.ThirdColumn]) &&
                Board[(int)RowNumber.SecondRow, (int)ColumnNumber.ThirdColumn].Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.ThirdColumn]))
            {
                isWin = true;
            }
            else if (Board[(int)RowNumber.FirstRow, (int)ColumnNumber.FirstColumn].Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn]) && Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn].Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.ThirdColumn]))
            {
                isWin = true;
            }
            else if(Board[(int)RowNumber.FirstRow, (int)ColumnNumber.ThirdColumn].Equals(Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn]) && Board[(int)RowNumber.SecondRow, (int)ColumnNumber.SecondColumn].Equals(Board[(int)RowNumber.ThirdRow, (int)ColumnNumber.FirstColumn]))
            {
                isWin = true;
            }

            if(isWin && !isComputerTurn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\t\t\t\t\t  Computer has won!");
            }
            else if(isWin && isComputerTurn)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\t\t\t\t\t  You have won!");
            }
            return isWin;
        }

        /// <summary>
        /// Write text and date to the file
        /// </summary>
        /// <param name="s"></param>
        private void logToFile(string s)
        {
            File.AppendAllText("log.txt", s);
            File.AppendAllText("log.txt", DateTime.Now.ToString() + "\n");
        }

        /// <summary>
        /// Write boards to the file
        /// </summary>
        private void logBoardToFile()
        {
            if (Counter == 0) return;

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    File.AppendAllText("log.txt", Board[i,j]);
                }
                File.AppendAllText("log.txt", "\n");
            }
        }
        

    }
}
