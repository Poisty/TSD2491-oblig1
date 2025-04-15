using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TSD2491_oblig_1_261660.Controllers;
using MvcBruker.Data;
using TSD2491_oblig_1_261660.Models;


public class SpillController : Controller
{
    private readonly BrukerContext _context;

    public SpillController(BrukerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
public IActionResult RegistrerSpill(string navn)
{
    if (string.IsNullOrWhiteSpace(navn))
    {
        TempData["Feil"] = "Du må skrive inn et navn!";
        return RedirectToAction("Index");
    }

    var bruker = _context.Bruker.FirstOrDefault(b => b.Navn == navn);

    if (bruker != null)
    {
        bruker.AntallSpill += 1;
    }
    else
    {
        // Opprett ny bruker
        bruker = new Bruker
        {
            Navn = navn,
            Kontakt = "ukjent", // Evt. la brukeren skrive inn mer info
            AntallSpill = 1
        };

        _context.Bruker.Add(bruker);
    }

    _context.SaveChanges();

    return RedirectToAction("Index");
}

public IActionResult Rangering()
{
    var brukere = _context.Bruker
        .OrderByDescending(b => b.AntallSpill)
        .ToList();

    return View(brukere);
}



}
