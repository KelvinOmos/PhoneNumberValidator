using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.Domain.Entities
{
    public class PhoneNumberResponse
    {
        public string Number { get; set; }
        public Country Country { get; set; }
    }
}
