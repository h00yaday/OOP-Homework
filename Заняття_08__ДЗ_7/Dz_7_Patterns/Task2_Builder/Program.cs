namespace Builder;

class Pizza
{
    private string dough = "";
    private string sauce = "";
    private string topping = "";

    public void SetDough(string d) => dough = d;
    public void SetSauce(string s) => sauce = s;
    public void SetTopping(string t) => topping = t;

    public void Info()
    {
        Console.WriteLine("Dough: {0}\nSauce: {1}\nTopping: {2}\n", dough, sauce, topping);
    }
}

// Abstract Builder
abstract class PizzaBuilder
{
    protected Pizza pizza = new Pizza();

    public Pizza GetPizza() => pizza;
    public void CreateNewPizza() => pizza = new Pizza();

    public abstract void BuildDough();
    public abstract void BuildSauce();
    public abstract void BuildTopping();
}

// Concrete Builder
class HawaiianPizzaBuilder : PizzaBuilder
{
    public override void BuildDough() => pizza.SetDough("cross");
    public override void BuildSauce() => pizza.SetSauce("mild");
    public override void BuildTopping() => pizza.SetTopping("ham+pineapple");
}

// Concrete Builder
class SpicyPizzaBuilder : PizzaBuilder
{
    public override void BuildDough() => pizza.SetDough("pan baked");
    public override void BuildSauce() => pizza.SetSauce("hot");
    public override void BuildTopping() => pizza.SetTopping("pepperoni+salami");
}

// Concrete Builder (додано)
class MargaritaPizzaBuilder : PizzaBuilder
{
    public override void BuildDough() => pizza.SetDough("thin");
    public override void BuildSauce() => pizza.SetSauce("tomato");
    public override void BuildTopping() => pizza.SetTopping("mozzarella+basil");
}

// Director
class Waiter
{
    private PizzaBuilder? pizzaBuilder;

    public void SetPizzaBuilder(PizzaBuilder pb) => pizzaBuilder = pb;

    public Pizza GetPizza()
    {
        if (pizzaBuilder == null)
            throw new InvalidOperationException("Builder не задано");
        return pizzaBuilder.GetPizza();
    }

    // Порядок кроків задає директор, а не будівельник
    public void ConstructPizza()
    {
        if (pizzaBuilder == null)
            throw new InvalidOperationException("Builder не задано");
        pizzaBuilder.CreateNewPizza();
        pizzaBuilder.BuildDough();
        pizzaBuilder.BuildSauce();
        pizzaBuilder.BuildTopping();
    }
}

class Program
{
    static void Main()
    {
        Waiter waiter = new Waiter();
        PizzaBuilder[] builders =
        {
            new HawaiianPizzaBuilder(),
            new SpicyPizzaBuilder(),
            new MargaritaPizzaBuilder()
        };

        foreach (PizzaBuilder builder in builders)
        {
            waiter.SetPizzaBuilder(builder);
            waiter.ConstructPizza();
            waiter.GetPizza().Info();
        }

        Console.ReadKey();
    }
}
