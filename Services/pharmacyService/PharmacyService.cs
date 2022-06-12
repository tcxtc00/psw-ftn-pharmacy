using AutoMapper;
using psw_ftn_pharmacy.Dtos;
using System.Text;

namespace psw_ftn_pharmacy.Services.eupravaService
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public PharmacyService(IConfiguration config, IMapper mapper)
        {
            this.mapper = mapper;
            this.config = config;
        }

        public async Task<ServiceResponse<RecipeDto>> PostRecipe(RecipeDto recipe)
        {
            var response = new ServiceResponse<RecipeDto>();

            try
            {
                CreateRecipe(recipe.Medicine, recipe.Therapy, recipe.DoctorName);
            }
            catch (System.Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            response.Data = recipe;
            return response;
        }

        private void CreateRecipe(string medicine, string therapy, string doctorName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string documentName = "Recipe-" + medicine + "-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            
            string fileName = currentDirectory + @"\Recipies\" + documentName;    
            try    
            {    
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))    
                {    
                    File.Delete(fileName);    
                }    
                // Create a new file     
                using (FileStream fs = File.Create(fileName))     
                {    
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true)
                    .GetBytes("Pharmacy Official Document" + System.Environment.NewLine + "Name of medicine: " + medicine  
                    + System.Environment.NewLine + "Instructions for therapy: " + therapy
                    + System.Environment.NewLine + "Recipe from doctor: " + doctorName
                    + System.Environment.NewLine + "Date of Recipe: " 
                    + DateTime.Now.ToString("yyyy-MM-dd"));    

                    fs.Write(title, 0, title.Length);  
                }    
            
                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(fileName))    
                {    
                    string s = "";    
                    while ((s = sr.ReadLine()) != null)    
                    {    
                        Console.WriteLine(s);    
                    }    
                }    
            }    
            catch (Exception Ex)    
            {    
                Console.WriteLine(Ex.ToString());    
            }
        }
    }
}