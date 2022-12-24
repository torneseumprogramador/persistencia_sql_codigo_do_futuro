using MySql.Data.MySqlClient;
using Database.Interfaces;
using System.Linq;
using System.Reflection;
using Database.Atributos;

namespace DatabaseMysql.Repositorios;

public class Repositorio<T> : IRepositorio<T>
{
    // exemplo de implementação driver mysql
    // https://github.com/Didox/Desafio21dias_TDD_ORM_Repository/blob/main/APIDesafio/Servicos/Database/SqlRepositorio.cs


    private  readonly string? conexao = Environment.GetEnvironmentVariable("DATABASE_URL");

    private string NomeDaTabela()
    {
        var nome = typeof(T).Name.ToLower() + "s";

        TabelaAttribute? tabelaAttr = (TabelaAttribute?)typeof(T).GetCustomAttribute(typeof(TabelaAttribute));
        if(tabelaAttr != null)
            nome = tabelaAttr.Nome;

        return nome;
    }

    private string NomeDaPropriedade(PropertyInfo prop)
    {
        var nome = prop.Name.ToLower();

        ColunaAttribute? colunaAttr = (ColunaAttribute?)typeof(T).GetCustomAttribute(typeof(ColunaAttribute));
        if(colunaAttr != null)
            nome = colunaAttr.Nome;

        return nome;
    }

    public void Salvar(T obj)
    {
        Console.WriteLine("======[" + conexao + "]=========");
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            List<string> colunasArray = new List<string>();
            List<string> valoresArray = new List<string>();
            List<string> updateArray = new List<string>();
            foreach(var prop in typeof(T).GetProperties())
            {
                var nome = this.NomeDaPropriedade(prop);
                if(nome == "Id") continue;
                colunasArray.Add(nome);
                valoresArray.Add($"'{prop.GetValue(obj)}'");
                updateArray.Add($"${nome}='{prop.GetValue(obj)}'");
            }
            var colunas = string.Join(", ", colunasArray.ToArray());
            var valores = string.Join(", ", valoresArray.ToArray());
            var update = string.Join(", ", updateArray.ToArray());

            var query = $"insert into {this.NomeDaTabela()} ({colunas})values({valores});";
            var id = Convert.ToInt32(typeof(T).GetProperty("Id")?.GetValue(obj));
            if(id > 0)
                query = $"update {this.NomeDaTabela()} set {update} where id = {id};";

            var command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();

            conn.Close();
        }
    }

    public List<T> BuscaPorIdOuEmail(string idOuEmail)
    {
        var clientes = new List<T>();
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"""
                select * from {this.NomeDaTabela()}
                where id = '{idOuEmail}' or
                      email like '%{idOuEmail}%'
            """;

            var command = new MySqlCommand(query, conn);
            var dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                var obj = Activator.CreateInstance<T>();
                
                foreach(var prop in typeof(T).GetProperties())
                {
                    var valor = dataReader[prop.Name].ToString();
                    obj?.GetType().GetProperty(prop.Name)?.SetValue(obj,valor);
                }
            }

            conn.Close();
        }

        return clientes;
    }

    public List<T> Todos()
    {
        return  new List<T>();
    }

    public void ApagaPorId(int id)
    {
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"delete from {this.NomeDaTabela()} where id = {id};";

            var command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();

            conn.Close();
        }
    }

    public T? BuscaPorId(int id)
    {
        var obj = Activator.CreateInstance<T>();
        return obj;
    }
}