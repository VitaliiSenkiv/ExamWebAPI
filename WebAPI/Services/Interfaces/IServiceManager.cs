using WebAPI.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public interface IServiceManager
    {
        public IGenericService<Patient> PatientService { get; }
        public IAppointmentService AppointmentService { get; }
    }
}
