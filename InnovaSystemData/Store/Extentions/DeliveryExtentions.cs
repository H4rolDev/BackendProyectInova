using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class DeliveryExtentions {
    public static Delivery ToModel(this DeliveryTable rt) {
      return new Delivery {
        Id = rt.id,
        DireccionId = rt.id_direccion,
        DNI = rt.DNI,
        Nombre = rt.Nombre,
        ApellidoPaterno = rt.Apellidos,
        Email = rt.Correo,
        Telefono = rt.Telefono
      };
    }

    public static DeliveryTable ToTable(this Delivery r) {
      return new DeliveryTable {
        id = r.Id,
        id_direccion = r.DireccionId,
        DNI = r.DNI,
        Nombre = r.Nombre,
        Apellidos = r.ApellidoPaterno,
        Correo = r.Email,
        Telefono = r.Telefono,
        estado = true
      };
    }
  }
}