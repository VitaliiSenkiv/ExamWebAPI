namespace WebAPI.DTO
{
    public class AppointmentDTO
    {
        public DateTime? Date { get; set; } = DateTime.Now;
        public int PatientId { get; set; }
    }
}
