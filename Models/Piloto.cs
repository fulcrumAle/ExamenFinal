using System.ComponentModel.DataAnnotations;

namespace ProyectoBackendAlejandro.Models
{
    public class Piloto
    {
        [Key]
        public int Nro_Licencia { get; set; }
        public string Restricciones { get; set; }
        public double Salario { get; set; }
        public string Turno { get; set; }

    }
}