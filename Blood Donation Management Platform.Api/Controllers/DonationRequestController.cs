using Domain.Exceptions.DonationRequestExceptions;
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
            try
            {
                var result = await serviceManager.donationRequestService.AddDonationRequest(donationRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Donation Request profile created successfully",
                    Data = result
                });
            }catch (DonationRequestValidationException ex)
            {
                return BadRequest(ex.Message);
            }catch(DonationRequestDatabaseException ex)
            {
                return StatusCode(500,ex.Message);
            }

        }
        [HttpPut("UpdateDonationRequestProfile")]
        public async Task<IActionResult> UpdateDonationRequest(DonationUpdateDto donationUpdateDto)
        {
            try
            {
                var result = await serviceManager.donationRequestService.UpdateDonationRequest(donationUpdateDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donation Request profile updated successfully",
                    Data = result
                });
            }catch (DonationRequestValidationException ex)
            {
                return BadRequest(ex.Message);
            }catch(DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(DonationRequestDatabaseDelete ex)
            {
                return StatusCode(500,ex.Message);
            }

        }

        [HttpDelete("DeleteDonationRequestProfile")]
        public async Task<IActionResult> DeleteDonationRequest(int id)
        {
            try
            {
                var result = await serviceManager.donationRequestService.DeleteDonationRequest(id);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donation Request profile Deleted successfully",
                    Data = result
                });
            }
            catch (DonationRequestValidationException ex)
            {
                return BadRequest(ex.Message);
            }catch(DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DonationRequestDatabaseDelete ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetAllDonationRequests")]
        public async Task<IActionResult> GetAllDonationRequests()
        {
            try
            {
                var result = await serviceManager.donationRequestService.GetAllDonationRequest();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "All Donation Requests fetched successfully",
                    Data = result
                });
            }
            catch (DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            

        }

        [HttpGet("GetDonationRequestById")]
        public async Task<IActionResult> GetDonationRequestById(int id)
        {
            try
            {
                var result = await serviceManager.donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(id);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donation Request fetched successfully",
                    Data = result
                });
            }
            catch (DonationRequestValidationException ex)
            {
                return BadRequest(ex.Message);
            }catch(DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("GetDonationRequestByNameOrPhoneNumberOrEmail")]
        public async Task<IActionResult> GetDonationRequestByNameOrPhoneNumberOrEmail(string input)
        {
            try
            {
                var result = await serviceManager.donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(input);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donation Request fetched successfully",
                    Data = result
                });
            }catch (DonationRequestValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DonationRequestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
