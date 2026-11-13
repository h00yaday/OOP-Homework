using System.Text;

namespace Adapter;

// Умова: застосунок працює з температурними датчиками через інтерфейс
// ITemperatureSensor (градуси Цельсія). Є сторонній американський датчик
// з іншим інтерфейсом (градуси Фаренгейта), який не можна змінити.
// Адаптер дозволяє використовувати його без змін клієнтського коду.

// Target
interface ITemperatureSensor
{
    double GetCelsius();
}

class LocalSensor : ITemperatureSensor
{
    public double GetCelsius() => 21.5;
}

// Adaptee: сторонній клас з несумісним інтерфейсом
class AmericanSensor
{
    public double ReadFahrenheit() => 98.6;
}

// Adapter
class FahrenheitSensorAdapter : ITemperatureSensor
{
    private readonly AmericanSensor sensor;

    public FahrenheitSensorAdapter(AmericanSensor sensor)
    {
        this.sensor = sensor;
    }

    public double GetCelsius() => (sensor.ReadFahrenheit() - 32) * 5 / 9;
}

// Client
class WeatherStation
{
    public void Report(ITemperatureSensor sensor) =>
        Console.WriteLine($"Температура: {sensor.GetCelsius():F1} °C");
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        WeatherStation station = new WeatherStation();
        station.Report(new LocalSensor());
        station.Report(new FahrenheitSensorAdapter(new AmericanSensor()));

        Console.ReadKey();
    }
}
