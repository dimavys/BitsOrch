using BitsOrch.Infrastructure.Entities;
using CsvHelper.Configuration;

namespace BitsOrch.ApplicationCore.Mapping;

public class FieldMapper : ClassMap<FieldEntity>
{
    public FieldMapper()
    {
        Map(m => m.Name).Index(0);
        Map(m => m.BirthDate).Index(1);
        Map(m => m.Married).Index(2);
        Map(m => m.MobilePhone).Index(3);
        Map(m => m.Salary).Index(4);
    }
}