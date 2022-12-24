
namespace ConsoleApp.UI;

internal class MesagensUI
{
    public static void Mensagem(string mensagem, int timer = 5000)
    {
        Console.Clear();
        Console.WriteLine(mensagem);
        Thread.Sleep(timer);
        Console.Clear();
    }
}