using Microsoft.Build.Framework;
using System.ComponentModel;
using da = System.ComponentModel.DataAnnotations;


namespace Proyecto.Presentacion.Models
{
    public class VendedorO //BACK
    {

        [DisplayName("CÓDIGO")]
        public int ide_ven { get; set; }

        [DisplayName("NOMBRES")]
        [da.Required(ErrorMessage="NOMBRE DEL VENDEDOR")]
        public string nom_ven { get; set; }

        [DisplayName("APELLIDOS")]
        [da.Required(ErrorMessage = "APELLIDO DEL VENDEDOR")]
        public string ape_ven { get; set; }

        [DisplayName("SUELDO")]
        [da.Required(ErrorMessage = "SUELDO DEL VENDEDOR")]
        public double sue_ven { get; set; }

        [DisplayName("FECHA DE INGRESO")]
        [da.Required(ErrorMessage = "FECHA DE INGRESO")]
        public DateTime fec_ing { get; set; }

        [DisplayName("DISTRITO")]
        [da.Required(ErrorMessage = "DISTRITO")]
        public int ide_dis { get; set; }
    }
}
