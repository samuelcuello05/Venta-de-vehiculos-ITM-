using VentaVehiculosITM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace VentaVehiculosITM.Clases
{
	public class clsVehiculo
	{
		private VentaVehiculosITMEntities dbVentaVehiculos = new VentaVehiculosITMEntities();

		public Vehiculo vehiculo { get; set; }

		public string Insertar()
		{
            try
            {
                dbVentaVehiculos.Vehiculoes.Add(vehiculo);
                dbVentaVehiculos.SaveChanges();
                return $"El vehiculo con ID {vehiculo.Id} ha sido insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el vehiculo: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Vehiculo Vehiculo = Consultar(vehiculo.Id);
            if (Vehiculo == null)
            {
                return "El ID del vehiculo no es valido";
            }
            dbVentaVehiculos.Vehiculoes.AddOrUpdate(vehiculo);
            dbVentaVehiculos.SaveChanges();
            return $"El vehiculo con ID {vehiculo.Id} ha sido actualizado correctamente";
        }

        public Vehiculo Consultar(int id)
        {
            Vehiculo vehiculo = dbVentaVehiculos.Vehiculoes.FirstOrDefault(e => e.Id == id);
            return vehiculo;
        }

        public List<Vehiculo> ConsultarTodos()
        {
            return dbVentaVehiculos.Vehiculoes.OrderBy(e => e.Id).ToList();
        }

        public string Eliminar(int id)
        {
            try
            {
                Vehiculo Vehiculo = Consultar(id);
                if (Vehiculo == null)
                {
                    return "El ID del vehiculo no es valido";
                }

                dbVentaVehiculos.Vehiculoes.Remove(Vehiculo);
                dbVentaVehiculos.SaveChanges();
                return $"El vehiculo con ID {Vehiculo.Id} ha sido eliminado correctamente";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el vehiculo: {ex.Message}";
            }
        }
        public List<Vehiculo> ConsultarXTipoCombustible(string tipoCombustible)
        {
            return dbVentaVehiculos.Vehiculoes.Where(e => e.TipoCombustible == tipoCombustible).OrderBy(e=>e.Id).ToList();
        }

        public List<Vehiculo> ConsultarXNumeroDePuertas(short numeroPuertas)
        {
            return dbVentaVehiculos.Vehiculoes.Where(e => e.NumeroPuertas == numeroPuertas).OrderBy(e => e.Id).ToList();
        }
    }
}