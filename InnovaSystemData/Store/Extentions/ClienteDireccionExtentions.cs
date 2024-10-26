using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class ClienteDireccionExtentions {
    public static ClienteDireccion ToModel(this ClienteDireccionTable rt) {
      return new ClienteDireccion {
        Id = rt.id,
        Direccion = rt.direccion,
        Referencia = rt.referencia,
        Departamento = rt.departamento,
        Provincia = rt.provincia,
        Distrito = rt.distrito,
      };
    }

    public static ClienteDireccionTable ToTable(this ClienteDireccion r) {
      return new ClienteDireccionTable {
        id = r.Id,
        direccion = r.Direccion,
        referencia = r.Referencia,
        departamento = r.Departamento,
        provincia = r.Provincia,
        distrito = r.Distrito,
        estado = true
      };
    }
  }
}