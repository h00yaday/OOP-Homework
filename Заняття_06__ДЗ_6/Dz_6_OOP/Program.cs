using System.Text.Json;
namespace Dz_6_OOP;
public class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Файл копіюється поруч з .exe (CopyToOutputDirectory у .csproj)
        string path = Path.Combine(AppContext.BaseDirectory, "books.json");
        string json = File.ReadAllText(path);
        List<Book>? books = JsonSerializer.Deserialize<List<Book>>(json);
        if (books == null)
        {
            Console.WriteLine("Не вдалось зчитати дані.");
            return;
        }
        foreach (Book book in books)
        {
            Console.WriteLine($"Назва книги: {book.Title}");
            Console.WriteLine($"Видавництво: {book.PublishingHouse.Name}");
            Console.WriteLine($"Адреса видавництва: {book.PublishingHouse.Adress}");
            Console.WriteLine();
        }
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string result = JsonSerializer.Serialize(books, options);

        Console.WriteLine("Серіалізований JSON:");
        Console.WriteLine(result);
    }
}
