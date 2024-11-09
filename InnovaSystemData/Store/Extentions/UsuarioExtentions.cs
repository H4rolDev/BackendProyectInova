using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class UsuarioExtentions {
    public static Usuario ToModel(this UsuarioTable rt) {
      return new Usuario {
        Id = rt.id,
        PersonaId = rt.id_Persona,
        RolId = rt.id_rol,
        correo = rt.Correo,
        clave = rt.clave,
        salt = rt.salt,
        Estado = true
      };
    }

    public static UsuarioTable ToTable(this Usuario r) {
      return new UsuarioTable {
        id = r.Id,
        id_Persona = r.PersonaId,
        id_rol = r.RolId,
        Correo = r.correo,
        clave = r.clave,
        salt = r.salt,
        estado = true
      };
    }
  }
}