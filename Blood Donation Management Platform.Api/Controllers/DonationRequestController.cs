using Microsoft.AspNetCore.Mvc;
using Services;
using ServicesAbstraction;
using Shared;

namespace Blood_Donation_Management_Platform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationRequestController:ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public DonationRequestController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("CreateDonationRequestProfile")]
        public async Task<IActionResult> CreateDonationRequest(DonationRequestDto donationRequestDto)
        {
            var result = await serviceManager.donationRequestService.AddDonationRequest(donationRequestDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status201Created,
                Message = "Donation Request profile created successfully",
                Data = result
            });

        }
        [HttpPost("UpdateDonationRequestProfile")]
        public async Task<IActionResult> UpdateDonationRequest(DonationUpdateDto donationUpdateDto)
        {
            var result = await serviceManager.donationRequestService.UpdateDonationRequest(donationUpdateDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donation Request profile updated successfully",
                Data = result
            });

        }

        [HttpDelete("DeleteDonationRequestProfile")]
        public async Task<IActionResult> DeleteDonationRequest(int id)
        {
            var result = await serviceManager.donationRequestService.DeleteDonationRequest(id);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donation Request profile Deleted successfully",
                Data = result
            });

        }

        [HttpGet("GetAllDonationRequests")]
        public async Task<IActionResult> GetAllDonationRequests()
        {
            var result = await serviceManager.donationRequestService.GetAllDonationRequest();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All Donation Requests fetched successfully",
                Data = result
            });

        }

        [HttpGet("GetDonationRequestById")]
        public async Task<IActionResult> GetDonerById(int id)
        {
            var result = await serviceManager.donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(id);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donation Request fetched successfully",
                Data = result
            });

        }

        [HttpGet("GetDonationRequestByNameOrPhoneNumberOrEmail")]
        public async Task<IActionResult> GetDonationRequestByNameOrPhoneNumberOrEmail(string input)
        {

            var result = await serviceManager.donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(input);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Donation Request fetched successfully",
                Data = result
            });

        }
    }
}
