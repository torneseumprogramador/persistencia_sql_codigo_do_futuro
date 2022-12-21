using ConsoleApp.Models;
using ConsoleApp.UI;

while (true)
{
    Console.WriteLine("""
        1 - Cadastrar cliente
        2 - Atualizar cliente
        3 - Listar clientes
        4 - Sair
    """);

    bool sair = false;
    var opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            ClientesUI.Cadastrar();
            break;
        case "2":
            ClientesUI.Atualizar();
            break;
        case "3":
            ClientesUI.Listar();
            break;
        default:
            sair = true;
            break;
    }

    if(sair) break;
    
}