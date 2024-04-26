namespace PlanetariumOnTheComputer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pointAtZero = new Point(0, 0, 0, 5);
            Console.WriteLine(nameof(pointAtZero) + " - " + pointAtZero);
            Console.WriteLine(nameof(pointAtZero) + " is zero? - " + pointAtZero.IsZero());
            Console.WriteLine();

            var pointWithNegativeMass = new Point(1, -2, 3, -5);
            Console.WriteLine(nameof(pointWithNegativeMass) + " - " + pointWithNegativeMass);
            Console.WriteLine(nameof(pointWithNegativeMass) + " is zero? - " + pointWithNegativeMass.IsZero());
            Console.WriteLine();

            Console.WriteLine("The distance between [" + nameof(pointAtZero) + "] and [" 
                + nameof(pointWithNegativeMass) + "] is " + pointAtZero.CalculateDistanceTo(pointWithNegativeMass));
        }
    }
}
