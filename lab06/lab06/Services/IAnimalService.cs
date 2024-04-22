using lab06.DTO;
using lab06.Models;

namespace lab06.Services;

public interface IAnimalService
{
    IOrderedEnumerable<Animal> GetAnimals(string orderBy);

    Animal GetAnimal(int id);

    Animal AddAnimal(AnimalDTO animalDTO);

    void UpdateAnimal(int idAnimal, AnimalDTO animalDTO);
    void DeleteAnimal(int id);
}