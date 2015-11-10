namespace PassableMatrixPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// We are given a matrix of passable and non-passable cells.
    /// Write a recursive program for finding all paths between two cells in the matrix.
    /// </summary>
    public class Startup
    {
        private static readonly char[,] labyrinth =
        {
            { 's', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', ' ', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', '*', ' ', ' ', '*', ' ' },
            { ' ', '*', '*', '*', '*', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        private static char[] path = new char[labyrinth.GetLongLength(0) * labyrinth.GetLongLength(1)];
        private const char PASS = ' ';
        private const char NONPASS = '*';
        private const char START = 's';
        private const char END = 'e';

        public static void Main(string[] args)
        {
            bool existsPath = false;

            FindAllPaths(labyrinth, 0, 0, ref existsPath);

            // TestWithEmptyMatrix100x100();
        }

        private static void FindAllPaths(char[,] labyrinth, int row, int col, ref bool existsPath, int index = 1, char dir = ' ')
        {
            if (existsPath || !IsCellPassable(labyrinth, row, col))
            {
                return;
            }

            if (labyrinth[row, col] == END)
            {
                existsPath = true;

                Console.WriteLine(PrintResult(existsPath));

                existsPath = false;
                return;
            }

            path[index - 1] = dir;
            labyrinth[row, col] = NONPASS;

            FindAllPaths(labyrinth, row - 1, col, ref existsPath, index + 1, 'U');  // Up
            FindAllPaths(labyrinth, row + 1, col, ref existsPath, index + 1, 'D');  // Down
            FindAllPaths(labyrinth, row, col - 1, ref existsPath, index + 1, 'L');  // Left
            FindAllPaths(labyrinth, row, col + 1, ref existsPath, index + 1, 'R');  // Right

            path[index - 1] = existsPath ? path[index - 1] : ' ';
            labyrinth[row, col] = PASS;
        }

        private static bool IsCellPassable(char[,] labyrinth, int row, int col)
        {
            return row >= 0 && row < labyrinth.GetLongLength(0) &&
                   col >= 0 && col < labyrinth.GetLongLength(1) &&
                   labyrinth[row, col] != NONPASS;
        }

        private static string PrintResult(bool existsPath)
        {
            if (!existsPath)
            {
                return "Path does not exists!";
            }

            var result = new StringBuilder();
            int pathLength = 1;

            for (int i = 1; i < path.Length && path[i] != '\0'; i++, pathLength++)
            {
                result.Append(path[i] + " ");
            }

            return string.Format("Path exists -> cells length: {0} -> Direction: {1}{2}\n",
                pathLength + 1, result.ToString().Substring(0, pathLength >= 250 ? 250 : pathLength),
                pathLength >= 250 ? "..." : "");
        }

        private static void TestWithEmptyMatrix100x100()
        {
            const int N = 100;
            bool existsPath = false;

            char[,] matrix = new char[N, N];
            path = new char[N * N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = PASS;
                }
            }

            matrix[N - 1, N - 1] = END;

            FindAllPaths(matrix, 0, 0, ref existsPath);
            Console.WriteLine(PrintResult(existsPath));
        }
    }
}
