using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class OrdenServicioTecnicoExtentions {
    public static OrdenServicioTecnico ToModel(this OrdenServicioTecnicoTable rt) {
      return new OrdenServicioTecnico {
        Id = rt.id,
        Cliente = rt.cliente,
        Trabajador = rt.trabajador,
        FechaInicio = rt.fechaInicio,
        FechFin = rt.fechaFin,
        HoraInicio = rt.horaInicio,
        HoraFin = rt.horaFin,
        DescripcionServicio = rt.descripcionServicio,
        PrecioUnitario = rt.precioUnitario,
        Total = rt.total,
      };
    }

    public static OrdenServicioTecnicoTable ToTable(this OrdenServicioTecnico r) {
      return new OrdenServicioTecnicoTable {
        id = r.Id,
        cliente = r.Cliente,
        trabajador = r.Trabajador,
        fechaInicio = r.FechaInicio,
        fechaFin = r.FechFin,
        horaInicio = r.HoraInicio,
        horaFin = r.HoraFin,
        descripcionServicio = r.DescripcionServicio,
        precioUnitario = r.PrecioUnitario,
        total = r.Total,
        estado = true
      };
    }
  }
}