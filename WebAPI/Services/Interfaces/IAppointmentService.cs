using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task<int> CreateAppointmentAsync(AppointmentDTO dto);
        Task UpdateAppointmentByIdAsync(int id, AppointmentDTO dto);
    }
}
