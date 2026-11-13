namespace MediatorPattern;

// "Mediator"
abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

// "ConcreteMediator"
// У прикладі з посібника посередник знав рівно двох колег і пересилав
// повідомлення "іншому". З третім колегою так вже не вийде, тому
// посередник зберігає список і розсилає повідомлення всім, крім відправника.
class ConcreteMediator : Mediator
{
    private readonly List<Colleague> colleagues = new List<Colleague>();

    public void Register(Colleague colleague) => colleagues.Add(colleague);

    public override void Send(string message, Colleague sender)
    {
        foreach (Colleague colleague in colleagues)
        {
            if (colleague != sender)
                colleague.Notify(message);
        }
    }
}

// "Colleague"
abstract class Colleague
{
    protected Mediator mediator;

    protected Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public void Send(string message) => mediator.Send(message, this);

    public abstract void Notify(string message);
}

class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator) { }

    public override void Notify(string message) =>
        Console.WriteLine("Colleague1 gets message: " + message);
}

class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator) { }

    public override void Notify(string message) =>
        Console.WriteLine("Colleague2 gets message: " + message);
}

// Додано
class ConcreteColleague3 : Colleague
{
    public ConcreteColleague3(Mediator mediator) : base(mediator) { }

    public override void Notify(string message) =>
        Console.WriteLine("Colleague3 gets message: " + message);
}

class Program
{
    static void Main()
    {
        ConcreteMediator m = new ConcreteMediator();
        ConcreteColleague1 c1 = new ConcreteColleague1(m);
        ConcreteColleague2 c2 = new ConcreteColleague2(m);
        ConcreteColleague3 c3 = new ConcreteColleague3(m);

        m.Register(c1);
        m.Register(c2);
        m.Register(c3);

        c1.Send("How are you?");
        c2.Send("Fine, thanks");
        c3.Send("Hello!");

        Console.Read();
    }
}
