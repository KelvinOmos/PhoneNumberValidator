using PhoneNumber.Domain.Common;

namespace PhoneNumber.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }

        public IEnumerable<CountryDetail> CountryDetails { get; set; }
    }
}
