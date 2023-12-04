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
    public class HangaresController : ControllerBase
    {

        private readonly ILogger<HangaresController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public HangaresController(ILogger<HangaresController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Hangar> GetHangar()
        {

            return _aplicacionContexto.Hangar.ToList();
        }
        [Route("/DeleteHangar")]
        [HttpDelete]
        public IActionResult Delete(int hangarID)
        {
            _aplicacionContexto.Hangar.Remove(_aplicacionContexto.Hangar.ToList().Where(x => x.idHangar == hangarID).FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(hangarID);
        }
        [Route("/PostHangar")]
        [HttpPost]
        public IActionResult Post([FromBody] Hangar hangar)
        {
            _aplicacionContexto.Hangar.Add(hangar);
            _aplicacionContexto.SaveChanges();
            return Ok(hangar);
        }
        [Route("/PutHangar")]
        [HttpPut]
        public IActionResult Put([FromBody] Hangar hangar)
        {
            _aplicacionContexto.Hangar.Update(hangar);
            _aplicacionContexto.SaveChanges();
            return Ok(hangar);
        }
    }
}