namespace Wpm.Clinic.Domain.Entities;

public record Text
{
    public string Value { get; init; }

    public Text(string value)
    {
        Validate(value);
        Value = value;
    }

    private void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("value", "text not valid");
        }    

        if (value.Length > 500)
        {
            throw new ArgumentException("value too long (max. 500 characters)");
        }    
    }

    public static implicit operator Text(string value)
    {
        return new Text(value);
    }
}
