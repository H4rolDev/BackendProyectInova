using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class DetalleVentaExtentions {
    public static DetalleVenta ToModel(this DetalleVentaTable rt) {
      return new DetalleVenta {
        Id = rt.id,
        ProductoId = rt.id_producto,
        VentaId = rt.id_venta,
        PrecioUnitario = rt.precioUnitario,
        Cantidad = rt.cantidad,
        Impuesto = rt.impuestos,
        Estado = true
      };
    }

    public static DetalleVentaTable ToTable(this DetalleVenta r) {
      return new DetalleVentaTable {
        id = r.Id,
        id_producto = r.ProductoId,
        id_venta = r.VentaId,
        precioUnitario = r.PrecioUnitario,
        cantidad = r.Cantidad,
        impuestos = r.Impuesto,
        estado = true
      };
    }
  }
}