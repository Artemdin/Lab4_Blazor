using Lab4_Blazor.Models;

namespace Lab4_Blazor.DTOs
{
    public class ExhibitDTO
    {
        public ArtworkDTO Artwork { get; set; } = new ArtworkDTO();
        public FundsDTO Funds { get; set; } = new FundsDTO();
        public Placement Placement { get; set; } = Placement.Wall; //  за замовчуванням
        public decimal Cost { get; set; }
        public string FundAddress { get; set; } = "";
    }
}