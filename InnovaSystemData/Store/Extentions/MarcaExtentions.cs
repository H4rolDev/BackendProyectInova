using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class MarcaExtentions {
    public static Marca ToModel(this MarcaTable rt) {
      return new Marca {
        Id = rt.id,
        Nombre = rt.nombre,
        Descripcion = rt.descripcion,
      };
    }

    public static MarcaTable ToTable(this Marca r) {
      return new MarcaTable {
        id = r.Id,
        nombre = r.Nombre,
        descripcion = r.Descripcion,
        estado = true
      };
    }
  }
}