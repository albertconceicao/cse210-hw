public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _postalCode;

    public Address(string street, string city, string state, string postalCode)
    {
        _street = street;
        _city = city;
        _state = state;
        _postalCode = postalCode;
    }

    public override string ToString()
    {
        return $"{_street}, {_city}, {_state}, {_postalCode}";
    }
}
