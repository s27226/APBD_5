namespace WebApplication1.Models;

public class Visit
{
    public Visit(DateTime date, Animal animal, string description, double cost)
    {
        Date = date;
        Animal = animal;
        Description = description;
        Cost = cost;
    }

    public Visit()
    {
        
    }

    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public double Cost { get; set; }
}