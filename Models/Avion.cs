using System.ComponentModel.DataAnnotations;

namespace ProyectoBackendAlejandro.Models
{
    public class Avion
    {
        [Key]
        public int idAvion { get; set; }
        public string Modelo { get; set; }
        public double Peso { get; set; }
        public int Capacidad { get; set; }
        public int idHangar { get; set; }
        public int idPiloto { get; set; }
    }
}