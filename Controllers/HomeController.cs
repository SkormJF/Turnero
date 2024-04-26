using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp.Models;
using Data;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> Categorias()
    {
        return View(await _context.Categorias.ToListAsync());
    }


    //David 
    public IActionResult Turno()
    {
        return View();
    }

    //Daniel
    public IActionResult Turnos()
    {
        return View();
    }
     public IActionResult Pausar()
    {
        return View();
    }

}
