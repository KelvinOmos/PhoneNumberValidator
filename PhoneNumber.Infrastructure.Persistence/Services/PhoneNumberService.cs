using Microsoft.EntityFrameworkCore;
using PhoneNumber.Application.DTO;
using PhoneNumber.Application.Interfaces;
using PhoneNumber.Application.Wrappers;
using PhoneNumber.Infrastructure.Contexts;
using Serilog;

namespace PhoneNumber.Infrastructure.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly ApplicationDbContext _context;

        public PhoneNumberService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PhoneNumberResponseDto>> ValidatePhoneNumber(string phoneNumber)
        {
            Log.Information("WELCOME TO VALIDATE PHONE NUMBER SERVICE");
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 10)
            {
                Log.Warning("Invalid phone number ({phonenumber})", phoneNumber);
                return await Task.FromResult(new Response<PhoneNumberResponseDto>() { Succeeded = false, Message = "Invalid phone number", Code = (long)ApiResponseCodes.FAIL });
            }

            try
            {
                var countryCode = phoneNumber.Substring(0, 3);
                var country = _context.Countries
                    .Include(c => c.CountryDetails)
                    .FirstOrDefault(c => c.CountryCode == countryCode);

                if (country == null)
                {
                    Log.Warning("Country not found with country code: ({countrycode})", countryCode);
                    return await Task.FromResult(new Response<PhoneNumberResponseDto>() { Succeeded = false, Message = "Country not found with country code: (" + countryCode + ")", Code = (long)ApiResponseCodes.ERROR });
                }

                var response = new PhoneNumberResponseDto
                {
                    Number = phoneNumber,
                    Country = new CountryDto
                    {
                        CountryCode = country.CountryCode,
                        Name = country.Name,
                        CountryIso = country.CountryIso,
                        CountryDetails = country.CountryDetails
                            .Select(cd => new CountryDetailDto
                            {
                                Operator = cd.Operator,
                                OperatorCode = cd.OperatorCode
                            })
                            .ToList()
                    }
                };
                Log.Warning("Successful");
                return await Task.FromResult(new Response<PhoneNumberResponseDto>() { Succeeded = true, Message = "Successful", Data = response, Code = (long)ApiResponseCodes.OK });
            }
            catch (ArgumentException ex)
            {
                Log.Information(ex, "Validation failed for phone number: {PhoneNumber}", phoneNumber);
                return await Task.FromResult(new Response<PhoneNumberResponseDto>() { Succeeded = false, Message = "Validation failed", Code = (long)ApiResponseCodes.ERROR });
            }
            catch (KeyNotFoundException ex)
            {
                Log.Information(ex, "Country not found for phone number: {PhoneNumber}", phoneNumber);
                return await Task.FromResult(new Response<PhoneNumberResponseDto>() { Succeeded = false, Message = "Country not found", Code = (long)ApiResponseCodes.NOT_FOUND });
            }
            catch (Exception ex)
            {
                Log.Information(ex, "An unexpected error occurred");
                return await Task.FromResult(new Response<PhoneNumberResponseDto>() { Succeeded = false, Message = "An unexpected error occurred", Code = (long)ApiResponseCodes.ERROR });
            }
        }
    }
}