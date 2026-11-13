namespace AbstractFactory;

// AbstractProductA
abstract class Car
{
    public abstract void Info();
}

// ConcreteProductA1
class Ford : Car
{
    public override void Info() => Console.WriteLine("Ford");
}

// ConcreteProductA2
class Toyota : Car
{
    public override void Info() => Console.WriteLine("Toyota");
}

// ConcreteProductA3 (додано)
class Mercedes : Car
{
    public override void Info() => Console.WriteLine("Mercedes");
}

// AbstractProductB
abstract class Engine
{
    public abstract void GetPower();
}

// ConcreteProductB1
class FordEngine : Engine
{
    public override void GetPower() => Console.WriteLine("Ford Engine 4.4");
}

// ConcreteProductB2
class ToyotaEngine : Engine
{
    public override void GetPower() => Console.WriteLine("Toyota Engine 3.2");
}

// ConcreteProductB3 (додано)
class MercedesEngine : Engine
{
    public override void GetPower() => Console.WriteLine("Mercedes Engine 5.5");
}

// AbstractFactory
interface ICarFactory
{
    Car CreateCar();
    Engine CreateEngine();
}

// ConcreteFactory1
class FordFactory : ICarFactory
{
    public Car CreateCar() => new Ford();
    public Engine CreateEngine() => new FordEngine();
}

// ConcreteFactory2
class ToyotaFactory : ICarFactory
{
    public Car CreateCar() => new Toyota();
    public Engine CreateEngine() => new ToyotaEngine();
}

// ConcreteFactory3 (додано): створює узгоджену пару Mercedes + MercedesEngine
class MercedesFactory : ICarFactory
{
    public Car CreateCar() => new Mercedes();
    public Engine CreateEngine() => new MercedesEngine();
}

class Program
{
    // Клієнт працює лише з абстракціями і не знає конкретних класів
    static void Assemble(ICarFactory factory)
    {
        Car car = factory.CreateCar();
        Engine engine = factory.CreateEngine();
        car.Info();
        engine.GetPower();
        Console.WriteLine();
    }

    static void Main()
    {
        ICarFactory[] factories = { new ToyotaFactory(), new FordFactory(), new MercedesFactory() };

        foreach (ICarFactory factory in factories)
        {
            Assemble(factory);
        }

        Console.ReadKey();
    }
}
