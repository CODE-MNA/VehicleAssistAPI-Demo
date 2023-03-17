using VehicleAssist.Domain;

namespace VehicleAssist.API.Models
{
    public class ErrorModel
    {

        public int StatusCode { get; set; }
        public List<string> ErrorMessage { get; set; }   
    }
}
