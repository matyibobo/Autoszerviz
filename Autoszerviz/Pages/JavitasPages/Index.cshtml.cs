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

    public async Task OnGetAsync()
    {
        Javitas = await _context.Javitasok.Include(j => j.Ugyfel).ToListAsync();
    }
}
