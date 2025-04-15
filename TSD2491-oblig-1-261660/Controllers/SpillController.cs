using Microsoft.AspNetCore.Mvc;

public class SpillController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistrerSpill(string navn)
    {
        // Her skal du oppdatere Bruker-modellen (øke antall spill)
        return RedirectToAction("Index");
    }
}
