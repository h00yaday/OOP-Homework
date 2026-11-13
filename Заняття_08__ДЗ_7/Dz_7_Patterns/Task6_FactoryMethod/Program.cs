using System.Text;

namespace FactoryMethod;

// Умова: служба доставки. Логістика планує доставку, але який транспорт
// буде використано, вирішують підкласи (фабричний метод CreateTransport).

// Product
interface ITransport
{
    void Deliver(string cargo);
}

// ConcreteProduct
class Truck : ITransport
{
    public void Deliver(string cargo) => Console.WriteLine($"Вантажівка везе \"{cargo}\" дорогою");
}

class Ship : ITransport
{
    public void Deliver(string cargo) => Console.WriteLine($"Корабель везе \"{cargo}\" морем");
}

class Drone : ITransport
{
    public void Deliver(string cargo) => Console.WriteLine($"Дрон доставляє \"{cargo}\" повітрям");
}

// Creator
abstract class Logistics
{
    // Фабричний метод
    protected abstract ITransport CreateTransport();

    // Бізнес-логіка не залежить від конкретного транспорту
    public void PlanDelivery(string cargo)
    {
        ITransport transport = CreateTransport();
        transport.Deliver(cargo);
    }
}

// ConcreteCreator
class RoadLogistics : Logistics
{
    protected override ITransport CreateTransport() => new Truck();
}

class SeaLogistics : Logistics
{
    protected override ITransport CreateTransport() => new Ship();
}

class AirLogistics : Logistics
{
    protected override ITransport CreateTransport() => new Drone();
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Logistics[] services = { new RoadLogistics(), new SeaLogistics(), new AirLogistics() };

        foreach (Logistics service in services)
        {
            service.PlanDelivery("Посилка");
        }

        Console.ReadKey();
    }
}
