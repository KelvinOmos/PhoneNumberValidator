using PhoneNumber.Application.DTO;
using PhoneNumber.Application.Wrappers;

namespace PhoneNumber.Application.Interfaces
{
    public interface IPhoneNumberService
    {
        Task<Response<PhoneNumberResponseDto>> ValidatePhoneNumber(string phoneNumber);
    }
}
