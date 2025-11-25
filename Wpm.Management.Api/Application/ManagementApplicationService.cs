using System.Reflection.Metadata;
using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Application;
public class ManagementApplicationService
{
    private readonly IBreedService _breedService;
    private readonly ManagementDbContext _dbContext;
    public ManagementApplicationService(IBreedService breedService, ManagementDbContext dbContext)
    {
        _breedService = breedService;
        _dbContext = dbContext;
    }
    public async Task Handle(CreatePetCommand command)
    {
        var breedId = new BreedId(command.BreedId, _breedService);
        var newPet = new Pet(command.Id,
            command.Name,
            command.Age,
            command.Color,
            command.SexOfPet,
            breedId);

        await _dbContext.Pets.AddAsync(newPet);
        await _dbContext.SaveChangesAsync();  
    }
}
