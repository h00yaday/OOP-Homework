namespace Task_4._1
{
    public class Mountain : IGeographicObject
    {
        public double CoordinateX { get; private set; }
        public double CoordinateY { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double HighestPoint { get; private set; } // м

        public Mountain(double coordinateX, double coordinateY, string name, string description, double highestPoint)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Name = name;
            Description = description;
            HighestPoint = highestPoint;
        }

        public string GetInfo()
        {
            return $"Назва: {Name}, Опис: {Description}, Координати: ({CoordinateX}; {CoordinateY}), " +
                   $"Найвища точка: {HighestPoint} м";
        }
    }
}
