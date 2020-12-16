using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using WebApi.Data;
using WebApi.Models;

namespace WebApiTeste
{
    [TestClass]
    public class TesteProduto
    {
        private static ProdutoContext _produtoContext;
        private static ProdutoController _produtoControler;

        public TesteProduto()
        {
            var dbContextOptions = new DbContextOptions<ProdutoContext>();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProdutoContext>(dbContextOptions);
            dbContextOptionsBuilder.UseMySQL(@"Server=localhost;Database=ecommerce;Uid=root;Pwd=ROOT;");

            _produtoContext = new ProdutoContext(dbContextOptionsBuilder.Options);

            _produtoControler = new ProdutoController(_produtoContext);
        }

        [TestMethod]
        public void TesteGetProduto()
        {          

            var ret = _produtoContext.Produto.ToListAsync().Result;

            //Assert
            Assert.IsNotNull(ret);
            Assert.IsTrue(!ret.Count.Equals(0));

        }

        [TestMethod]
        public void TesteGetProdutoId()
        {
            //Busca um produto que existe
            var prod1 =_produtoControler.GetProduto("3d09e318-d99f-43f8-9f60-412cf9d29bbf").Result;
            
            Assert.IsNotNull(prod1);

            //Busca um produto que não existe
            var prod2 = _produtoControler.GetProduto("33333333-3333-3333-3333-333333333333").Result;

            Assert.IsNull(prod2.Value);

        }

        [TestMethod]
        public void TestePutProduto()
        {
            //Busca um produto que existe
            var prod1 = _produtoControler.GetProduto("3d09e318-d99f-43f8-9f60-412cf9d29bbf").Result;
            Assert.IsNotNull(prod1.Value);
            //Altera a descrição
            prod1.Value.Descricao = "Descrição alterada mais uma vez";
            //altera no banco 
            var prod2 = _produtoControler.PutProduto("3d09e318-d99f-43f8-9f60-412cf9d29bbf", prod1.Value).Result;
            Assert.IsNotNull(prod2);

            //Busca um produto que existe
            var prod3 = _produtoControler.GetProduto("3d09e318-d99f-43f8-9f60-412cf9d29bbf").Result;
            Assert.IsNotNull(prod1.Value);
            //Altera a descrição
            prod3.Value.Descricao = "Descrição alterada";
            //tenta alterar mas passando ID de outro produto
            var prod4 = _produtoControler.PutProduto("cb008b0a-0e28-4cbd-b62f-eeb8ba429f51", prod3.Value).Result;
            //bad request e não deixa alterar
            Assert.IsNotNull(prod4);

        }

        [TestMethod]
        public void TestePostProduto()
        {
            var produtoNovo = new Produto
            {
                Id = "7ec6cd13-2eb2-4ae5-a6d4-4f273af1366f",
                Codigo = "7",
                Descricao = "Descrição do codigo 7",
                Preco = 5000,
                Status = true,
                IdDepartamento = "7ec6cd13-2eb2-4ae5-a6d4-4f273af1366f"
            };

            //Insere um produto novo
            var prod1 = _produtoControler.PostProduto(produtoNovo).Result;

            Assert.IsNotNull(prod1.Result);
            
        }

        [TestMethod]
        public void TesteDeleteProduto()
        {                     
            var prod1 = _produtoControler.DeleteProduto("7ec6cd13-2eb2-4ae5-a6d4-4f273af1366f").Result;

            Assert.IsNotNull(prod1);

        }
    }
}
