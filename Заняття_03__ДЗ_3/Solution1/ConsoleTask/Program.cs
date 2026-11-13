Console.Write("Введіть ціле число: ");

try
{
    string input = Console.ReadLine() ?? string.Empty;

    if (input.Contains('.') || input.Contains(','))
    {
        throw new FormatException("Введено дробове число.");
    }

    int number = int.Parse(input);

    Console.WriteLine($"Ви ввели число {number}");
}
catch (FormatException)
{
    Console.WriteLine("Помилка: потрібно ввести ціле число.");
}
catch (OverflowException)
{
    Console.WriteLine("Помилка: введене число занадто велике або занадто мале.");
}