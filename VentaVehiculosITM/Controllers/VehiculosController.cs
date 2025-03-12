using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VentaVehiculosITM.Clases;
using VentaVehiculosITM.Models;

namespace VentaVehiculosITM.Controllers
{
    [RoutePrefix("api/Vehiculos")]
    public class VehiculosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Vehiculo> ConsultarTodos()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Vehiculo Consultar(int id)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.vehiculo = vehiculo;
            return Vehiculo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.vehiculo = vehiculo;
            return Vehiculo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Eliminar(id);
        }

        [HttpGet]
        [Route("ConsultarXTipoCombustible")]
        public List<Vehiculo> ConsultarXTipoCombustible(string tipoCombustible)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ConsultarXTipoCombustible(tipoCombustible);
        }

        [HttpGet]
        [Route("ConsultarXNumeroDePuertas")]
        public List<Vehiculo> ConsultarXNumeroDePuertas(short numeroDePuertas)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ConsultarXNumeroDePuertas(numeroDePuertas);
        }
    }
}