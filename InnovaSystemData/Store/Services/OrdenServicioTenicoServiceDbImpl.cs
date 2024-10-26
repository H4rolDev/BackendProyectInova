using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class OrdenServicioTecnicoServiceDbImpl : IOrdenServicioTecnicoService
    {
        private readonly InnovaDbContext _db;
        public OrdenServicioTecnicoServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public OrdenServicioTecnico Create(OrdenServicioTecnico entity)
        {
            OrdenServicioTecnicoTable ordenesserviciostecnicosTable = entity.ToTable();
            _db.ordenServicioTecnicos.Add(ordenesserviciostecnicosTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = ordenesserviciostecnicosTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar la Orden del Servicio Tecnico");
            }
        }
        public void Delete(int id)
        {
            OrdenServicioTecnicoTable? ordenServicioTecnicoTable = _db.ordenServicioTecnicos.FirstOrDefault(r => r.id == id && r.estado);
            if (ordenServicioTecnicoTable == null) throw new MessageExeption("No se encontro la Orden del Servicio Tecnico");
            //_db.ordenserviciotecnicoes.Remove(ordenserviciotecnicoTable);
            ordenServicioTecnicoTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Orden del Servicio Tecnico");
        }
        public List<OrdenServicioTecnico> GetAll()
        {
            List<OrdenServicioTecnico> ordenServicioTecnicos = _db.ordenServicioTecnicos
                .Where(r => r.estado)
                .Select<OrdenServicioTecnicoTable, OrdenServicioTecnico>(
                    rt => rt.ToModel()
                ).ToList();
            return ordenServicioTecnicos;
        }

        public OrdenServicioTecnico? GetById(int id)
        {
            OrdenServicioTecnicoTable? ordenserviciotecnico = _db.ordenServicioTecnicos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (ordenserviciotecnico == null) return null;
            return ordenserviciotecnico.ToModel();
        }

        public void Update(int id, OrdenServicioTecnico body)
        {
            OrdenServicioTecnicoTable? ordenserviciotecnico = _db.ordenServicioTecnicos
                .FirstOrDefault(r => r.id == id && r.estado);
            if (ordenserviciotecnico == null) throw new MessageExeption("No se encontro la Orden del Servicio Tecnico");
            ordenserviciotecnico.id_cliente = body.ClienteId;
            ordenserviciotecnico.id_Trabajador = body.TrabajadorId;
            ordenserviciotecnico.fechaInicio = body.FechaInicio;
            ordenserviciotecnico.fechaFin = body.FechFin;
            ordenserviciotecnico.horaInicio = body.HoraInicio;
            ordenserviciotecnico.horaFin = body.HoraFin;
            ordenserviciotecnico.descripcionServicio = body.DescripcionServicio;
            ordenserviciotecnico.precioUnitario = body.PrecioUnitario;
            ordenserviciotecnico.total = body.Total;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar la Orden del Servicio Tecnico");
        }
    }
}