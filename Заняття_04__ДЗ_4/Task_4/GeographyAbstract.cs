namespace Task_4
{
    // Абстрактний клас "Географічний об'єкт"
    public abstract class GeographicObject
    {
        public double CoordinateX { get; private set; }
        public double CoordinateY { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected GeographicObject(double coordinateX, double coordinateY, string name, string description)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Name = name;
            Description = description;
        }

        // Віртуальний метод отримання інформації
        public virtual string GetInfo()
        {
            return $"Назва: {Name}, Опис: {Description}, Координати: ({CoordinateX}; {CoordinateY})";
        }
    }
}
