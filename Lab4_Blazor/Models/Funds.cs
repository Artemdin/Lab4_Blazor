namespace Lab4_Blazor.Models
{
    public class Funds
    {
        private string _title; 
        private string _address;

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва фонду не може бути порожньою");
                _title = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Адреса не може бути порожньою");
                _address = value;
            }
        }
    }
}