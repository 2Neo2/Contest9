using System;

public class Citizen : IOptimist, IPessimist
{
    private readonly int predictedValue;

    private Citizen(int predictedValue)
    {
        this.predictedValue = predictedValue;
    }

    public double GetForecast()
    {
        return predictedValue * 1.1;
    }

    double IPessimist.GetForecast()
    {
        return predictedValue * 0.6;
    }

    double IOptimist.GetForecast()
    {
        return predictedValue * 2;
    }

    internal static Citizen Parse(string input)
    {
        int salary;
        if (!int.TryParse(input, out salary) && salary <= 0)
            throw new ArgumentException("Incorrect citizen");
        return new Citizen(salary);
    }
}