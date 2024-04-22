using lab06.DTO;
using lab06.Models;
using lab06.Repositories;

namespace lab06.Services;

internal class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IOrderedEnumerable<Animal> GetAnimals(string orderBy)
    {
        IList<Animal> animals = _animalRepository.GetAnimals();
        
        switch (orderBy.ToLower())
        {
            case "description":
                return animals.OrderBy(a => a.Description);
            case "category":
                return animals.OrderBy(a => a.Category);
            case "area":
                return animals.OrderBy(a => a.Area);
            default:
                return animals.OrderBy(a => a.Name);
        }
    }
    

    public Animal GetAnimal(int id)
    {
        return _animalRepository.GetAnimal(id);
    }

    public Animal AddAnimal(AnimalDTO animalDTO)
    {
        return _animalRepository.AddAnimal(animalDTO);
    }

    public void UpdateAnimal(int idAnimal, AnimalDTO animalDTO)
    {
        _animalRepository.UpdateAnimal(idAnimal, animalDTO);
    }

    public void DeleteAnimal(int id)
    {
        _animalRepository.DeleteAnimal(id);
    }
}