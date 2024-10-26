using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemBussines.Store.Models;

namespace InnovaSystemData.Store.Extentions
{
  public static class VentaExtentions {
    public static Venta ToModel(this VentaTable rt) {
      return new Venta {
        Id = rt.id,
        ClienteId = rt.id_cliente,
        TrabajadorId = rt.id_trabajador,
        DeliveryId = rt.id_delivery,
        TipoPagoId = rt.id_tipoPago,
        RecojoAlmacenId = rt.id_recojoAlmacen,
        FechaCompra = rt.fechaCompra,
        TotalVenta = rt.totalVenta,
      };
    }

    public static VentaTable ToTable(this Venta r) {
      return new VentaTable {
        id = r.Id,
        id_cliente = r.ClienteId,
        id_trabajador = r.TrabajadorId,
        id_delivery = r.DeliveryId,
        id_tipoPago = r.TipoPagoId,
        id_recojoAlmacen = r.RecojoAlmacenId,
        fechaCompra = r.FechaCompra,
        totalVenta = r.TotalVenta,
        estado = true
      };
    }
  }
}