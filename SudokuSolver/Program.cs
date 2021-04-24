using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new char[,]
           {
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' },
        { '0', '0', '0', '0', '0', '0', '0', '0', '0' }
           };
            userInput(sudoku); // Receive values from the user
            checkSudoku(sudoku); // Check if the matrix is not null or empty
            Console.WriteLine(" \n After Solving : \n");
            print(sudoku); // Print the solution
        }
        public static void userInput(char[,] matrix)
        {
            while (true)
            {
                Console.Write("Enter row number : (from 1 to 9) ");
                int row = (Convert.ToInt32(Console.ReadLine()) - 1);
                Console.Write("Enter column number : (from 1 to 9) ");
                int col = (Convert.ToInt32(Console.ReadLine()) - 1);
                Console.Write("Enter the value: (from 1 to 9) ");
                char value = Convert.ToChar(Console.ReadLine());
                matrix[row, col] = value;
                Console.WriteLine("Do you want to add another number? (y/n) ");
                char newInput = Convert.ToChar(Console.ReadLine());
                if (char.ToLower(newInput) == 'n')
                {
                    Console.WriteLine(" \n Before Solving : \n");
                    print(matrix);
                    Console.WriteLine("are you sure?  (y/n) "); // Do you want the sudoku to be solved now?
                    char check = Convert.ToChar(Console.ReadLine());
                    if (check == 'y') break;
                }
            }
        }
        public static void print(char[,] matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("----------|---------|----------");
                }
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(" " + matrix[i, j]
                            + " ");
                }
                Console.WriteLine();
            }
        }
        public static void checkSudoku(char[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return;
            solve(matrix);
        }

        private static bool solve(char[,] matrix) // This is a method to solve the sudoku 

        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '0')
                    {
                        for (char num = '1'; num <= '9'; num++)
                        {
                            if (isPossible(matrix, row, col, num))
                            {
                                matrix[row, col] = num;
                                if (solve(matrix))
                                    return true;
                                else
                                    matrix[row, col] = '0';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool isPossible(char[,] matrix, int row, int col, char num) // Check if the value is possible to insert
        {
            for (int i = 0; i < 9; i++)
            {
                // Check the column
                if (matrix[i, col] != '0' && matrix[i, col] == num)
                    return false;
                // Check the row
                if (matrix[row, i] != '0' && matrix[row, i] == num)
                    return false;
               
                //check the 3*3 block  
                if (matrix[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '0' && matrix[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == num)
                    return false;
            }
            return true;
        }
    
    }
}
