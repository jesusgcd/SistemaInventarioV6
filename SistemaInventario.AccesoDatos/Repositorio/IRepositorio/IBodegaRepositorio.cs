using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AccesoDatos.Repositorio.IRepositorio
{
    public interface IBodegaRepositorio : IRepositorio<Bodega>
    {

        void Actualizar(Bodega bodega);


    }
}
