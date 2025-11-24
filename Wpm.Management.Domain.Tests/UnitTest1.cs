using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using System.Xml.Linq;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_must_be_equal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet(id, "Pupi", 10, "Brown", SexOfPetEnum.Female, breedId);
        var pet2 = new Pet(id, "Tito", 15, "Black", SexOfPetEnum.Male, breedId);

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Weight_must_be_equal()
    {
        var w1 = new Weight(10.2m);
        var w2 = new Weight(10.2m);

        Assert.True(w1 == w2);
    }

    [Fact]
    public void WeightRange_must_be_equal()
    {
        var w1 = new WeightRange(10.2m, 20.1m);
        var w2 = new WeightRange(10.2m, 20.1m);

        Assert.True(w1 == w2);
    }

    [Fact]
    public void BreedId_must_be_equal()
    {
        var breedService = new FakeBreedService();
        var b1 = breedService.breeds[0].Id;
        var breedId = new BreedId(b1, breedService);

        Assert.NotNull(breedId);
    }

    [Fact]
    public void WeightClass_must_be_ideal()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Test", 9, "Gray", SexOfPetEnum.Male, breedId);
        pet.SetWeight(9.5m, breedService);

        Assert.True(pet.WeightClass == WeightClassEnum.Underweight);
    }
}