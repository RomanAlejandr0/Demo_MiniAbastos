using System.ComponentModel.DataAnnotations;

namespace Demo_MiniAbastos.Shared
{
    public class CuentaBanco
    {
        public long Id { get; set; }
        public string NombreTitularTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NombreBanco { get; set; }
        public string MM { get; set; }
        public string AA { get; set; }
        public string CVV { get; set; }
        public string LogoBanco { get; set; }
        public bool CuentaBancoSeleccionada { get; set; } = false;
    }
}
