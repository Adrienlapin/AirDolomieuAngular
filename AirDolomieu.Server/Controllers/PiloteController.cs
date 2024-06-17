using Microsoft.AspNetCore.Mvc;

namespace AirDolomieu.Server
{
    [ApiController]
    [Route("[controller]")]
    public class PiloteController : ControllerBase
    {
        private readonly ILogger<PiloteController> _logger;

    public PiloteController(ILogger<PiloteController> logger)
    {
        _logger = logger;
    }

        [HttpGet(Name = "GetAllPilote")]
        public IEnumerable<Pilote> GetAllPilote()
        {
            IEnumerable<Pilote> List = new List<Pilote>();
            DataExtract data = new DataExtract();
            List = data.GetAllPilote();
            return List;
        }

    }
}
