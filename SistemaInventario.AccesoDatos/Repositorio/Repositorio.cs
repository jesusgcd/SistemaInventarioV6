using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioV6.AccesoDatos.Data;
using SistemaInventarioV6.AccesoDatos.Repositorio.IRepositorio;

namespace SistemaInventarioV6.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            
        }
        public async Task Agregar(T endidad)
        {
            await dbSet.AddAsync(endidad);
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id);
        }


        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirProedades = null, bool isTracking = true)
        {

            IQueryable<T> query = dbSet;

            if (filro != null) { query = query.Where(filro); }
            if (incluirProedades != null)
            {
                foreach (var incluirProp in incluirProedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking) { query = query.AsNoTracking(); }

            return await query.ToListAsync();
        }


        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filro = null, string incluirProedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;

            if (filro != null) { query = query.Where(filro); }
            if (incluirProedades != null)
            {
                foreach (var incluirProp in incluirProedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            if (!isTracking) { query = query.AsNoTracking(); }

            return await query.FirstOrDefaultAsync();
        }

        
        public void Remover(T endidad)
        {
            dbSet.Remove(endidad);  
        }

        public void RemoverRango(IEnumerable<T> endidad)
        {
            dbSet.RemoveRange(endidad);
        }
    }
}
