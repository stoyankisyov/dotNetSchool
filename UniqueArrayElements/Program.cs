namespace UniqueArrayElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array lenght: ");
            var arrayLenght = int.Parse(Console.ReadLine());

            var originalArray = ReadIntArrayFromConsole(arrayLenght);
            var filteredArray = FilterUniqueElements(originalArray);
            var hashSetFilteredArray = FilterUniqueElementsWithHashSet(originalArray);

            Console.Write("Original array : ");
            PrintArray(originalArray);
            Console.Write("Filtered array : ");
            PrintArray(filteredArray);
            Console.Write("HashSet Filtered array: ");
            PrintArray(hashSetFilteredArray);
        }

        private static int[] ReadIntArrayFromConsole (int arrayLenght)
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

                for (int j = 0; j < lastElementIndex; j++)
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

        private static int[] FilterUniqueElementsWithHashSet(int[] array)
        {
            var uniqueElements = new HashSet<int>();

            foreach (var element in array)
            {
                uniqueElements.Add(element);
            }

            return uniqueElements.ToArray();
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
