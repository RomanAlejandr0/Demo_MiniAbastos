using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared.Catalogos
{
    public class Estados
    {
        [Key]
        public string c_Estado { get; set; }

        public string c_Pais { get; set; }

        public string Nombre { get; set; }
    }
}
