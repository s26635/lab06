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

    public IList<Animal> GetAnimals(string orderBy)
    {
        List<Animal> list = (List<Animal>)_animalRepository.GetAnimals();

        switch (orderBy)
        {
            
        }
        
        return _animalRepository.GetAnimals();
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