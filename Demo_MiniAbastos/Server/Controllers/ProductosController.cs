using Demo_MiniAbastos.Shared;
using Demo_MiniAbastos.Shared.AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_MiniAbastos.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }


        #region Carrito
        [HttpGet("GetAll")]
        public async Task<Respuesta<List<Producto>>> GetAll()
        {
            var respuesta = new Respuesta<List<Producto>>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var productos = await context.DemoMiniabastos_Carrito.AsNoTracking().ToListAsync();

                respuesta.Datos = productos;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al consultar los productos {ex.InnerException.Message}";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> GuardarCarrito([FromBody] List<Producto> value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                foreach (var item in value)
                {
                    if (item.Id == 0)
                    {
                        context.DemoMiniabastos_Carrito.Add(item);
                    }
                }

                await context.SaveChangesAsync();

                respuesta.Datos = 1;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al guardar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> EliminarProductoDelCarrito([FromBody] long value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Producto Eliminado Correctamente"
            };

            try
            {
                var productoEliminado = await context.DemoMiniabastos_Carrito.Where(x => x.Id == value).FirstOrDefaultAsync();
                context.DemoMiniabastos_Carrito.Remove(productoEliminado);
                await context.SaveChangesAsync();

                respuesta.Datos = 1;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al eliminar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }
        
        #endregion


        #region Cuentas
        [HttpGet("GetCuenta")]
        public async Task<Respuesta<CuentaBanco>> GetCuenta()
        {
            var respuesta = new Respuesta<CuentaBanco>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var cuenta = await context.DemoMiniabastos_CuentasBanco.AsNoTracking().FirstOrDefaultAsync(x => x.CuentaBancoSeleccionada == true);

                respuesta.Datos = cuenta;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al consultar los productos {ex.InnerException.Message}";
            }

            return respuesta;
        }

        [HttpGet("GetCuentas")]
        public async Task<Respuesta<List<CuentaBanco>>> GetCuentas()
        {
            var respuesta = new Respuesta<List<CuentaBanco>>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var cuentas = await context.DemoMiniabastos_CuentasBanco.AsNoTracking().ToListAsync();

                respuesta.Datos = cuentas;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al consultar los productos {ex.InnerException.Message}";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> GuardarCuenta([FromBody] CuentaBanco value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                value.Id = 0;
                context.DemoMiniabastos_CuentasBanco.Add(value);
                await context.SaveChangesAsync();

                respuesta.Datos = value.Id;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al guardar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> ActualizarCuentaSeleccionada([FromBody] CuentaBanco value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var cuentas = await context.DemoMiniabastos_CuentasBanco.ToListAsync();

                cuentas.ForEach(x => x.CuentaBancoSeleccionada = false);
                cuentas.FirstOrDefault(x => x.Id == value.Id).CuentaBancoSeleccionada = true;

                await context.SaveChangesAsync();

                respuesta.Datos = value.Id;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al guardar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }
        #endregion


        #region Ubicaciones
        [HttpGet("GetUbicacion")]
        public async Task<Respuesta<Ubicacion>> GetUbicacion()
        {
            var respuesta = new Respuesta<Ubicacion>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var ubicacion = await context.DemoMiniabastos_Ubicaciones.AsNoTracking().FirstOrDefaultAsync(x => x.UbicacionSeleccionada == true);

                respuesta.Datos = ubicacion;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al consultar los productos {ex.InnerException.Message}";
            }

            return respuesta;
        }

        [HttpGet("GetUbicaciones")]
        public async Task<Respuesta<List<Ubicacion>>> GetUbicaciones()
        {
            var respuesta = new Respuesta<List<Ubicacion>>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var ubicacion = await context.DemoMiniabastos_Ubicaciones.AsNoTracking().ToListAsync();

                respuesta.Datos = ubicacion;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al consultar los productos {ex.InnerException.Message}";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> GuardarUbicacion([FromBody] Ubicacion value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                value.Id = 0;
                context.DemoMiniabastos_Ubicaciones.Add(value);
                await context.SaveChangesAsync();

                respuesta.Datos = value.Id;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al guardar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> ActualizarUbicacionSeleccionada([FromBody] Ubicacion value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var ubicaciones = await context.DemoMiniabastos_Ubicaciones.ToListAsync();

                ubicaciones.ForEach(x => x.UbicacionSeleccionada = false);
                ubicaciones.FirstOrDefault(x => x.Id == value.Id).UbicacionSeleccionada = true;

                await context.SaveChangesAsync();

                respuesta.Datos = value.Id;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al guardar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }
        #endregion



        [HttpGet("GetVentas")]
        public async Task<Respuesta<List<Venta_DemoMiniabastos>>> GetVentas()
        {
            var respuesta = new Respuesta<List<Venta_DemoMiniabastos>>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Operacion exitosa"
            };

            try
            {
                var productos = await context.DemoMiniabastos_Ventas.AsNoTracking().ToListAsync();

                respuesta.Datos = productos;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al consultar los productos {ex.InnerException.Message}";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("{action}")]
        public async Task<Respuesta<long>> GuardarVenta([FromBody] List<Venta_DemoMiniabastos> value)
        {
            var respuesta = new Respuesta<long>
            {
                Estado = EstadosDeRespuesta.Correcto,
                Mensaje = "Venta Guardada Correctamente"
            };

            try
            {
                context.AddRange(value);

                await context.SaveChangesAsync();

                respuesta.Datos = 1;
            }
            catch (Exception ex)
            {
                respuesta.Estado = EstadosDeRespuesta.Error;
                respuesta.Mensaje = $"Error al guardar el producto: {ex.InnerException.ToString()}";
            }
            return respuesta;
        }
    }
}
