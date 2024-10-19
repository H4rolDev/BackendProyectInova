using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class ProductoaExtentions {
    public static Producto ToModel(this ProductoTable rt) {
      return new Producto {
        Id = rt.id,
        Nombre = rt.nombre,
        Imagen = rt.imagen,
        Categoria = rt.categoria,
        Descripcion = rt.descripcion,
        Modelo = rt.modelo,
        Marca = rt.marca,
        Stock = rt.stock,
        PrecioVenta = rt.precioVenta,
        UtilidadPrecioVenta = rt.utilidadPrecioVenta,
        UtilidadPorcentaje = rt.utilidadPorcentaje,
        Garantia = rt.garantia,
      };
    }

    public static ProductoTable ToTable(this Producto r) {
      return new ProductoTable {
        id = r.Id,
        nombre = r.Nombre,
        imagen = r.Imagen,
        categoria = r.Categoria,
        descripcion = r.Descripcion,
        modelo = r.Modelo,
        marca = r.Marca,
        stock = r.Stock,
        precioVenta = r.PrecioVenta,
        utilidadPrecioVenta = r.UtilidadPrecioVenta,
        utilidadPorcentaje = r.UtilidadPorcentaje,
        garantia = r.Garantia,
        estado = true
      };
    }
  }
}