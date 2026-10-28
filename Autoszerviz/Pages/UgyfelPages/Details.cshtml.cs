using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Autoszerviz.Models;
using Autoszerviz.Data;

namespace Autoszerviz.Pages.UgyfelPages;

public class DetailsModel : PageModel
{
    private readonly AutoszervizDbContext _context;
    public DetailsModel(AutoszervizDbContext context)
    {
        _context = context;
    }

    public Ugyfel Ugyfel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var ugyfel = await _context.Ugyfelek.Include(j => j.Javitasok).FirstOrDefaultAsync(m => m.Id == id);
        if (ugyfel is null)
        {
            return NotFound();
        }
        else
        {
            Ugyfel = ugyfel;
        }

        return Page();
    }
}
