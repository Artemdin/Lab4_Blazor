namespace Lab4_Blazor.Models
{
    public class Exhibit
    {
        public int Id { get; set; }
        private Artwork _artwork;
        private Funds _funds;
        private Placement _placement;
        private decimal _cost;

        public Artwork Artwork
        {
            get => _artwork;
            set => _artwork = value ?? throw new ArgumentNullException(nameof(value), "Произведение искусства не может быть null");
        }

        public Funds Funds
        {
            get => _funds;
            set => _funds = value ?? throw new ArgumentNullException(nameof(value), "Фонд не может быть null");
        }

        public Placement Placement
        {
            get => _placement;
            set => _placement = value; 
        }

        public decimal Cost
        {
            get => _cost;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Вартість не може бути від'ємною");
                _cost = value;
            }
        }

        public Exhibit(Artwork artwork, Funds funds, Placement placement, decimal cost)
        {
            Artwork = artwork;
            Funds = funds;
            Placement = placement;
            Cost = cost;
        }

        public Exhibit() { }
    }
}