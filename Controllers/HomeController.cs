using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;

namespace CSharp.Controllers;

public class HomeController : Controller
{

//variable de conexion
    private readonly TurneroContext _context;
//inicializar conexion
    public HomeController(TurneroContext context){
        _context = context;
    }


    //Angelica
    public IActionResult Index()
    {
        return View();
    }

    //Laura
    public async Task<IActionResult> Categorias(string tipo, string documento)
    {
        var info=tipo + "-" + documento;
        /* ViewData["informacion"]=info; */
        Response.Cookies.Append("info",info);
        ViewData["informacion"]=info;
        return View(await _context.Categorias.ToListAsync());
    }


    //David 
    public async Task<IActionResult> Turno(string siglas)
    {
        string seleccion = "";
        string turno = "";
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Siglas == siglas);
        int contador = result.Contador +1;

        turno = siglas+"-"+(contador < 10 ? "00"+contador: "0"+contador);

        ViewBag.Turno = turno;
        var a = HttpContext.Request.Cookies["info"];
        ViewData["informacion"]=a;
        return View();
    }

    //Daniel
    public IActionResult Turnos()
    {
        return View();
    }

}
