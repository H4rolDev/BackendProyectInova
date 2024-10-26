using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class TrabajadorExtentions {
    public static Trabajador ToModel(this TrabajadorTable rt) {
      return new Trabajador {
        Id = rt.id,
        PersonaId = rt.id_Persona,
        Nombre = rt.nombres,
        ApellidoPaterno = rt.apellidoPaterno,
        ApellidoMaterno = rt.apellidoMaterno,
        FechaInicioContrato = rt.FechaInicioContrato,
        FechaFinContrato = rt.FechaFinContrato,
        Puesto = rt.puesto,
        Salario = rt.salario,
        Telefono = rt.telefono,   
      };
    }

    public static TrabajadorTable ToTable(this Trabajador r) {
      return new TrabajadorTable {
        id = r.Id,
        nombres = r.Nombre,
        apellidoPaterno = r.ApellidoPaterno,
        apellidoMaterno = r.ApellidoMaterno,
        FechaInicioContrato = r.FechaInicioContrato,
        FechaFinContrato = r.FechaFinContrato,
        puesto = r.Puesto,
        salario = r.Salario,
        telefono = r.Telefono, 
        estado = true
      };
    }
  }
}