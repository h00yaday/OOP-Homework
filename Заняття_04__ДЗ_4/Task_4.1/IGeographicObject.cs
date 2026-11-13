namespace Task_4._1
{
    // Інтерфейс "Географічний об'єкт"
    public interface IGeographicObject
    {
        double CoordinateX { get; }
        double CoordinateY { get; }
        string Name { get; }
        string Description { get; }

        string GetInfo();
    }
}
