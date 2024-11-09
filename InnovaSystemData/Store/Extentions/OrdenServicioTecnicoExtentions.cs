using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class OrdenServicioTecnicoExtentions {
    public static OrdenServicioTecnico ToModel(this OrdenServicioTecnicoTable rt) {
      return new OrdenServicioTecnico {
        Id = rt.id,
        ClienteId = rt.id_cliente,
        TrabajadorId = rt.id_Trabajador,
        FechaInicio = rt.fechaInicio,
        FechFin = rt.fechaFin,
        HoraInicio = rt.horaInicio,
        HoraFin = rt.horaFin,
        DescripcionServicio = rt.descripcionServicio,
        PrecioUnitario = rt.precioUnitario,
        Total = rt.total,
        Estado = true
      };
    }

    public static OrdenServicioTecnicoTable ToTable(this OrdenServicioTecnico r) {
      return new OrdenServicioTecnicoTable {
        id = r.Id,
        id_cliente = r.ClienteId,
        id_Trabajador = r.TrabajadorId,
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