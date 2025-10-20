using Domain.Exceptions.DonationRequestExceptions;
using Domain.Exceptions.DonorExceptions;
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
    public class DashboardController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public DashboardController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("AddDonationHistory")]
        public async Task<IActionResult> AddDonationHistory(DonationHistoryRequestDto donationHistoryRequestDto)
        {
            try
            {
                var result = await serviceManager.dashboardService.AddDonationHistory(donationHistoryRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Add Donation History Done",
                    Data = result
                });
            }
            catch (DonorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("AddDonor")]
        public async Task<IActionResult> AddDonor(DonorRequestDto donorRequestDto)
        {

            try
            {
                var result = await serviceManager.dashboardService.AddDonor(donorRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Add Donor Done",
                    Data = result
                });
            }
            catch (DonorValidationException)
            {
                return BadRequest();
            }
            catch (DonorConflictException)
            {
                return Conflict();
            }
            catch (DonorDatabaseException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("CountOfDonationRequest")]
        public async Task<IActionResult> CountOfDonationRequest()
        {
            try
            {
                var result = await serviceManager.dashboardService.CountOfDonationRequest();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "CountOfDonationRequest",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("CountOfDonors")]
        public async Task<IActionResult> CountOfDonors()
        {
            try
            {

                var result = await serviceManager.dashboardService.CountOfDonors();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "CountOfDonors",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetAllDonationHistory")]
        public async Task<IActionResult> GetAllDonationHistory()
        {
            try
            {
                var result = await serviceManager.dashboardService.GetAllDonationHistory();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "AllDonationHistory",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("GetAllDonationHistoryByDonorId")]
        public async Task<IActionResult> GetAllDonationHistoryByDonorId(int donorId)
        {
            try
            {
                var result = await serviceManager.dashboardService.GetAllDonationHistoryByDonorId(donorId);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "AllDonationHistoryByDonorId",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("GetAllDonationHistoryByPatientId")]
        public async Task<IActionResult> GetAllDonationHistoryByPatientId(int PatientId)
        {
            try
            {
                var result = await serviceManager.dashboardService.GetAllDonationHistoryByPatientId(PatientId);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "AllDonationHistoryByPatientId",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetAllDonationRequest")]
        public async Task<IActionResult> GetAllDonationRequest()
        {
            try
            {
                var result = await serviceManager.dashboardService.GetAllDonationRequest();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "AllDonationRequest",
                    Data = result
                });
            }
            catch (DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet("GetAllDonors")]
        public async Task<IActionResult> GetAllDonors()
        {
            try
            {
                var result = await serviceManager.dashboardService.GetAllDonors();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "AllDonors",
                    Data = result
                });
            }
            catch (DonorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("GetDonationRequestsByBloodType")]
        public async Task<IActionResult> GetDonationRequestsByBloodType([FromQuery] BloodTypesRequestDto bloodTypesRequestDto)
        {
            try
            {
                var result = await serviceManager.dashboardService.GetDonationRequestsByBloodType(bloodTypesRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "All Donation Requests By BloodType",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("GetDonorsByBloodType")]
        public async Task<IActionResult> GetDonorsByBloodType([FromQuery] BloodTypesRequestDto bloodTypesRequestDto)
        {
            try
            {
                var result = await serviceManager.dashboardService.GetDonorsByBloodType(bloodTypesRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "All Donor By BloodType",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch("UpdateDonationRequestStatus")]
        public async Task<IActionResult> UpdateDonationRequestStatus(int DonationRequestId, StatusOfRequestDto NewstatusOfRequestDto)
        {
            try
            {
                var result = await serviceManager.dashboardService.UpdateDonationRequestStatus(DonationRequestId, NewstatusOfRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Donation Request Status Done",
                    Data = result
                });
            }
            catch (DonationRequestValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("UpdateDonor")]
        public async Task<IActionResult> UpdateDonor(DonorUpdateDto donorUpdateDto)
        {

            try
            {
                var result = await serviceManager.dashboardService.UpdateDonor(donorUpdateDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Update Donor Done",
                    Data = result
                });
            }
            catch (DonorValidationException)
            {
                return BadRequest();
            }
            catch (DonorNotFoundException)
            {
                return NotFound();
            }
            catch (DonorDatabaseException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
