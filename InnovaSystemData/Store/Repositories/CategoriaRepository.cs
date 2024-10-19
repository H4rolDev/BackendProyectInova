using InnovaSystemBussines.Store.Repositories;
using InnovaSystemBussines.Store.Services;

namespace InnovaSystemData.Store.Repositories {
    public class CategoriaRepositoryImpl : ICategoriaRepository
    {
        private readonly ICategoriaService _categoria;
        public CategoriaRepositoryImpl(
           ICategoriaService categoria
        )
        {
            _categoria = categoria;
        }
        public ICategoriaService categoria()
        {   
            return _categoria;
        }
    }
}