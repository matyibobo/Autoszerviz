using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autoszerviz.Models;
using Autoszerviz.Data;

namespace Autoszerviz.Pages.JavitasPages;

public class CreateModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public CreateModel(AutoszervizDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Javitas Javitas { get; set; } = new();

    public SelectList UgyfelLista { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        await UgyfelekBetolteseAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Javitas.Ugyfel");
        ModelState.Remove("Javitas.FelvetelDatuma");
        ModelState.Remove("Javitas.Allapot");

        Javitas.FelvetelDatuma = DateTime.Now;
        Javitas.Allapot = "Felvéve";

        if (!ModelState.IsValid)
        {
            await UgyfelekBetolteseAsync();
            return Page();
        }

        _context.Javitasok.Add(Javitas);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private async Task UgyfelekBetolteseAsync()
    {
        UgyfelLista = new SelectList(
            await _context.Ugyfelek
                .OrderBy(u => u.Nev)
                .ToListAsync(),
            "Id",
            "Nev"
        );
    }
}
