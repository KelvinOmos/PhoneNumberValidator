using PhoneNumber.Application.Interfaces;

namespace PhoneNumber.Application.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
