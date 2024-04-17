using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("visits")]
public class VisitsController : ControllerBase
{
    private IMockDb _mockDb;

    public VisitsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet("{id}")]
    public IActionResult GetVisitByAnimalId(int id)
    {
        foreach (var animal in _mockDb.GetAllAnimals())
        {
            if (animal.Id == id)
            {
                foreach(var visit in _mockDb.GetAllVisits())
                {
                    if (visit.Animal == animal)
                    {
                        return Ok(visit);
                    }
                    
                }
            }
        }
        return NotFound();
    }

    [HttpPost()]
    public IActionResult AddVisit(VisitRequest visit)
    {
        foreach (var animal in _mockDb.GetAllAnimals())
        {
            if(visit.AnimalId == animal.Id)
            {
                _mockDb.AddVisit(new Visit(DateTime.Now,animal,visit.Description,visit.Cost));
                return NoContent();
            }
        }
        return NotFound();
    }

}