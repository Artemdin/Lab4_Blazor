using Lab4_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4_Blazor
{
    public class ExhibitionService
    {
        private readonly AppDbContext _context;
        public ExhibitionHall Hall { get; private set; } = new ExhibitionHall { HallName = "Головний зал" };
        public ExhibitionService(AppDbContext context)
        {
            _context = context;
            // Створюємо базу, якщо її ще немає
            _context.Database.EnsureCreated();
        }

        public List<Exhibit> GetExhibits()
        {
            return _context.Exhibits
                .Include(e => e.Artwork)
                .Include(e => e.Funds)
                .ToList();
        }
        public void UpdateExhibit(Exhibit exhibit)
        {
            _context.Exhibits.Update(exhibit);
            _context.SaveChanges();
        }
        public void SaveExhibit(Exhibit exhibit)
        {
            _context.Exhibits.Add(exhibit);
            _context.SaveChanges();
        }
    }
}