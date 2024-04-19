namespace UniqueArrayElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of array element: ");
            var arrayLenght = int.Parse(Console.ReadLine());
            var originalArray = ReadArrayFromConsole(arrayLenght);
            var filteredArray = FilterUniqueElements(originalArray);
            Console.Write("Original array : ");
            PrintArray(originalArray);
            Console.Write("Filtered array : ");
            PrintArray(filteredArray);
        }

        private static int[] ReadArrayFromConsole (int arrayLenght)
        {
            var array = new int[arrayLenght];
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write($"Enter [{i}] element: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            return array;
        }
        private static int[] FilterUniqueElements(int[] array)
        {
            var tempArray = new int[array.Length];
            var lastElementIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                var existing = false;
                for (int j = 0; j < tempArray.Length; j++)
                {
                    if (array[i] == tempArray[j])
                    {
                        existing = true;
                        break;
                    }
                }

                if (!existing)
                {
                    tempArray[lastElementIndex] = array[i];
                    lastElementIndex++;
                }
            }

            var finalArray = new int[lastElementIndex];
            Array.Copy(tempArray, finalArray, lastElementIndex);

            return finalArray;
        }

        private static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
