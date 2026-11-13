using System;
using System.Collections.Generic;
using System.Text;

// Завдання 1. Порушено принцип єдиної відповідальності (SRP):
// клас Order одночасно зберігав товари, друкував замовлення і працював зі сховищем.
// Розділяємо на три класи, кожен з однією причиною для змін.

class Item
{
    public string Name { get; }
    public decimal Price { get; }

    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

// Відповідальність 1: дані замовлення та робота з товарами
class Order
{
    private readonly List<Item> itemList = new List<Item>();

    public IReadOnlyList<Item> GetItems() => itemList;
    public int GetItemCount() => itemList.Count;

    public decimal CalculateTotalSum()
    {
        decimal sum = 0;
        foreach (Item item in itemList)
            sum += item.Price;
        return sum;
    }

    public void AddItem(Item item) => itemList.Add(item);
    public void DeleteItem(Item item) => itemList.Remove(item);
}

// Відповідальність 2: відображення замовлення
class OrderPrinter
{
    public void PrintOrder(Order order)
    {
        Console.WriteLine("Друк замовлення на принтер...");
        ShowOrder(order);
    }

    public void ShowOrder(Order order)
    {
        Console.WriteLine($"Замовлення ({order.GetItemCount()} шт.):");
        foreach (Item item in order.GetItems())
            Console.WriteLine($"  {item.Name} - {item.Price} грн");
        Console.WriteLine($"Разом: {order.CalculateTotalSum()} грн");
    }
}

// Відповідальність 3: збереження в сховищі
class OrderRepository
{
    public void Load(Order order) => Console.WriteLine("Замовлення завантажено");
    public void Save(Order order) => Console.WriteLine("Замовлення збережено");
    public void Update(Order order) => Console.WriteLine("Замовлення оновлено");
    public void Delete(Order order) => Console.WriteLine("Замовлення видалено");
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Order order = new Order();
        Item phone = new Item("Телефон", 12000);
        order.AddItem(phone);
        order.AddItem(new Item("Чохол", 350));
        order.AddItem(new Item("Навушники", 1500));

        OrderPrinter printer = new OrderPrinter();
        OrderRepository repository = new OrderRepository();

        printer.ShowOrder(order);
        repository.Save(order);

        Console.WriteLine();
        order.DeleteItem(phone);
        printer.ShowOrder(order);
        repository.Update(order);

        Console.ReadKey();
    }
}
