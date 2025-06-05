using System;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        string countryNormalized = _country.Trim().ToLower();
        return countryNormalized == "usa" ||
               countryNormalized == "u.s." ||
               countryNormalized == "us" ||
               countryNormalized == "united states" ||
               countryNormalized == "united states of america";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
