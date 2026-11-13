using System.Text;

namespace Decorator;

// Component
abstract class ChristmasTree
{
    public abstract string GetDescription();
    public abstract bool CanShine();

    public void Show()
    {
        Console.WriteLine(GetDescription());
        Console.WriteLine(CanShine() ? "Ялинка світиться!" : "Ялинка не світиться.");
        Console.WriteLine();
    }
}

// ConcreteComponent
class SimpleTree : ChristmasTree
{
    private readonly int height;

    public SimpleTree(int height)
    {
        this.height = height;
    }

    public override string GetDescription() => $"Ялинка висотою {height} см";
    public override bool CanShine() => false;
}

// Decorator: сам є ялинкою і містить ялинку, яку прикрашає
abstract class TreeDecorator : ChristmasTree
{
    protected ChristmasTree tree;

    protected TreeDecorator(ChristmasTree tree)
    {
        this.tree = tree;
    }

    public override string GetDescription() => tree.GetDescription();
    public override bool CanShine() => tree.CanShine();
}

// ConcreteDecorator: прикраси (поля)
class Toys : TreeDecorator
{
    private readonly string kind;
    private readonly int count;

    public Toys(ChristmasTree tree, string kind, int count) : base(tree)
    {
        this.kind = kind;
        this.count = count;
    }

    public override string GetDescription() =>
        base.GetDescription() + $", прикраси: {kind} ({count} шт.)";
}

// ConcreteDecorator: гірлянда (метод, що дозволяє ялинці світитися)
class Garland : TreeDecorator
{
    private readonly string color;

    public Garland(ChristmasTree tree, string color) : base(tree)
    {
        this.color = color;
    }

    public override string GetDescription() =>
        base.GetDescription() + $", гірлянда ({color})";

    public override bool CanShine() => true;
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        ChristmasTree tree = new SimpleTree(150);
        tree.Show();

        tree = new Toys(tree, "кульки", 20);
        tree.Show();

        tree = new Garland(tree, "різнокольорова");
        tree.Show();

        // Декоратори можна комбінувати в будь-якому порядку і кількості
        ChristmasTree another = new Garland(
            new Toys(new Toys(new SimpleTree(200), "шишки", 10), "зірка", 1),
            "тепла біла");
        another.Show();

        Console.ReadKey();
    }
}
