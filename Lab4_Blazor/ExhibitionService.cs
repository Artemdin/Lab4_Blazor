using Blazored.LocalStorage;
using Lab4_Blazor.Models;

namespace Lab4_Blazor.Services
{
    public class ExhibitionService
    {
        private readonly ILocalStorageService _localStorage;

        // Тепер головний список — це ЗАЛИ
        public List<ExhibitionHall> Halls { get; set; } = new();

        // Поточний вибраний зал
        public ExhibitionHall SelectedHall { get; set; }

        public ExhibitionService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadDataAsync()
        {
            var savedHalls = await _localStorage.GetItemAsync<List<ExhibitionHall>>("museum_data_halls");

            if (savedHalls != null && savedHalls.Any())
            {
                Halls = savedHalls;
            }
            else
            {
                Halls = new List<ExhibitionHall>
        {
            new ExhibitionHall { HallName = "Головний зал" }
        };
                await SaveAll();
            }

            SelectedHall = Halls.First();
        }

        public async Task SaveAll()
        {
            await _localStorage.SetItemAsync("museum_data_halls", Halls);
        }

        public List<Exhibit> GetExhibits() => SelectedHall?.Exhibits ?? new List<Exhibit>();


        public async Task SaveExhibit(Exhibit exhibit)
        {
            SelectedHall?.AddExhibit(exhibit);
            await SaveAll();
        }

        public async Task DeleteExhibit(int id)
        {
            var exhibit = SelectedHall?.Exhibits.FirstOrDefault(e => e.Id == id);
            if (exhibit != null)
            {
                SelectedHall.Exhibits.Remove(exhibit);
                await SaveAll();
            }
        }

        public async Task UpdateExhibit(Exhibit exhibit)
        {
            var index = SelectedHall?.Exhibits.FindIndex(e => e.Id == exhibit.Id) ?? -1;
            if (index != -1)
            {
                SelectedHall.Exhibits[index] = exhibit;
                await SaveAll();
            }
        }
    }
}