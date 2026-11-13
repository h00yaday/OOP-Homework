using System;

class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

class EmailSender
{
    public void Send(Email email)
    {
        // sending...
    }
}

class Logger
{
    public void Log(Email email)
    {
        Console.WriteLine(
            "Email from '" + email.From +
            "' to '" + email.To + "' was send");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email()
        {
            From = "Me",
            To = "Vasya",
            Theme = "Who are you?"
        };

        Email e2 = new Email()
        {
            From = "Vasya",
            To = "Me",
            Theme = "vacuum cleaners!"
        };

        EmailSender sender = new EmailSender();
        Logger logger = new Logger();

        sender.Send(e1);
        logger.Log(e1);

        sender.Send(e2);
        logger.Log(e2);

        Console.ReadKey();
    }
}