﻿namespace DiagonalMatrixNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emptyDiagonalMatrix = new DiagonalMatrix();
            var shorterDiagonalMatrix = new DiagonalMatrix(2, 3, 4);
            var shorterDiagonalMatrixCopy = new DiagonalMatrix(2, 3, 4);
            var longerDiagonalMatrix = new DiagonalMatrix(2, 3, 4, 6, 7, 8);

            // Proper size set upon object creation check
            Console.WriteLine(nameof(emptyDiagonalMatrix) + " Size = " + emptyDiagonalMatrix.Size);
            Console.WriteLine(nameof(shorterDiagonalMatrix) + " Size = " + shorterDiagonalMatrix.Size);

            // ToString override check
            Console.WriteLine("\n" + nameof(shorterDiagonalMatrix) + ":");
            Console.WriteLine(shorterDiagonalMatrix);
            Console.WriteLine("\n" + nameof(longerDiagonalMatrix) + ":");
            Console.WriteLine(longerDiagonalMatrix);

            // Addition check
            Console.WriteLine("\nMatrix after addition:");
            Console.WriteLine(shorterDiagonalMatrix.Addition(longerDiagonalMatrix));

            // Track check
            Console.WriteLine(nameof(longerDiagonalMatrix) + "element's sum: " + longerDiagonalMatrix.Track());

            // Equals check
            Console.WriteLine(nameof(shorterDiagonalMatrix) + " and " + nameof(shorterDiagonalMatrixCopy) + " are equal?: " + shorterDiagonalMatrix.Equals(shorterDiagonalMatrixCopy));
            Console.WriteLine(nameof(shorterDiagonalMatrix) + " and " + nameof(longerDiagonalMatrix) + " are equal?: " + shorterDiagonalMatrix.Equals(longerDiagonalMatrix));

            var matrix1 = new GenericDiagonalMatrix<int>(3);
            matrix1[0, 0] = 1;
            matrix1[1, 1] = 2;
            matrix1[2, 2] = 3;

            var matrix2 = new GenericDiagonalMatrix<int>(4);
            matrix2[0, 0] = 4;
            matrix2[1, 1] = 5;
            matrix2[2, 2] = 6;
            matrix2[3, 3] = 7;

            // Generic matrix Addition() check
            var resultMatrix = matrix1.Addition(matrix2, (x, y) => x + y);

            // Tracker check
            var tracker = new MatrixTracker<int>(resultMatrix);
            resultMatrix[0, 0] = 10;
            tracker.Undo();
        }
    }
}
