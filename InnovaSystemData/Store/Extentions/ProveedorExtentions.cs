using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class ProveedorExtentions {
    public static Proveedor ToModel(this ProveedorTable rt) {
      return new Proveedor {
        Id = rt.id,
        PersonaContacto = rt.nombreContacto,
        RazonSocial = rt.RSocial,
        RUC = rt.RUC,
        Telefono = rt.telefono,
        CorreoElectronico = rt.correo,
        Direccion = rt.direccion
      };
    }

    public static ProveedorTable ToTable(this Proveedor r) {
      return new ProveedorTable {
        id = r.Id,
        nombreContacto = r.PersonaContacto,
        RSocial = r.RazonSocial,
        RUC = r.RUC,
        telefono = r.Telefono,
        correo = r.CorreoElectronico,
        direccion = r.Direccion,
        estado = true
      };
    }
  }
}