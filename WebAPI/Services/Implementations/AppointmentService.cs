using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Repository;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Implementations
{
    public class AppointmentService : GenericService<Appointment>, IAppointmentService
    {
        protected IGenericRepository<Patient> _patientRepository;
        public AppointmentService(
            IGenericRepository<Patient> patientRepository,
            IGenericRepository<Appointment> repository, 
            IMapper mapper) : base(repository, mapper)
        {
            _patientRepository = patientRepository;
        }
        public async Task UpdateAppointmentByIdAsync(int id, AppointmentDTO dto)
        {
            try
            {
                var appointment = await GetByIdAsync<Appointment>(id);
                appointment.Date = dto.Date;
                
                if (appointment.Patient.Id != dto.PatientId)
                {
                    var patient = (await _patientRepository.GetByConditionAsync(patient => patient.Id == dto.PatientId)).FirstOrDefault();
                    if (patient == null)
                    {
                        throw new Exception($"there are no patient with id:  {dto.PatientId}!");
                    }

                    appointment.Patient = patient;
                }

                await _repository.UpdateAsync(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception($"cant update Appointment", ex);
            }
        }
        public async Task<int> CreateAppointmentAsync(AppointmentDTO dto)
        {
            var patient = (await _patientRepository.GetByConditionAsync(patient => patient.Id == dto.PatientId)).FirstOrDefault();

            if (patient == null)
            {
                throw new Exception($"there are no patient with id:  {dto.PatientId}!");
            }

            var appointment = new Appointment 
            {
                Date = dto.Date,
                Patient = patient,
            };

            try
            {
                await _repository.CreateAsync(appointment);
                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"cant add appointment!", ex);
            }
        }
    }
}
