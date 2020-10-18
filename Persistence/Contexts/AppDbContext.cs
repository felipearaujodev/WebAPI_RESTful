using Microsoft.EntityFrameworkCore;
using Supermercado.API.Domain.Models;

namespace Supermercado.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
//O construtor que adicionamos a essa classe é responsável por passar a configuração do banco de dados para a classe base através da injeção de dependência.Você verá em breve como isso funciona.

//Agora, temos que criar duas propriedades DbSet.Essas propriedades são conjuntos (coleções de objetos exclusivos) que mapeiam modelos para tabelas de banco de dados.

//Além disso, temos que mapear as propriedades dos modelos para as respectivas colunas da tabela, especificando quais propriedades são chaves primárias, que são chaves estrangeiras, os tipos de coluna, etc.

//Podemos fazer isso sobrescrevendo o método OnModelCreating na classe ModelBuilder, usando um recurso chamado Fluent API para especifique o mapeamento do banco de dados.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Categoria>().HasKey(c=>c.Id);
            builder.Entity<Categoria>().Property(c=>c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(c=>c.Nome).IsRequired().HasMaxLength(30);
            builder.Entity<Categoria>().HasMany(p => p.Produtos).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);

            builder.Entity<Categoria>().HasData(
                //Id definido manualmente por que vamos usar o provedor em memória
                new Categoria { Id = 100, Nome = "Frutas e Vegetais"},
                new Categoria { Id = 101, Nome = "Laticínios"}
            );


            builder.Entity<Produto>().ToTable("Produtos");
            builder.Entity<Produto>().HasKey(c => c.Id);
            builder.Entity<Produto>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Produto>().Property(c => c.Nome).IsRequired().HasMaxLength(50);
            builder.Entity<Produto>().Property(c => c.QuantidadePacote).IsRequired();
            builder.Entity<Produto>().Property(c => c.UnidadeMedida).IsRequired();

        }
    }
}
