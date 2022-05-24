using System.Text.Json;
using DateTimeOnly.Converters;

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

Console.ReadLine();

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