using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumber.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
