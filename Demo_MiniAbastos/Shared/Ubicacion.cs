namespace Demo_MiniAbastos.Shared
{
    public class Ubicacion
    {

        public long Id { get; set; }
        public bool EsSucursal { get; set; } = false;
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool UbicacionSeleccionada { get; set; } = false;
    }
}
