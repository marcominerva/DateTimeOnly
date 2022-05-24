var dateOnly = DateOnly.FromDateTime(DateTime.Now);
var timeOnly = TimeOnly.FromDateTime(DateTime.Now);

Console.WriteLine(dateOnly);
Console.WriteLine(timeOnly);

Console.ReadLine();

public class Invoice
{
    public DateOnly Date { get; set; }

    public double Amount { get; set; }
}

public class Restaurant
{
    public string Name { get; set; }

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }
}