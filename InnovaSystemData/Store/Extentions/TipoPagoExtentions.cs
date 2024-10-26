using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class TipoPagoExtentions {
    public static TipoPago ToModel(this TipoPagoTable rt) {
      return new TipoPago {
        Id = rt.id,
        Nombre = rt.nombres,
        Descripcion = rt.descripcion,
      };
    }

    public static TipoPagoTable ToTable(this TipoPago r) {
      return new TipoPagoTable {
        id = r.Id,
        nombres = r.Nombre,
        descripcion = r.Descripcion,
        estado = true
      };
    }
  }
}