using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public interface IGrupoRepository
    {
        void Cadastrar(Grupo grupo);

        ICollection<Grupo> Listar();
    }
}
