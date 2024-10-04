using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared
{
    public class Producto
    {
        [Key]
        public long Id { get; set; }
        public string UrlImagen { get; set; }
        public string Nombre { get; set; }
        public string? Marca { get; set; }

        public int CantidadEmpaques { get; set; }

        public string? NombreSegundoEmpaque { get; set; }
        public string? NombreTercerEmpaque { get; set; }

        public int CantidadProductoSegundoEmpaque { get; set; }
        public int CantidadProductoTercerEmpaque { get; set; }

        public bool TienePromocion { get; set; } = false;
        public decimal PrecioIndividualPromocion { get; set; } = 0m;

        public decimal PrecioIndividual { get; set; }
        public decimal PrecioSegundoEmpaque { get; set; }
        public decimal PrecioTercerEmpaque { get; set; }

        public decimal Cantidad { get; set; } = 1;

        public string? EmpaqueSeleccionado { get; set; }


        #region Para la Base de Datos
        public decimal Precio { get; set; }
        public string? Empaque { get; set; }
        public decimal Subtotal { get; set; }
        #endregion
        
    }

    public enum TipoEmpaque
    {
        Pieza,
        Paquete,
        Caja
    }

}

