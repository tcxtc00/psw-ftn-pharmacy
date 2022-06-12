using psw_ftn_pharmacy.Dtos;
using psw_ftn_pharmacy.Services;
using Microsoft.AspNetCore.Mvc;

namespace psw_ftn_pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService pharmacyService;
        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        [HttpPost("/Recipe")]
        public async Task<ActionResult<ServiceResponse<RecipeDto>>> PostRecipe(RecipeDto recipe)
        {
            var response = await pharmacyService.PostRecipe(recipe);

            if(response.Success == false)
            {
                return  StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
    }
}
