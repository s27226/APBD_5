namespace WebApplication1.DTO;

public class VisitRequest
{
    public DateTime Date { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public double Cost { get; set; }

}