namespace MauiTask;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private void OnShowNumberButtonClicked(object sender, EventArgs e)
    {
        try
        {
            string input = NumberEntry.Text ?? string.Empty;

            if (input.Contains('.') || input.Contains(','))
            {
                throw new FormatException("Введено дробове число.");
            }

            int number = int.Parse(input);

            ResultLabel.Text = $"Ви ввели число {number}";
        }
        catch (FormatException)
        {
            ResultLabel.Text = "Помилка: потрібно ввести ціле число.";
        }
        catch (OverflowException)
        {
            ResultLabel.Text =
                "Помилка: введене число занадто велике або занадто мале.";
        }
    }
}