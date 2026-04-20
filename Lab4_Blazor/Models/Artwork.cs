namespace Lab4_Blazor.Models
{
    public class Artwork
    {
        private string _title;
        private int _creationYear;
        private double _height;
        private double _width;
        private double _depth;

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                 throw new ArgumentException("Назва не може бути порожньою"); 
                _title = value;
            }
        }

        public int CreationYear
        {
            get => _creationYear;
            set
            {
                if (value > DateTime.Now.Year)
                    throw new ArgumentException("Рік створення не може бути в майбутньому");
                _creationYear = value;
            }
        }

      public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Висота не може бути меншою за 0");
                _height = value;
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Ширина має бути більшою за нуль");
                _width = value;
            }
        }

        public double Depth
        {
            get => _depth;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Глибина має бути більшою за нуль");
                _depth = value;
            }
        }
    }
}