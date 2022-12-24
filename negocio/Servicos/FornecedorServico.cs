using Database.Interfaces;
using Negocio.Entidades;

namespace Negocio.Servicos;

public class FornecedorServico 
{
    private IRepositorio<Fornecedor> _repositorio;
    public FornecedorServico(IRepositorio<Fornecedor> repositorio)
    {
        _repositorio = repositorio;
    }

    public void Salvar(Fornecedor fornecedor)
    {
        _repositorio.Salvar(fornecedor);
    }

    public List<Fornecedor> BuscaPorIdOuEmail(string idOuEmail)
    {
        return _repositorio.BuscaPorIdOuEmail(idOuEmail);
    }

    public List<Fornecedor> Todos()
    {
        return _repositorio.Todos();
    }

    public void ApagaPorId(int id)
    {
       _repositorio.ApagaPorId(id);
    }

    public Fornecedor? BuscaPorId(int id)
    {
        return _repositorio.BuscaPorId(id);
    }
}