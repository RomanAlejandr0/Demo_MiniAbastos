using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared
{
    public class Venta_DemoMiniabastos
    {
        [Key]
        public long Id { get; set; }
        public bool EntregaDomicilio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string Empaque { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
    }
}
