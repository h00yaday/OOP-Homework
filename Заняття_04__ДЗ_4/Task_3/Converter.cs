namespace Task3;

public class Converter
{
    private readonly decimal _usdRate;
    private readonly decimal _eurRate;

    public Converter(decimal usdRate, decimal eurRate)
    {
        if (usdRate <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(usdRate),
                "Курс долара повинен бути більшим за 0.");
        }

        if (eurRate <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(eurRate),
                "Курс євро повинен бути більшим за 0.");
        }

        _usdRate = usdRate;
        _eurRate = eurRate;
    }

    public decimal ConvertUahToUsd(decimal amount)
    {
        return amount / _usdRate;
    }

    public decimal ConvertUsdToUah(decimal amount)
    {
        return amount * _usdRate;
    }

    public decimal ConvertUahToEur(decimal amount)
    {
        return amount / _eurRate;
    }

    public decimal ConvertEurToUah(decimal amount)
    {
        return amount * _eurRate;
    }
}
