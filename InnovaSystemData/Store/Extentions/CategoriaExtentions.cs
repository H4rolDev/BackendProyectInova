using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class CategoriaExtentions {
    public static Categoria ToModel(this CategoriaTable rt) {
      return new Categoria {
        Id = rt.id,
        Nombre = rt.nombre,
        Descripcion = rt.descripcion,
        Estado = true
      };
    }

    public static CategoriaTable ToTable(this Categoria r) {
      return new CategoriaTable {
        id = r.Id,
        nombre = r.Nombre,
        descripcion = r.Descripcion,
        estado = true
      };
    }
  }
}