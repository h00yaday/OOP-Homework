using System.Text;
using Task_4;

namespace GeographyAbstract;

public class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Масив базового типу: GetInfo() викликається поліморфно
        GeographicObject[] objects =
        {
            new River(50.45, 30.52, "Дніпро", "Найбільша річка України", 60.0, 2201.0),
            new Mountain(48.16, 24.50, "Говерла", "Найвища гора України", 2061.0)
        };

        foreach (GeographicObject obj in objects)
        {
            Console.WriteLine(obj.GetInfo());
            Console.WriteLine();
        }
    }
}
