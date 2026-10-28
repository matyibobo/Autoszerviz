using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Autoszerviz.Models;
using Autoszerviz.Data;

namespace Autoszerviz.Pages.JavitasPages;

public class IndexModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public IndexModel(AutoszervizDbContext context)
    {
        _context = context;
    }

    public IList<Javitas> Javitas { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Allapot { get; set; }

    public IReadOnlyList<string> Allapotok { get; } =
        new[] { "Felvéve", "Folyamatban", "Kész" };

    public async Task OnGetAsync()
    {
        var query = _context.Javitasok
            .Include(j => j.Ugyfel)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(Allapot))
        {
            query = query.Where(j => j.Allapot == Allapot);
        }

        Javitas = await query
            .OrderByDescending(j => j.FelvetelDatuma)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostAllapotLepesAsync(int id, string? allapot)
    {
        var javitas = await _context.Javitasok.FindAsync(id);
        if (javitas is null)
        {
            return NotFound();
        }

        var kovetkezoAllapot = javitas.Allapot switch
        {
            "Felvéve" => "Folyamatban",
            "Folyamatban" when javitas.Koltseg > 0 => "Kész",
            "Folyamatban" => null,
            _ => null
        };

        if (kovetkezoAllapot is null)
        {
            if (javitas.Allapot == "Folyamatban")
            {
                TempData["Hiba"] = "A javítás csak nullánál nagyobb költséggel állítható kész állapotba.";
            }
            else if (javitas.Allapot == "Kész")
            {
                TempData["Hiba"] = "A javítás már kész állapotban van.";
            }

            return RedirectToPage(new { allapot });
        }

        javitas.Allapot = kovetkezoAllapot;
        await _context.SaveChangesAsync();

        return RedirectToPage(new { allapot });
    }
}
