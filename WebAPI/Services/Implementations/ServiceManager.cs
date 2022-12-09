using AutoMapper;
using WebAPI.Repository;
using WebAPI.Models;
using WebAPI.Services.Interfaces;
using WebAPI.Services.Implementations;

namespace WebAPI.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IGenericRepository<Appointment> _appointmentRepository;

        private readonly IMapper _mapper;

        public ServiceManager(
            IMapper mapper,
            IGenericRepository<Patient> patientRepository,
            IGenericRepository<Appointment> appointmentRepository)
        {
            _mapper = mapper;

            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IGenericService<Patient> PatientService => new GenericService<Patient>(_patientRepository, _mapper);
        public IAppointmentService AppointmentService => new AppointmentService(_patientRepository, _appointmentRepository, _mapper);
    }
}
