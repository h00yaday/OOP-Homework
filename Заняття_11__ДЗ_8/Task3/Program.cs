using System;

interface IShape
{
    int GetArea();
}

class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

class Square : IShape
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle
        {
            Width = 5,
            Height = 10
        };

        Square square = new Square
        {
            Side = 10
        };

        Console.WriteLine(rectangle.GetArea()); // 50
        Console.WriteLine(square.GetArea());    // 100

        Console.ReadKey();
    }
}