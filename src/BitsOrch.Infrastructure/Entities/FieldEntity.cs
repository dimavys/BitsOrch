using Microsoft.EntityFrameworkCore;

namespace BitsOrch.Infrastructure.Entities;

public class FieldEntity
{
    // public string Id { get; set; }
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public bool Married { get; set; }
    
    public string MobilePhone { get; set; }
    
    public decimal Salary { get; set; }
}
