using Supermercado.API.Domain.Models;
using Supermercado.API.Domain.Models.Services;
using Supermercado.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaService;

        public CategoriaService(ICategoriaRepository categoriaRepository) 
        {
            _categoriaService = categoriaRepository;
        }
        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _categoriaService.ListAsync();
        }

    }
}
