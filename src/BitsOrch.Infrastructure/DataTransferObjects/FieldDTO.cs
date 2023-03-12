namespace BitsOrch.Infrastructure;

public class FieldDTO
{
    [CsvHelper.Configuration.Attributes.Index(0)]
    public string Name { get; set; }
    
    [CsvHelper.Configuration.Attributes.Index(1)]
    public DateTime BirthDate { get; set; }

    [CsvHelper.Configuration.Attributes.Index(2)]
    public bool Married { get; set; }
    
    [CsvHelper.Configuration.Attributes.Index(3)]
    public string MobilePhone { get; set; }
    
    [CsvHelper.Configuration.Attributes.Index(4)]
    public decimal Salary { get; set; }
}