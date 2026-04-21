using System.Text.Json;
using Lab4_Blazor.Models;
using Microsoft.JSInterop;

namespace Lab4_Blazor
{
    public class ExhibitionService
    {
        private readonly IJSRuntime _js;
        private const string StorageKey = "exhibition_data";

        public ExhibitionHall Hall { get; private set; } = new ExhibitionHall { HallName = "Головний зал" };
        private List<Exhibit> _exhibits = new();

        public ExhibitionService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task LoadDataAsync()
        {
            try
            {
                var json = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);

                if (!string.IsNullOrEmpty(json))
                {
                    // Створюємо опції, ідентичні тим, що при збереженні
                    var options = new JsonSerializerOptions
                    {
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                        PropertyNameCaseInsensitive = true // Щоб не переживати за великі/малі літери
                    };

                    var loaded = JsonSerializer.Deserialize<List<Exhibit>>(json, options);

                    if (loaded != null)
                    {
                        _exhibits = loaded;
                        Console.WriteLine($"Завантажено {_exhibits.Count} експонатів.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завантаження: {ex.Message}");
            }
        }

        public List<Exhibit> GetExhibits() => _exhibits;

        public async Task SaveExhibit(Exhibit exhibit)
        {
            _exhibits.Add(exhibit);
            await SaveToStorage();
        }

        public async Task UpdateExhibit(Exhibit exhibit)
        {
            await SaveToStorage();
        }

        private async Task SaveToStorage()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(_exhibits, options);
                await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критична помилка JSON: {ex.Message}");
            }
        }
    }
}