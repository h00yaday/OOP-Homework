using System.Text;

namespace PrototypeFigure;

interface IFigure
{
    IFigure Clone();
    void GetInfo();
}

class Rectangle : IFigure
{
    private readonly int width;
    private readonly int height;

    public Rectangle(int w, int h)
    {
        width = w;
        height = h;
    }

    public IFigure Clone() => new Rectangle(width, height);

    public void GetInfo() =>
        Console.WriteLine("Прямокутник довжиною {0} і шириною {1}", height, width);
}

class Circle : IFigure
{
    private readonly int radius;

    public Circle(int r)
    {
        radius = r;
    }

    public IFigure Clone() => new Circle(radius);

    public void GetInfo() => Console.WriteLine("Круг радіусом {0}", radius);
}

// Додано
class Triangle : IFigure
{
    private readonly int a;
    private readonly int b;
    private readonly int c;

    public Triangle(int a, int b, int c)
    {
        if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Трикутник з такими сторонами не існує");
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public IFigure Clone() => new Triangle(a, b, c);

    public void GetInfo() =>
        Console.WriteLine("Трикутник зі сторонами {0}, {1}, {2}", a, b, c);
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        IFigure[] figures = { new Rectangle(10, 20), new Circle(15), new Triangle(3, 4, 5) };

        foreach (IFigure figure in figures)
        {
            IFigure clone = figure.Clone();
            figure.GetInfo();
            clone.GetInfo();
            Console.WriteLine("Це різні об'єкти: " + !ReferenceEquals(figure, clone));
            Console.WriteLine();
        }

        Console.Read();
    }
}
