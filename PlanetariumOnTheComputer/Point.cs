namespace PlanetariumOnTheComputer
{
    public class Point
    {
        private int[] _coordinates = new int[3];
        private double _mass;

        public int CoordinateX
        {
            get => _coordinates[0];
            set => _coordinates[0] = value;
        }
        public int CoordinateY
        {
            get => _coordinates[1];
            set => _coordinates[1] = value;
        }
        public int CoordinateZ
        {
            get => _coordinates[2];
            set => _coordinates[2] = value;
        }
        public double Mass
        {
            get => _mass;
            set => _mass = value > 0 ? value : 0;
        }

        public Point(int coordinateX, int coordinateY, int coordinateZ, double mass)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
            Mass = mass;
        }

        public bool IsZero()
        {
            return CoordinateX == 0 && CoordinateY == 0 && CoordinateZ == 0;
        }

        public double CalculateDistanceTo (Point secondPoint)
        {
            var distanceX = CoordinateX - secondPoint.CoordinateX;
            var distanceY = CoordinateY - secondPoint.CoordinateY;
            var distanceZ = CoordinateZ - secondPoint.CoordinateZ;

            return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2) + Math.Pow(distanceZ, 2));
        }

        public override string ToString()
        {
            return $"CoordinateX: {CoordinateX}, CoordinateY: {CoordinateY}, CoordinateZ: {CoordinateZ}, Mass: {Mass}";
        }
    }
}
