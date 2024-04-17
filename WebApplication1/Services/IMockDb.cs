using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IMockDb
{
    public ICollection<Animal> GetAllAnimals();
    public void AddAnimal(Animal animal);
    public bool ReplaceAnimal(Animal animal, int id);
    public bool DeleteAnimal(int id);
    public ICollection<Visit> GetAllVisits();
    public void AddVisit(Visit visit);
}