using System.Collections.ObjectModel;

namespace Task_5;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<Product> _products;

    // Набір товарів, які по черзі додаються кнопкою "Add product"
    private readonly Func<Product>[] _catalog =
    {
        () => new FoodProduct(75.50, "Ukraine", "Milk", DateTime.Today, "Dairy product", 7, 1, "l"),
        () => new Book(450, "Ukraine", "Kobzar", DateTime.Today, "Poetry", 320, "Taras Shevchenko", "A-BA-BA-HA-LA-MA-HA"),
        () => new FoodProduct(42.00, "Poland", "Apples", DateTime.Today, "Fruit", 30, 2, "kg"),
        () => new Book(380, "Ukraine", "Intermezzo", DateTime.Today, "Short story", 96, "Mykhailo Kotsiubynskyi", "Folio")
    };

    private int _nextCatalogIndex;

    public MainPage()
    {
        InitializeComponent();

        _products = new ObservableCollection<Product>();
        ProductsCollectionView.ItemsSource = _products;

        // Початкове заповнення таблиці
        for (int i = 0; i < 3; i++)
        {
            AddNextProduct();
        }
    }

    private void AddNextProduct()
    {
        _products.Add(_catalog[_nextCatalogIndex]());
        _nextCatalogIndex = (_nextCatalogIndex + 1) % _catalog.Length;
    }

    private void AddProductButton_Clicked(object sender, EventArgs e)
    {
        AddNextProduct();
    }

    // Видаляє виділений товар, а якщо нічого не виділено - останній
    private void DeleteProductButton_Clicked(object sender, EventArgs e)
    {
        if (_products.Count == 0)
        {
            return;
        }

        if (ProductsCollectionView.SelectedItem is Product selected)
        {
            _products.Remove(selected);
            ProductsCollectionView.SelectedItem = null;
        }
        else
        {
            _products.RemoveAt(_products.Count - 1);
        }
    }
}
