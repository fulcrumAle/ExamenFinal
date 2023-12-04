using System.ComponentModel.DataAnnotations;

namespace ProyectoBackendAlejandro.Models
{
    public class Hangar
    {
        [Key]
        public int idHangar { get; set; }
        public int Capacidad { get; set; }
        public string Localizacion { get; set; }

    }
}