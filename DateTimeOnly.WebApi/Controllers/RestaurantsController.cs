using Microsoft.AspNetCore.Mvc;

namespace DateTimeOnly.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    [HttpPost]
    public IActionResult Save(Restaurant restaurant) => NoContent();
}

public record class Restaurant(string Name, TimeOnly OpeningTime, TimeOnly ClosingTime);