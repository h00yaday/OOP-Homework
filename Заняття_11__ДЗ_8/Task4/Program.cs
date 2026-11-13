using System;

interface IPrice
{
    void SetPrice(double price);
}

interface IDiscount
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}

interface IColor
{
    void SetColor(byte color);
}

interface ISize
{
    void SetSize(byte size);
}
class Book : IPrice, IDiscount
{
    public void SetPrice(double price)
    {
        Console.WriteLine("Book price: " + price);
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine("Book discount: " + discount);
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine("Book promocode: " + promocode);
    }
}
class Outerwear : IPrice, IDiscount, IColor, ISize
{
    public void SetPrice(double price)
    {
        Console.WriteLine("Outerwear price: " + price);
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine("Outerwear discount: " + discount);
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine("Outerwear promocode: " + promocode);
    }

    public void SetColor(byte color)
    {
        Console.WriteLine("Color: " + color);
    }

    public void SetSize(byte size)
    {
        Console.WriteLine("Size: " + size);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(500);
        book.ApplyDiscount("10%");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(2000);
        jacket.ApplyDiscount("20%");
        jacket.SetColor(1);
        jacket.SetSize(48);

        Console.ReadKey();
    }
}