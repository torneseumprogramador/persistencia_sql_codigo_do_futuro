using negocio.testes.Repositorios.Mocks;
using Negocio.Entidades;

namespace negocio.testes.Repositorios;

[TestClass]
public class ClienteRepositorioTest
{
    [TestMethod]
    public void TestandoSalvarNoBancoDeDados()
    {
        new ClienteRepositorioMock().Salvar(new Cliente{
            Nome = "Jamil",
            Email = "jamil@teste.com"
        });

        var quantidade = new ClienteRepositorioMock().Todos().Count;

        Assert.AreEqual(1, quantidade);
    }
}