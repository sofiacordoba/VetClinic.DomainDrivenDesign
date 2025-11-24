using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain.Services;
public interface IBreedService
{
    Breed? GetBreed(Guid id);
}

public class FakeBreedService : IBreedService
{
    public readonly List<Breed> breeds =
    [
        new Breed(Guid.NewGuid(), "Bulldog", new ValueObjects.WeightRange(10, 20), new ValueObjects.WeightRange(2, 5)),
        new Breed(Guid.NewGuid(), "Caniche", new ValueObjects.WeightRange(1, 10), new ValueObjects.WeightRange(1, 5))
    ];
    public Breed? GetBreed(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException("Invalid breed id");
        }

        var result = breeds.Find(x => x.Id == id);
        return result ?? throw new ArgumentException("Breed not found");
    }
}