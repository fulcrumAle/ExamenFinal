using Microsoft.AspNetCore.Mvc;
using ProyectoBackendAlejandro.Models;
using Microsoft.AspNetCore.Mvc;
using ProyectoBackendAlejandro.Models;
using Npgsql;
using ProyectoBackendAlejandro.Context;
using Microsoft.Extensions.Logging;

namespace ProyectoBackendAlejandro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PilotosController : ControllerBase
    {

        private readonly ILogger<PilotosController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public PilotosController(ILogger<PilotosController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Piloto> GetPiloto()
        {

            return _aplicacionContexto.Piloto.ToList();
        }
        [Route("/DeletePiloto")]
        [HttpDelete]
        public IActionResult Delete(int pilotoID)
        {
            _aplicacionContexto.Piloto.Remove(_aplicacionContexto.Piloto.ToList().Where(x => x.Nro_Licencia == pilotoID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(pilotoID);
        }
        [Route("/PostPiloto")]
        [HttpPost]
        public IActionResult Post([FromBody] Piloto piloto)
        {
            _aplicacionContexto.Piloto.Add(piloto);
            _aplicacionContexto.SaveChanges();
            return Ok(piloto);
        }
        [Route("/PutPiloto")]
        [HttpPut]
        public IActionResult Put([FromBody] Piloto piloto)
        {
            _aplicacionContexto.Piloto.Update(piloto);
            _aplicacionContexto.SaveChanges();
            return Ok(piloto);
        }
    }
}