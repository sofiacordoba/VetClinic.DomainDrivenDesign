using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain;
public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }    
    public Weight Weight { get; init; }
    public string Color { get; init; }
    public SexOfPet SexPet { get; init; }
    public BreedId BreedId { get; init; }
    public Pet(Guid id, string name, int age, Weight weight, string color, SexOfPet sexPet)
    {
        Id = id;
        Name = name;
        Age = age;
        Weight = weight;
        Color = color;
        SexPet = sexPet;
    }

    public enum SexOfPet
    {
        Male,
        Female
    }
}
