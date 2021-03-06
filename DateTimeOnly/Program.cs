using System.Text.Json;
using DateTimeOnly.Converters;
using DateTimeOnly.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

ExecuteJsonSample();
await ExecuteEntityFrameworkCoreSampleAsync();

Console.ReadLine();

void ExecuteJsonSample()
{
    var dateOnly = DateOnly.FromDateTime(DateTime.Now);
    var timeOnly = TimeOnly.FromDateTime(DateTime.Now);

    Console.WriteLine(dateOnly);
    Console.WriteLine(timeOnly);

    var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    jsonSerializerOptions.Converters.Add(new DateOnlyConverter());
    jsonSerializerOptions.Converters.Add(new TimeOnlyConverter());

    var invoice = new Invoice { Amount = 42, Date = dateOnly };
    var json = JsonSerializer.Serialize(invoice, jsonSerializerOptions);

    Console.WriteLine(json);

    invoice = JsonSerializer.Deserialize<Invoice>(json, jsonSerializerOptions);
    Console.WriteLine(invoice.Date);

    var restaurant = new Restaurant { Name = "La Darsena", OpeningTime = new TimeOnly(19, 00), ClosingTime = new TimeOnly(23, 30) };
    json = JsonSerializer.Serialize(restaurant, jsonSerializerOptions);

    Console.WriteLine(json);
}

async Task ExecuteEntityFrameworkCoreSampleAsync()
{
    using var db = new DataContext();

    var invoices = await db.Invoices.OrderByDescending(i => i.Date).ToListAsync();

    //var newInvoice = new DateTimeOnly.DataAccessLayer.Entities.Invoice { Amount = 420, Date = new DateOnly(2021, 1, 1) };
    //_ = db.Invoices.Add(newInvoice);

    //_ = await db.SaveChangesAsync();
}

public class Invoice
{
    //[JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly Date { get; set; }

    public double Amount { get; set; }
}

public class Restaurant
{
    public string Name { get; set; }

    //[JsonConverter(typeof(TimeOnlyConverter))]
    public TimeOnly OpeningTime { get; set; }

    //[JsonConverter(typeof(TimeOnlyConverter))]
    public TimeOnly ClosingTime { get; set; }
}