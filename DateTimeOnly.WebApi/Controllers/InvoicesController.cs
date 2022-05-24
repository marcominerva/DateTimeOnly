using Microsoft.AspNetCore.Mvc;

namespace DateTimeOnly.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    [HttpGet]
    public IActionResult Search(DateOnly date) => NoContent();

    [HttpPost]
    public IActionResult Save(Invoice invoice) => NoContent();
}

public record class Invoice(DateOnly Date, double Amount);