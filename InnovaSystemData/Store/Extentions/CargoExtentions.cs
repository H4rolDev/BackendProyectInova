using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class CargoExtentions {
    public static Cargo ToModel(this CargoTable rt) {
      return new Cargo {
        Id = rt.id,
        Nombre = rt.nombre,
        Descripcion = rt.descripcion,
        SalarioBase = rt.salarioBase
      };
    }

    public static CargoTable ToTable(this Cargo r) {
      return new CargoTable {
        id = r.Id,
        nombre = r.Nombre,
        descripcion = r.Descripcion,
        salarioBase = r.SalarioBase,
        Estado = true
      };
    }
  }
}