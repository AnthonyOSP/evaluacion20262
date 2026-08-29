using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using evaluacion20262.Data;
using evaluacion20262.Models;

namespace evaluacion20262.Controllers;

public class SolicitudesController : Controller
{
    private readonly ApplicationDbContext _context;

    public SolicitudesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Solicitudes
    public async Task<IActionResult> Index()
    {
        // Consulta LINQ contra SQLite: trae todas las solicitudes,
        // ordenadas de la mas reciente a la mas antigua.
        var solicitudes = await _context.SolicitudesServicio
            .OrderByDescending(s => s.FechaRegistro)
            .ToListAsync();

        return View(solicitudes);
    }

    // GET: /Solicitudes/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Solicitudes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SolicitudServicio solicitud)
    {
        if (!ModelState.IsValid)
        {
            // Vuelve a la vista mostrando los errores de validacion.
            return View(solicitud);
        }

        _context.SolicitudesServicio.Add(solicitud);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = "La solicitud fue registrada correctamente.";
        return RedirectToAction(nameof(Create));
    }
}
