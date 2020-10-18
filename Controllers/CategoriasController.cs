using Microsoft.AspNetCore.Mvc;
using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermercado.API.Controllers
{
    //especificando um espaço reservado que indica que a rota deve usar o nome da classe sem o sufixo do controlador, por convenção.
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        //O atributo HttpGet diz ao pipeline do ASP.NET Core para usá-lo para lidar com solicitações GET
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            var categorias = await _categoriaService.ListAsync();
            return categorias;
        }
    }
}
