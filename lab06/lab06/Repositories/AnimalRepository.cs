using lab06.DTO;
using lab06.Models;

namespace lab06.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IList<Animal> GetAnimals(string orderBy)
    {
        throw new NotImplementedException();
    }

    public Animal GetAnimal(int id)
    {
        throw new NotImplementedException();
    }

    public Animal AddAnimal(AnimalDTO animalDTO)
    {
        throw new NotImplementedException();
    }

    public void UpdateAnimal(int idAnimal, AnimalDTO animalDTO)
    {
        throw new NotImplementedException();
    }

    public void DeleteAnimal(int id)
    {
        throw new NotImplementedException();
    }
}