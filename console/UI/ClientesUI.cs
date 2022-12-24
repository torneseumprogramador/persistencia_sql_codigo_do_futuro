using Database.Repositorios;
using Negocio.Entidades;
using Negocio.Servicos;

namespace ConsoleApp.UI;

internal class ClientesUI
{
    private static ClienteServico clienteServico = new ClienteServico(new Repositorio<Cliente>());
    public static void Cadastrar()
    {
        var cliente = new Cliente();
        Console.WriteLine("========= [Cadastro de clientes] ==========");
        
        Console.WriteLine("Nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Email:");
        cliente.Email = Console.ReadLine();

        clienteServico.Salvar(cliente);

        MesagensUI.Mensagem("Cliente cadastrado com sucesso !!!");
    }

    internal static void Atualizar()
    {

        Console.WriteLine("========= [Atualização de clientes] ==========");
        Console.WriteLine("Digite o Id ou o email do cliente");
        var idOuEmail = Console.ReadLine();

        if(string.IsNullOrEmpty(idOuEmail))
        {
            MesagensUI.Mensagem("Digite o Id ou o Email");
            ClientesUI.Atualizar();
            return;
        }

        var clientes = clienteServico.BuscaPorIdOuEmail(idOuEmail);
        if(clientes.Count == 0)
        {
            MesagensUI.Mensagem("Cliente não localizado");
            ClientesUI.Atualizar();
            return;
        }

        Console.WriteLine("Digite o Id do cliente abaixo para atualizar");
        foreach(var clienteDb in clientes)
        {
            Console.WriteLine("Id: "+ clienteDb.Id);
            Console.WriteLine("Nome: "+ clienteDb.Nome);
            Console.WriteLine("Email: "+ clienteDb.Email);
            Console.WriteLine("-----------------------");
        }

        var cliente = new Cliente();
        cliente.Id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Novo Nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Novo Email:");
        cliente.Email = Console.ReadLine();

        clienteServico.Salvar(cliente);

        Console.Clear();
        Console.WriteLine("Cliente atualizado com sucesso !!!");
        Thread.Sleep(5000);
        Console.Clear();
    }

    internal static void Listar()
    {
        Console.WriteLine("====== Lista de clientes ========");
        var clientes = clienteServico.Todos();
        foreach(var clienteDb in clientes)
        {
            Console.WriteLine("Id: "+ clienteDb.Id);
            Console.WriteLine("Nome: "+ clienteDb.Nome);
            Console.WriteLine("Email: "+ clienteDb.Email);
            Console.WriteLine("-----------------------");
        }
    }
}