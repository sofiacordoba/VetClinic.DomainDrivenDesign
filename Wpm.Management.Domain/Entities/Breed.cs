using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;
public class Breed : Entity
{
    public string Name { get; init; }
    public WeightRange MaleIdealWeightRange { get; init; }
    public WeightRange FemaleIdealWeightRange { get; init; }

    public Breed(Guid id,
                string name,
                WeightRange maleWeightRange,
                WeightRange femaleWeightRange)
    {
        Id = id;
        Name = name;
        MaleIdealWeightRange = maleWeightRange;
        FemaleIdealWeightRange = femaleWeightRange;
    }
}
