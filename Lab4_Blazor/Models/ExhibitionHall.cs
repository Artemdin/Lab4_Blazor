using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_Blazor.Models
{
    public class ExhibitionHall
    {
        private string _hallName;
        private List<Exhibit> _exhibits = new List<Exhibit>(); // Список експонатів 

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

        public List<Exhibit> Exhibits => _exhibits;

        // Функція для додавання експонату 
        public void AddExhibit(Exhibit exhibit)
        {
            if (exhibit == null) throw new ArgumentNullException(nameof(exhibit));
            _exhibits.Add(exhibit);
        }

        // Скорочена інформація / назва залу та часовий проміжок 
        public string ToShortString()
        {
            if (_exhibits.Count == 0)
                return $"Зал: {_hallName}. Експонати відсутні.";

            // Знаходимо мінімальний та максимальний рік серед усіх експонатів
            int minYear = _exhibits.Min(e => e.Artwork.CreationYear);
            int maxYear = _exhibits.Max(e => e.Artwork.CreationYear);

            return $"Зал: {_hallName}. Експонати створені в період: {minYear} – {maxYear} рр.";
        }
    }
}