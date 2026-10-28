using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Javitas Javitas { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Javitasok.Add(Javitas);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
