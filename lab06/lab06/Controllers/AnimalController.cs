using lab06.DTO;
using lab06.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab06.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult  GetAnimals(string orderBy = "name")
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] AnimalDTO animalDTO)
    {
        var result = _animalService.AddAnimal(animalDTO);
        return Ok(result);
    }

    [HttpPut("{idAnimal}")]
    public IActionResult UpdateAnimal(int idAnimal, [FromBody] AnimalDTO animalDTO)
    {
        _animalService.UpdateAnimal(idAnimal, animalDTO);
        return NoContent();
    }

    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        _animalService.DeleteAnimal(idAnimal);
        return NoContent();
    }

}