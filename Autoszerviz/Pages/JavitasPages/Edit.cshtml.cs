using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autoszerviz.Models;
using Autoszerviz.Data;

namespace Autoszerviz.Pages.JavitasPages;

public class EditModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public EditModel(AutoszervizDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Javitas Javitas { get; set; } = default!;

    public SelectList UgyfelLista { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var javitas = await _context.Javitasok.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        if (javitas is null)
        {
            return NotFound();
        }
        Javitas = javitas;
        await UgyfelekBetolteseAsync();
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Javitas.Ugyfel");
        ModelState.Remove("Javitas.Allapot");
        ModelState.Remove("Javitas.FelvetelDatuma");

        if (!ModelState.IsValid)
        {
            await UgyfelekBetolteseAsync();
            return Page();
        }

        var javitas = await _context.Javitasok.FindAsync(Javitas.Id);
        if (javitas is null)
        {
            return NotFound();
        }

        javitas.UgyfelId = Javitas.UgyfelId;
        javitas.Rendszam = Javitas.Rendszam;
        javitas.Leiras = Javitas.Leiras;
        javitas.Koltseg = Javitas.Koltseg;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JavitasExists(Javitas.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private async Task UgyfelekBetolteseAsync()
    {
        UgyfelLista = new SelectList(
            await _context.Ugyfelek.OrderBy(u => u.Nev).ToListAsync(),
            "Id",
            "Nev",
            Javitas?.UgyfelId);
    }

    private bool JavitasExists(int id)
    {
        return _context.Javitasok.Any(e => e.Id == id);
    }
}
