using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirDolomieu.Server
{
    [ApiController]
    [Route("[controller]")]
    public class VolsController : ControllerBase
    {
        private readonly ILogger<VolsController> _logger;

        public VolsController(ILogger<VolsController> logger)
        {
            _logger = logger;
        }
         
        //string Numvol = string.Empty;   

        [HttpGet(Name = "GetAllVols")]
        public IEnumerable<ViewVol> GetAllVols()
        {
            IEnumerable<ViewVol> List = new List<ViewVol>();
            DataExtract data = new DataExtract();
            List = data.GetAllViewVols();
            return List;
        }
        

        [HttpGet("/VolbyID:{Numvol}")]
        public Vol GetOneVol(string Numvol)
        {
            Vol Vol = new Vol();
            DataExtract data = new DataExtract();
            Vol = data.GetOneVol(Numvol);
            return Vol;
        }

        [HttpGet("/VolbyPilote:{Numpilote}")]
        public IEnumerable<ViewVol> GetVolsbypilote(int Numpilote)
        {
            IEnumerable<ViewVol> Vol = new List<ViewVol>();
            DataExtract data = new DataExtract();
            Vol = data.GetViewVolsbyPilote(Numpilote);
            return Vol;
        }

        [HttpGet("/VolbyAvion:{Numavion}")]
        public IEnumerable<ViewVol> GetVolsbyavion(int Numavion)
        {
            IEnumerable<ViewVol> Vol = new List<ViewVol>();
            DataExtract data = new DataExtract();
            Vol = data.GetViewVolsbyAvion(Numavion);
            return Vol;
        }

        [HttpGet("/VolbyPiloteEtAvion:{Numpilote}:{Numavion}")]
        public IEnumerable<ViewVol> VolbyPiloteEtAvion(int Numpilote, int Numavion)
        {
            IEnumerable<ViewVol> Vol = new List<ViewVol>();
            DataExtract data = new DataExtract();
            Vol = data.GetViewVolsbyAll(Numpilote,Numavion);
            return Vol;
        }

        [HttpPost(Name = "PutNewVol")]
        public void Create(Fly Newvol)
        {
            DataExtract data = new DataExtract();
            if (data.GetOneVol(Newvol.Numvol) == null)
            {
                Vol vol = new Vol(Newvol);
                
                string message = data.PutNewVol(vol);

                if (message == "OK")
                {
                    
                }
                else
                {
                    throw new Exception(message);
                }
            }
            else
            {
                throw new Exception("Le vol " + Newvol.Numvol + " existe déja");
            }
        }


    }
}
