using Database.Interfaces;
using System.Linq;

namespace DatabaseMongoDb.Repositorios;

public class Repositorio<T> : IRepositorio<T>
{
    private  readonly string? conexao = Environment.GetEnvironmentVariable("DATABASE_URL");

    public void Salvar(T obj)
    {
        Console.WriteLine("Fiz o salvar do mongo");
    }

    public List<T> BuscaPorIdOuEmail(string idOuEmail)
    {
        var clientes = new List<T>();
        return clientes;
    }

    public List<T> Todos()
    {
        return  new List<T>();
    }

    public void ApagaPorId(int id)
    {
        Console.WriteLine("Fiz o salvar do mongo");
    }

    public T? BuscaPorId(int id)
    {
        var obj = Activator.CreateInstance<T>();
        return obj;
    }
}