using System.ComponentModel;

namespace Proyecto.Presentacion.Models
{
    public class Vendedor //esta clase es el front, lo que ven los demas
    {
        [DisplayName("CÓDIGO")]
        public int ide_ven { get; set; }

        [DisplayName("VENDEDOR")]
        public string ? nom_ven { get; set; }

        [DisplayName("SUELDO")]
        public double sue_ven { get; set; }

        [DisplayName("FECHA DE INGRESO")]
        public DateTime fec_ing { get; set; }

        [DisplayName("DISTRITO")]
        public string ? nom_dis { get; set; }
    }
}
