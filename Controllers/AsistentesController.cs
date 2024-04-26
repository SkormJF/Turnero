using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Turnero.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;
using System.Linq;
using Data;

namespace CSharp.Controllers;

public class AsistentesController : Controller
{

    //Angelica
    public readonly TurneroContext _context;

    public AsistentesController(TurneroContext context)
    {
        _context = context;
    }
    
}