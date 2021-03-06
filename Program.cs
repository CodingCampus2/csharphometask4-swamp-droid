using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {

        static int GetAliveCellsCount(int x, int y, char[,] board)
        {
            int counter = 0;
            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    if (board[x + i, y + j] == '1')
                    {
                        ++counter;
                    }
                }
            }

            return counter;
        }

        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                char[,] board = task.Board;

                int x = board.GetLength(0);
                int y = board.GetLength(1);
                char[,] virtualBoard = new char[x + 2, y + 2];

                for(int i = 1; i <= y; i++)
                {
                    for(int j = 1; j <= x; j++)
                    {
                        virtualBoard[j, i] = board[j - 1, i - 1];
                    }
                }

                char[,] answerBoard = new char[x, y];

                for(int i = 1; i <= y; i++)
                {
                    for(int j = 1; j <= x; j++)
                    {
                        int aliveCells = GetAliveCellsCount(j, i, virtualBoard);
                        
                        if(virtualBoard[j,i] == '1'
                           && (aliveCells == 2 || aliveCells == 3))
                        {
                            answerBoard[j - 1, i - 1] = '1';
                        }
                        else if (virtualBoard[j, i] == '0'
                                && aliveCells == 3)
                        {
                            answerBoard[j - 1, i - 1] = '1';
                        }
                        else
                        {
                            answerBoard[j - 1, i - 1] = '0';
                        }
                    }
                }

                return answerBoard;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
