using System;
using System.Collections.Generic;

class UtilitiesPrice
{
    public virtual double Price()
    {
        return 0;
    }
}

class FixedPrice : UtilitiesPrice
{
    private double _fixedAmount;

    public FixedPrice(double fixedAmount)
    {
        _fixedAmount = fixedAmount;
    }

    public override double Price()
    {
        return _fixedAmount;
    }
}

class ConsumedAmountPrice : UtilitiesPrice
{
    private double _rate;
    private double _consumedAmount;

    public ConsumedAmountPrice(double rate, double consumedAmount)
    {
        _rate = rate;
        _consumedAmount = consumedAmount;
    }

    public override double Price()
    {
        return _rate * _consumedAmount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<UtilitiesPrice> utilities = new List<UtilitiesPrice>
        {
            new FixedPrice(100),
            new ConsumedAmountPrice(2.64, 100),
            new FixedPrice(70),
            new ConsumedAmountPrice(8.50, 10)
        };

        double totalSum = 0;
        foreach (UtilitiesPrice utility in utilities)
        {
            totalSum += utility.Price();
        }

        Console.WriteLine($"Загальна сума до сплати: {totalSum}");
    }
}
