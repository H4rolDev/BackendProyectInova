using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class TrabajadorExtentions {
    public static Trabajador ToModel(this TrabajadorTable rt) {
      return new Trabajador {
        Id = rt.Id,
        PersonaId = rt.Id_Persona,
        Nombre = rt.Nombres,
        ApellidoPaterno = rt.ApellidoPaterno,
        ApellidoMaterno = rt.ApellidoMaterno,
        FechaInicioContrato = rt.FechaInicioContrato,
        FechaFinContrato = rt.FechaFinContrato,
        PuestoId = rt.PuestoId,
        Salario = rt.Salario,
        Telefono = rt.Telefono,
        Estado = true   
      };
    }

    public static TrabajadorTable ToTable(this Trabajador r) {
      return new TrabajadorTable {
        Id = r.Id,
        Nombres = r.Nombre,
        ApellidoPaterno = r.ApellidoPaterno,
        ApellidoMaterno = r.ApellidoMaterno,
        FechaInicioContrato = r.FechaInicioContrato,
        FechaFinContrato = r.FechaFinContrato,
        PuestoId = r.PuestoId,
        Salario = r.Salario,
        Telefono = r.Telefono, 
        Estado = true
      };
    }
  }
}