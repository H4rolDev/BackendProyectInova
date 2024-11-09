using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class ProductoExtentions {
    public static Producto ToModel(this ProductoTable rt) {
      return new Producto {
        Id = rt.id,
        Nombre = rt.nombre,
        Imagen = rt.imagen,
        categoriaId = rt.id_categoria,
        Descripcion = rt.descripcion,
        Modelo = rt.modelo,
        MarcaId = rt.id_marca,
        Stock = rt.stock,
        PrecioVenta = rt.precioVenta,
        UtilidadPrecioVenta = rt.utilidadPrecioVenta,
        UtilidadPorcentaje = rt.utilidadPorcentaje,
        Garantia = rt.garantia,
        Estado = true
      };
    }

    public static ProductoTable ToTable(this Producto r) {
      return new ProductoTable {
        id = r.Id,
        nombre = r.Nombre,
        imagen = r.Imagen,
        id_categoria = r.categoriaId,
        descripcion = r.Descripcion,
        modelo = r.Modelo,
        id_marca = r.MarcaId,
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