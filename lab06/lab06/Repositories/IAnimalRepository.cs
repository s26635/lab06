using lab06.DTO;
using lab06.Models;

namespace lab06.Repositories;

public interface IAnimalRepository
{
    IList<Animal> GetAnimals(string orderBy);

    Animal GetAnimal(int id);

    Animal AddAnimal(AnimalDTO animalDTO);
    
    void UpdateAnimal(int idAnimal, AnimalDTO animalDTO);

    void DeleteAnimal(int id);
}