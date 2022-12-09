namespace WebAPI.Models
{
    public class Patient : IBaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; } = DateTime.Today;
        public string Diagnos { get; set; } = string.Empty;
    }
}
