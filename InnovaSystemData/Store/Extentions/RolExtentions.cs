using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class RolExtentions {
    public static Rol ToModel(this RolTable rt) {
      return new Rol {
        Id = rt.id,
        Nombre = rt.nombre,
        Descripcion = rt.descripcion,
      };
    }

    public static RolTable ToTable(this Rol r) {
      return new RolTable {
        id = r.Id,
        nombre = r.Nombre,
        descripcion = r.Descripcion,
        estado = true
      };
    }
  }
}