using Database.Interfaces;
using Negocio.Entidades;

namespace Negocio.Servicos;

public class ClienteServico 
{
    private IRepositorio<Cliente> _repositorio;
    public ClienteServico(IRepositorio<Cliente> repositorio)
    {
        _repositorio = repositorio;
    }

    public void Salvar(Cliente cliente)
    {
        _repositorio.Salvar(cliente);
    }

    public List<Cliente> BuscaPorIdOuEmail(string idOuEmail)
    {
        return _repositorio.BuscaPorIdOuEmail(idOuEmail);
    }

    public List<Cliente> Todos()
    {
        return _repositorio.Todos();
    }

    public void ApagaPorId(int id)
    {
       _repositorio.ApagaPorId(id);
    }

    public Cliente? BuscaPorId(int id)
    {
        return _repositorio.BuscaPorId(id);
    }
}