using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared
{
    public class Domicilio
    {
        [Key]
        public long Id { get; set; }
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public string NombreDomicilio { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        //[Required(ErrorMessage = "El codigo postal es requerido")]
        public string CodigoPostal { get; set; }

        public DateTime Fecha { get; set; }
    }
}
