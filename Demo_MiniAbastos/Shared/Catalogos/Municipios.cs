using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared.Catalogos
{
    public class Municipios
    {
        [Key]
        public string c_Municipio { get; set; }

        public string c_Estado { get; set; }

        public string Descripcion { get; set; }
    }
}
