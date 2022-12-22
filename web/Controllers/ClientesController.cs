using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Negocio.Models;

namespace web.Controllers;

public class ClientesController : Controller
{
    public IActionResult Index()
    {
        ViewBag.clientes = Cliente.Todos();
        return View();
    }

    public IActionResult Novo()
    {
        return View();
    }

    public IActionResult Cadastrar([FromForm] Cliente cliente)
    {
        if(string.IsNullOrEmpty(cliente.Nome))
        {
            ViewBag.erro = "O nome não pode ser vazio";
            return View();
        }

        cliente.Salvar();

        return Redirect("/clientes");
    }

    [Route("/clientes/{id}/deletar")]
    public IActionResult Apagar([FromRoute] int id)
    {
        Cliente.ApagaPorId(id);
        return Redirect("/clientes");
    }
}
