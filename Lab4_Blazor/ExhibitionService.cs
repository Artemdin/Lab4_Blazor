using Blazored.LocalStorage;
using Lab4_Blazor.Models;

namespace Lab4_Blazor.Services
{
    public class ExhibitionService
    {
        private readonly ILocalStorageService _localStorage;
        private List<Exhibit> _exhibits = new();
        public ExhibitionHall Hall { get; set; } = new ExhibitionHall { HallName = "Головний зал" };

        public ExhibitionService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadDataAsync()
        {
            // Просто читаємо. Якщо пусто — поверне null, і ми залишимо пустий список.
            var saved = await _localStorage.GetItemAsync<List<Exhibit>>("museum_data");
            if (saved != null)
            {
                _exhibits = saved;
            }
        }

        public List<Exhibit> GetExhibits() => _exhibits;

        public async Task SaveExhibit(Exhibit exhibit)
        {
            _exhibits.Add(exhibit);
            await _localStorage.SetItemAsync("museum_data", _exhibits);
        }

        public async Task UpdateExhibit(Exhibit exhibit)
        {
            var index = _exhibits.FindIndex(e => e.Id == exhibit.Id);
            if (index != -1)
            {
                _exhibits[index] = exhibit;
                await _localStorage.SetItemAsync("museum_data", _exhibits);
            }
        }
    }
}