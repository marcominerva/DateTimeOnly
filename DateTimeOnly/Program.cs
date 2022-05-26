using DateTimeOnly.DataAccessLayer;

ExecuteJsonSample();
//await ExecuteEntityFrameworkCoreSampleAsync();

Console.ReadLine();

static void ExecuteJsonSample()
{

}

static Task ExecuteEntityFrameworkCoreSampleAsync()
{
    using var db = new DataContext();

    return Task.CompletedTask;
}

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