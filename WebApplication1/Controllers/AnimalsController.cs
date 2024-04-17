using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("animals")]
public class AnimalsController : ControllerBase
{

    private IMockDb _mockDb;

    public AnimalsController(IMockDb mockDb)
    {
        _mockDb = mockDb;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mockDb.GetAllAnimals());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        foreach (var animal in _mockDb.GetAllAnimals())
        {
            if (animal.Id == id)
            {
                return Ok(animal);
            }
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        if (_mockDb.GetAllAnimals().FirstOrDefault(x => x.Id == animal.Id) is not null)
            return Conflict();

        _mockDb.AddAnimal(animal);
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(Animal animal, int id)
    {
        _mockDb.ReplaceAnimal(animal, id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        if(_mockDb.DeleteAnimal(id))
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }

    }
}