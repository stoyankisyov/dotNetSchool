namespace SparseMatrixApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sparseMatrix = new SparseMatrix(5, 5);

            // Empty matrix ToString()
            Console.WriteLine(sparseMatrix);

            // Setting values
            sparseMatrix[0, 0] = 1L;
            sparseMatrix[2, 2] = 1L;
            sparseMatrix[1, 2] = 1L;
            sparseMatrix[4, 4] = 1L;

            // Set operations success check
            Console.WriteLine(sparseMatrix);

            // Get operation
            Console.WriteLine($"Element[0, 0]: {sparseMatrix[0, 0]}");

            // IEnumerable 
            Console.WriteLine("\nIEnumerable test: ");
            foreach(var element in sparseMatrix)
            {
                Console.Write(element + " ");
            }

            // Following tests are done using debug
            // GetNonzeroElements()
            var nonZeroElements = sparseMatrix.GetNonzeroElements();

            // GetCount(1)
            var oneCount = sparseMatrix.GetCount(1L);

            // GetCount(0)
            var zeroCount = sparseMatrix.GetCount(0);
        }
    }
}
