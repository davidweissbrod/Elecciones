using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EjemploLogin.Models;

namespace Elecciones2023.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.listaPartidos = BD.ListarPartidos();
        return View("Index");
    }

    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.detallesPartido = BD.VerInfoPartido(idPartido);
        return View("VerDetallePartido");
    }

    public IActionResult AgregarCandidato(int idCandidato)
    {
        ViewBag.idCandidato = idCandidato;
        return View("formularioCandidatos");
    }

    public IActionResult VerDetalleCandidato(int idCandidato)
    {
        ViewBag.detallesCandidato = BD.ListarCandidatos(idCandidato);
        return View("VerDetallePartido");
    }

    [HttpPost]
    public IActionResult GuardarCandidato(Candidato can)
    {
        BD.AgregarCandidato(can);
        return RedirectToAction("VerDetallePartido", new { idPartido = can.IdPartido });
    }

    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        return RedirectToAction("VerDetallePartido", new { idPartido });
    }

    public IActionResult Elecciones(int idCandidato, int idPartido)
    {
        ViewBag.explicacionElecciones = "Las PASO este año son el 13 de agosto, mientras que las eleciones generales para presidente son el 22 de Octubre";
        return View("Elecciones");
    }

    public IActionResult Creditos(int idCandidato, int idPartido)
    {
        ViewBag.txtIan = "Ian Roitman";
        ViewBag.txtDavid = "David Weissbrod";
        return View("Creditos");
    }

}
