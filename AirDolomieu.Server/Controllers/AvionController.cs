using Microsoft.AspNetCore.Mvc;

namespace AirDolomieu.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvionController : Controller
    {

        [HttpGet(Name = "GetAllAvion")]
        public IEnumerable<Avion> GetAllAvion()
        {
            IEnumerable<Avion> List = new List<Avion>();
            DataExtract data = new DataExtract();
            List = data.GetAllAvion();
            return List;
        }
    }
}
