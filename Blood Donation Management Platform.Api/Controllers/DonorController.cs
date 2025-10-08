using Domain.Exceptions.DonorExceptions;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction;
using Shared;

namespace Blood_Donation_Management_Platform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController(IServiceManager serviceManager):ControllerBase
    {
        [HttpPost("CreateDonerProfile")]
        public async Task<IActionResult> CreateDoner(DonorRequestDto donorRequestDto)
        {
            var result = await serviceManager.donorService.AddDonor(donorRequestDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status201Created,
                Message = "Donor profile created successfully",
                Data = result
            });

        }
        [HttpPost("UpdateDonerProfile")]
        public async Task<IActionResult> UpdateDoner(DonorUpdateDto donorUpdateDto)
        {
            var result = await serviceManager.donorService.UpdateDonor(donorUpdateDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donor profile updated successfully",
                Data = result
            });

        }

        [HttpDelete("DeleteDonerProfile")]
        public async Task<IActionResult> DeleteeDoner(int id)
        {
            var result = await serviceManager.donorService.DeleteDonor(id);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donor profile Deleted successfully",
                Data = result
            });

        }
       
        [HttpGet("GetAllDonors")]
        public async Task<IActionResult> GetAllDonors()
        {
            var result = await serviceManager.donorService.GetAllDonors();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All donors fetched successfully",
                Data = result
            });

        }
       
        [HttpGet("GetDonerById")]
        public async Task<IActionResult> GetDonerById(int id)
        {
            try
            {
                var result = await serviceManager.donorService.GetDonorsByIdOrNameOrEmailOrPhoneNumber(id);
                return Ok(result);

            }
            catch (DonorNotFoundException)
            {
                return NotFound();
            }
        }
       
        [HttpGet("GetDonerByNameOrPhoneNumberOrEmail")]
        public async Task<IActionResult> GetDonerByNameOrPhoneNumberOrEmail(string Input)
        {

            var result = await serviceManager.donorService.GetDonorsByIdOrNameOrEmailOrPhoneNumber(Input);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donor fetched Successfully",
                Data = result
            });

        }
       
    }
}
