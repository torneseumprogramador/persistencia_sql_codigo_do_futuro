using Negocio.Entidades;
using Database.Interfaces;

namespace negocio.testes.Repositorios.Mocks;

public class ClienteRepositorioMock : IRepositorio<Cliente>
{
    private static List<Cliente> clientes = new List<Cliente>();

    public void Salvar(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public List<Cliente> BuscaPorIdOuEmail(string idOuEmail)
    {
        return new List<Cliente>();
    }

    public List<Cliente> Todos()
    {
        return new List<Cliente>(){
            new Cliente()
        };
    }

    public void ApagaPorId(int id)
    {
        clientes.RemoveAt(id);
    }

    public Cliente? BuscaPorId(int id)
    {
        return new Cliente();
    }
}