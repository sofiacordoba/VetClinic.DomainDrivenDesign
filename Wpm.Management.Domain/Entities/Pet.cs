using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;
public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public Weight Weight { get; private set; }
    public string Color { get; init; }
    public SexOfPetEnum SexOfPet { get; init; }
    public BreedId BreedId { get; init; }
    public WeightClassEnum WeightClass { get; private set; }
    public Pet(Guid id, string name, int age, string color, SexOfPetEnum sexPet, BreedId breedId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        SexOfPet = sexPet;
        BreedId = breedId;
    }

    public void SetWeight(Weight weight, IBreedService breedService)
    {
        Weight = weight;
        SetWeightClass(breedService);
    }

    private void SetWeightClass(IBreedService breedService)
    {
        var desiredBreed = breedService.GetBreed(BreedId.Value);
        var (from, to) = SexOfPet switch
        {
            SexOfPetEnum.Male => (desiredBreed.MaleIdealWeightRange.From, desiredBreed.MaleIdealWeightRange.To),
            SexOfPetEnum.Female => (desiredBreed.FemaleIdealWeightRange.From, desiredBreed.FemaleIdealWeightRange.To),
            _ => throw new NotImplementedException()
        };

        var weightClass = Weight.Value switch
        {
            _ when Weight.Value < from => WeightClassEnum.Underweight,
            _ when Weight.Value > to => WeightClassEnum.Overweight,
            _ => WeightClassEnum.Ideal
        };

        WeightClass = weightClass;
    }
}

public enum SexOfPetEnum
{
    Male,
    Female
}

public enum WeightClassEnum
{
    Unknown,
    Ideal,
    Underweight,
    Overweight
}
