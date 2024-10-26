using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class ClienteExtentions {
    public static Cliente ToModel(this ClienteTable rt) {
      return new Cliente {
        Id = rt.id,
        PersonaId = rt.id_Persona,
        DireccionId = rt.id_Direccion,
        RazonSocial = rt.RSocial,
        Nombres = rt.Nombres,
        Apellidos = rt.Apellidos,
        Telefono = rt.telefono,
        Correo = rt.correo,
        TipoDocumento = rt.TipoDocumento,
        NumeroDocumento = rt.NumeroDocumento
      };
    }

    public static ClienteTable ToTable(this Cliente r) {
      return new ClienteTable {
        id = r.Id,
        id_Persona = r.PersonaId,
        id_Direccion = r.DireccionId,
        RSocial = r.RazonSocial,
        Nombres = r.Nombres,
        Apellidos = r.Apellidos,
        telefono = r.Telefono,
        correo = r.Correo,
        TipoDocumento = r.TipoDocumento,
        NumeroDocumento = r.NumeroDocumento,
        estado = true
      };
    }
  }
}