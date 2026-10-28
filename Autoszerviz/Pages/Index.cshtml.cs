using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Autoszerviz.Models;
using Autoszerviz.Data;

namespace Autoszerviz.Pages.UgyfelPages;

public class IndexModel : PageModel
{
    private readonly AutoszervizDbContext _context;

    public IndexModel(AutoszervizDbContext context)
    {
        _context = context;
    }

    public IList<Ugyfel> Ugyfel { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Ugyfel = await _context.Ugyfelek.ToListAsync();
    }
}
