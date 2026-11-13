namespace Task_4._1
{
    public class River : IGeographicObject
    {
        public double CoordinateX { get; private set; }
        public double CoordinateY { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double FlowSpeed { get; private set; }   // см/с
        public double Length { get; private set; }      // км

        public River(double coordinateX, double coordinateY, string name, string description, double flowSpeed, double length)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Name = name;
            Description = description;
            FlowSpeed = flowSpeed;
            Length = length;
        }

        public string GetInfo()
        {
            return $"Назва: {Name}, Опис: {Description}, Координати: ({CoordinateX}; {CoordinateY}), " +
                   $"Швидкість течії: {FlowSpeed} см/с, Загальна довжина: {Length} км";
        }
    }
}
