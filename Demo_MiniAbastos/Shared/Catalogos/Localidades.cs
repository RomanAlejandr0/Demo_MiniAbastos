using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared.Catalogos
{
    public class Localidades
    {
        [Key]
        public string c_Localidad { get; set; }

        public string c_Estado { get; set; }

        public string Descripcion { get; set; }
    }
}
