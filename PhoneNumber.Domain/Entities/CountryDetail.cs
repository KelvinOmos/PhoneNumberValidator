using PhoneNumber.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.Domain.Entities
{
    public class CountryDetail : BaseEntity
    {
        public int CountryId { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }

        public Country Country { get; set; }
    }
}