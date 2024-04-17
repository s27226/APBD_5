using WebApplication1.Models;
namespace WebApplication1.Services;

public class MockDb : IMockDb
{
    private ICollection<Animal> _animals;
    private ICollection<Visit> _visits;

    public MockDb()
    {
        _animals = new List<Animal>
        {
            new Animal
            {
                Id = 1,
                Name = "Bones",
                Category = "Dog",
                Mass = 20.0,
                FurColor = "Black"
            },
            new Animal
            {
                Id = 2,
                Name = "Snickers",
                Category = "Cat",
                Mass = 15.0,
                FurColor = "Black"
            }
        };
        _visits = new List<Visit>
        {
            new Visit
            {
                Date = DateTime.Now,
                Animal = (_animals as List<Animal>)[0],
                Description = "Example1",
                Cost = 27.59
            },
            new Visit
            {
                Date = DateTime.Now,
                Animal = (_animals as List<Animal>)[1],
                Description = "Example2",
                Cost = 31.54
            }
        };
    }

    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public bool ReplaceAnimal(Animal animal, int id)
    {
        (_animals as List<Animal>)[id] = animal;
        return true;
    }

    public bool DeleteAnimal(int id)
    {
        foreach (var animal in _animals)
        {
            if (animal.Id == id)
            {
                _animals.Remove(animal);
                return true;
            }
        }
        return false;
    }

    public ICollection<Visit> GetAllVisits()
    {
        return _visits;
    }

    public void AddVisit(Visit visit)
    {
        _visits.Add(visit);
    }
}