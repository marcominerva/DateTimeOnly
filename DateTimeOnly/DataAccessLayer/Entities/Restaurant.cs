namespace DateTimeOnly.DataAccessLayer.Entities;

public class Restaurant
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }
}