using System.Globalization;

namespace Task3;

public class Program
{
    // Приймає і крапку, і кому як десятковий роздільник (41.5 або 41,5)
    private static decimal ReadDecimal()
    {
        string input = (Console.ReadLine() ?? string.Empty).Trim().Replace(',', '.');
        return decimal.Parse(input, NumberStyles.Number, CultureInfo.InvariantCulture);
    }

    private static void Main()
    {
        try
        {
            Console.Write("Введіть курс долара до гривні: ");
            decimal usdRate = ReadDecimal();

            Console.Write("Введіть курс євро до гривні: ");
            decimal eurRate = ReadDecimal();

            Converter converter = new Converter(usdRate, eurRate);

            Console.WriteLine();
            Console.WriteLine("1 - Гривні в долари");
            Console.WriteLine("2 - Долари в гривні");
            Console.WriteLine("3 - Гривні в євро");
            Console.WriteLine("4 - Євро в гривні");

            Console.Write("Оберіть операцію: ");
            string choice = Console.ReadLine() ?? string.Empty;

            Console.Write("Введіть суму: ");
            decimal amount = ReadDecimal();

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Сума не може бути від'ємною.");
            }

            decimal result;

            switch (choice)
            {
                case "1":
                    result = converter.ConvertUahToUsd(amount);
                    break;

                case "2":
                    result = converter.ConvertUsdToUah(amount);
                    break;

                case "3":
                    result = converter.ConvertUahToEur(amount);
                    break;

                case "4":
                    result = converter.ConvertEurToUah(amount);
                    break;

                default:
                    Console.WriteLine("Помилка: невідома операція.");
                    return;
            }

            Console.WriteLine($"Результат: {result:F2}");
        }
        catch (FormatException)
        {
            Console.WriteLine(
                "Помилка: потрібно вводити числові значення.");
        }
        catch (OverflowException)
        {
            Console.WriteLine(
                "Помилка: введене число занадто велике.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Помилка: {ex.ParamName} має некоректне значення.");
        }
    }
}
