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
    public class AvionesController : ControllerBase
    {

        private readonly ILogger<AvionesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public AvionesController(ILogger<AvionesController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Avion> GetAvion()
        {

            return _aplicacionContexto.Avion.ToList();
        }
        [Route("/DeleteAvion")]
        [HttpDelete]
        public IActionResult Delete(int avionID)
        {
            _aplicacionContexto.Avion.Remove(_aplicacionContexto.Avion.ToList().Where(x => x.idAvion == avionID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(avionID);
        }
        [Route("/PostAvion")]
        [HttpPost]
        public IActionResult Post([FromBody] Avion avion)
        {
            _aplicacionContexto.Avion.Add(avion);
            _aplicacionContexto.SaveChanges();
            return Ok(avion);
        }
        [Route("/PutAvion")]
        [HttpPut]
        public IActionResult Put([FromBody] Avion avion)
        {
            _aplicacionContexto.Avion.Update(avion);
            _aplicacionContexto.SaveChanges();
            return Ok(avion);
        }
    }
}