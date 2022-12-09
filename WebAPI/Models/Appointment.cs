namespace WebAPI.Models
{
    public class Appointment : IBaseModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public virtual Patient Patient { get; set; }
    }
}
