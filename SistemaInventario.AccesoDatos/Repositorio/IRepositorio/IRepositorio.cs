using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioV6.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> Obtener(int id);

        Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> filro=null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirProedades = null,
            bool isTracking = true
            );

        Task<T> ObtenerPrimero(
            Expression<Func<T, bool>> filro = null,
            string incluirProedades = null,
            bool isTracking = true
            );

        Task Agregar(T endidad);

        void Remover(T endidad);

        void RemoverRango(IEnumerable<T> endidad);
    }
}
