using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.API.Domain.Models.Services
{
//As implementações do método ListAsync devem retornar de forma assíncrona uma enumeração de categorias.

//A classe Task, encapsulando o retorno, indica assincronia. Precisamos pensar em um método assíncrono devido ao fato de termos que esperar que o banco de dados conclua alguma operação para retornar os dados, e esse processo pode demorar um pouco. Observe também o sufixo “async”. É uma convenção que indica que nosso método deve ser executado de forma assíncrona.

//Usando interfaces podemos abstrair o comportamento desejado da implementação real. Usando um mecanismo conhecido como injeção de dependência, podemos implementar essas interfaces e isolá-las de outros componentes.

//Basicamente, quando você usa a injeção de dependência, você define alguns comportamentos usando uma interface. Em seguida, você cria uma classe que implementa a interface. Finalmente, você vincula as referências da interface à classe criada.

//Vamos fazer isso a seguir na classe CategoriasController onde vamos usar o serviço criado e realizar a injeção de dependência nesta classe:


    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ListAsync();
    }
}
