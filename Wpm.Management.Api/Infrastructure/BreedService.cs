using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infrastructure;

public class BreedService : IBreedService
{
    public readonly List<Breed> breeds =
    [
        new Breed(Guid.Parse("3f9c2a47-8b1e-4f32-af13-9c6d2e4b8a21"), "Bulldog", new WeightRange(10, 20), new WeightRange(2, 5)),
        new Breed(Guid.Parse("4f9c2a47-8b1e-4f32-af13-9c6d2e4b8a22"), "Caniche", new WeightRange(1, 10), new WeightRange(1, 5))
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
