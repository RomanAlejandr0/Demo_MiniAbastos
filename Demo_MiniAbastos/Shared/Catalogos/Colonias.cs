using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared.Catalogos
{
    public class Colonias
    {
        [Key]
        public string c_Colonia { get; set; }

        public string c_CodigoPostal { get; set; }

        public string NombreAsentamiento { get; set; }
    }
}
