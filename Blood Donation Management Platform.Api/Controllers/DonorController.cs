using Domain.Exceptions.DonorExceptions;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction;
using Shared;
using Twilio.TwiML.Messaging;

namespace Blood_Donation_Management_Platform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController(IServiceManager serviceManager):ControllerBase
    {
        [HttpPost("CreateDonerProfile")]
        public async Task<IActionResult> CreateDoner(DonorRequestDto donorRequestDto)
        {
            try
            {
                var result = await serviceManager.donorService.AddDonor(donorRequestDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Donor profile created successfully",
                    Data = result
                });
            }catch (DonorValidationException)
            {
                return BadRequest();
            }catch (DonorConflictException)
            {
                return Conflict();
            }
            catch(DonorDatabaseException ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("UpdateDonerProfile")]
        public async Task<IActionResult> UpdateDoner(DonorUpdateDto donorUpdateDto)
        {
            try
            {
                var result = await serviceManager.donorService.UpdateDonor(donorUpdateDto);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donor profile updated successfully",
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

        [HttpDelete("DeleteDonerProfile")]
        public async Task<IActionResult> DeleteeDoner(int id)
        {
            try
            {
                var result = await serviceManager.donorService.DeleteDonor(id);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donor profile Deleted successfully",
                    Data = result
                });
            }
            catch (DonorValidationException ex)
            {
                return BadRequest(new
                {
                    Message= ex.Message
                });
            }catch(DonorDatabaseDelete ex)
            {
                return StatusCode(500,ex.Message);  
            }

        }
       
        [HttpGet("GetAllDonors")]
        public async Task<IActionResult> GetAllDonors()
        {
            try
            {
                var result = await serviceManager.donorService.GetAllDonors();
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "All donors fetched successfully",
                    Data = result
                });

            }
            catch (DonorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
       
        [HttpGet("GetDonerById")]
        public async Task<IActionResult> GetDonerById(int id)
        {
            try
            {
                var result = await serviceManager.donorService.GetDonorsByIdOrNameOrEmailOrPhoneNumber(id);
                return Ok(result);

            }
            catch (DonorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch (DonorValidationException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }
       
        [HttpGet("GetDonerByNameOrPhoneNumberOrEmail")]
        public async Task<IActionResult> GetDonerByNameOrPhoneNumberOrEmail(string Input)
        {

            try
            {
                var result = await serviceManager.donorService.GetDonorsByIdOrNameOrEmailOrPhoneNumber(Input);
                return Ok(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Donor fetched Successfully",
                    Data = result
                });
            }catch (DonorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch (DonorValidationException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }

        }
       
    }
}
