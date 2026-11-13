namespace Task_4
{
    public class River : GeographicObject
    {
        public double FlowSpeed { get; private set; }   // см/с
        public double Length { get; private set; }      // км

        public River(double coordinateX, double coordinateY, string name, string description, double flowSpeed, double length)
            : base(coordinateX, coordinateY, name, description)
        {
            FlowSpeed = flowSpeed;
            Length = length;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Швидкість течії: {FlowSpeed} см/с, Загальна довжина: {Length} км";
        }
    }
}
