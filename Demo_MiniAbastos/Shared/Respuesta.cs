namespace Demo_MiniAbastos.Shared
{
    public class Respuesta<T>
    {
        public EstadosDeRespuesta Estado { get; set; }

        public string Mensaje { get; set; }

        public T Datos { get; set; }
    }

}
