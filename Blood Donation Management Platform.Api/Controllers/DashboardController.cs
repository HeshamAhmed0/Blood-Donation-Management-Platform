using Domain.Meduls.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction;
using Shared;
using Twilio.TwiML.Messaging;

namespace Blood_Donation_Management_Platform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController :ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public DashboardController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("AddDonationHistory")]
        public async Task<IActionResult> AddDonationHistory(DonationHistoryRequestDto donationHistoryRequestDto)
        {
            var result =await serviceManager.dashboardService.AddDonationHistory(donationHistoryRequestDto);

            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message="Add Donation History Done",
                Data=result
            });
        }
        [HttpPost("AddDonor")]
        public async Task<IActionResult> AddDonor (DonorRequestDto donorRequestDto)
        {
            var result =await serviceManager.dashboardService.AddDonor(donorRequestDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Add Donor Done",
                Data = result
            });

        }
        [HttpGet("CountOfDonationRequest")]
        public async Task<IActionResult> CountOfDonationRequest()
        {
            var result = await serviceManager.dashboardService.CountOfDonationRequest();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "CountOfDonationRequest",
                Data = result
            });
        }
        [HttpGet("CountOfDonors")]
        public async Task<IActionResult> CountOfDonors()
        {
            var result = await serviceManager.dashboardService.CountOfDonors();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "CountOfDonors",
                Data = result
            });
        }
        [HttpGet("GetAllDonationHistory")]
        public async Task<IActionResult> GetAllDonationHistory()
        {
            var result =await serviceManager.dashboardService.GetAllDonationHistory();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "AllDonationHistory",
                Data = result
            });
        }
        [HttpPost("GetAllDonationHistoryByDonorId")]
        public async Task<IActionResult> GetAllDonationHistoryByDonorId(int donorId)
        {
            var result =await serviceManager.dashboardService.GetAllDonationHistoryByDonorId(donorId);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "AllDonationHistoryByDonorId",
                Data = result
            });
        }
        [HttpPost("GetAllDonationHistoryByPatientId")]
        public async Task<IActionResult> GetAllDonationHistoryByPatientId(int PatientId)
        {
            var result = await serviceManager.dashboardService.GetAllDonationHistoryByPatientId(PatientId);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "AllDonationHistoryByPatientId",
                Data = result
            });
        }
        [HttpGet("GetAllDonationRequest")]
        public async Task<IActionResult> GetAllDonationRequest()
        {
            var result = await serviceManager.dashboardService.GetAllDonationRequest();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "AllDonationRequest",
                Data = result
            });
        }
        [HttpGet("GetAllDonors")]
        public async Task<IActionResult> GetAllDonors()
        {
            var result = await serviceManager.dashboardService.GetAllDonors();
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "AllDonors",
                Data = result
            });
        }
        [HttpPost("GetDonationRequestsByBloodType")]
        public async Task<IActionResult> GetDonationRequestsByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
            var result = await serviceManager.dashboardService.GetDonationRequestsByBloodType(bloodTypesRequestDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All Donation Requests By BloodType",
                Data = result
            });
        }
        [HttpPost("GetDonorsByBloodType")]
        public async Task<IActionResult> GetDonorsByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
            var result = await serviceManager.dashboardService.GetDonorsByBloodType(bloodTypesRequestDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "All Donor By BloodType",
                Data = result
            });
        }
        [HttpPost("UpdateDonationRequestStatus")]
        public async Task<IActionResult> UpdateDonationRequestStatus(int DonationRequestId, StatusOfRequestDto NewstatusOfRequestDto)
        {
            var result = await serviceManager.dashboardService.UpdateDonationRequestStatus(DonationRequestId, NewstatusOfRequestDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Update Donation Request Status Done",
                Data = result
            });
        }
        [HttpPost("UpdateDonor")]
        public async Task<IActionResult> UpdateDonor(DonorUpdateDto donorUpdateDto)
        {
            var result =await serviceManager.dashboardService.UpdateDonor(donorUpdateDto);
            return Ok(new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Update Donor Done",
                Data = result
            });
        }
    }
}
