namespace Task_4
{
    public class Mountain : GeographicObject
    {
        public double HighestPoint { get; private set; } // м

        public Mountain(double coordinateX, double coordinateY, string name, string description, double highestPoint)
            : base(coordinateX, coordinateY, name, description)
        {
            HighestPoint = highestPoint;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Найвища точка: {HighestPoint} м";
        }
    }
}
