namespace PhoneNumber.Application.DTO
{
    public class CountryDto
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetailDto> CountryDetails { get; set; }
    }
}
