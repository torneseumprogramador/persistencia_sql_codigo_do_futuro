namespace Database.Interfaces;

public interface IRepositorio<T>
{
    void Salvar(T obj);

    List<T> BuscaPorIdOuEmail(string idOuEmail);

    List<T> Todos();

    void ApagaPorId(int id);

    T? BuscaPorId(int id);
}