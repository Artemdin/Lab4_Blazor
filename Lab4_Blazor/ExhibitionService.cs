using Lab4_Blazor.Models;

namespace Lab4_Blazor
{
    public class ExhibitionService
    {
        public ExhibitionHall Hall { get; private set; } = new ExhibitionHall { HallName = "Головний зал" };

        public void SaveExhibit(Exhibit exhibit)
        {
            Hall.AddExhibit(exhibit);
        }
    }
}
