namespace DateTimeOnly.DataAccessLayer.Entities;

public class Invoice
{
    public Guid Id { get; set; }

    public DateOnly Date { get; set; }

    public double Amount { get; set; }
}
