namespace Wpm.Management.Domain.ValueObjects;
public record Weight
{
    public decimal Value { get; init; }

    public Weight(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException("Invalid value");

        Value = value;
    }

    public static implicit operator Weight(decimal value)
    {
        return new Weight(value);
    }

}
