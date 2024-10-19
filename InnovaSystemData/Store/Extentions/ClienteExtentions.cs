using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class ClienteExtentions {
    public static Cliente ToModel(this ClienteTable rt) {
      return new Cliente {
        Id = rt.id,
        RazonSocial = rt.RSocial,
        Documento = rt.documento,
        Nombres = rt.Nombres,
        Apellidos = rt.Apellidos,
        Telefono = rt.telefono,
        Correo = rt.correo,
        Direccion = rt.direccion
      };
    }

    public static ClienteTable ToTable(this Cliente r) {
      return new ClienteTable {
        id = r.Id,
        RSocial = r.RazonSocial,
        documento = r.Documento,
        Nombres = r.Nombres,
        Apellidos = r.Apellidos,
        telefono = r.Telefono,
        correo = r.Correo,
        direccion = r.Direccion,
        estado = true
      };
    }
  }
}