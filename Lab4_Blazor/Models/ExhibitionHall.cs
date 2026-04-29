using Lab4_Blazor.Models;

public class ExhibitionHall
{
    private string _hallName = "Новий зал";

    public List<Exhibit> Exhibits { get; set; } = new List<Exhibit>();

    public string HallName
    {
        get => _hallName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва залу не може бути порожньою");
            _hallName = value;
        }
    }

    public void AddExhibit(Exhibit exhibit)
    {
        if (exhibit == null) throw new ArgumentNullException(nameof(exhibit));
        Exhibits.Add(exhibit);
    }

    // Скорочена інформація
    public string ToShortString()
    {
        if (Exhibits == null || Exhibits.Count == 0)
            return $"Зал: {HallName}. Експонати відсутні.";

        int minYear = Exhibits.Min(e => e.Artwork.CreationYear);
        int maxYear = Exhibits.Max(e => e.Artwork.CreationYear);

        return $"Зал: {HallName}. Експонати створені в період: {minYear} – {maxYear} рр.";
    }
}