using psw_ftn_pharmacy.Dtos;

namespace psw_ftn_pharmacy.Services
{
    public interface IPharmacyService
    {
        Task<ServiceResponse<RecipeDto>> PostRecipe(RecipeDto recipe);
    }
}