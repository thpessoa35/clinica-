
using HospitalSolution.Domain.Appointment;


namespace HospitalSolution.Contracts.Appointments.Get.GetConsultByIdMedic
{
    public static class GetByAppointmentResponseMapper
    {
        public static List<GetByAppointmentResponse> MapFrom(IEnumerable<Appointment> appointments)
        {
            var responses = new List<GetByAppointmentResponse>();

            foreach (var appointment in appointments)
            {
                var medics = new List<Medic>();
                var patients = new List<Pacient>();

                var existingMedic = medics.FirstOrDefault(m => m.Id == appointment.Medic.Id.Id);

                if (existingMedic == null)
                {
                    medics.Add(new Medic(
                        appointment.Medic.Id.Id,
                        appointment.Medic.FirstName,
                        appointment.Medic.LastName,
                        appointment.Medic.PhoneNumber
                    ));
                }


                if (appointment.Pacient != null)
                {
                    var addresses = new List<Addresses>();
                    foreach (var address in appointment.Pacient.Enderecos)
                    {
                        addresses.Add(new Addresses(
                            address.Address,
                            address.City,
                            address.State,
                            address.ZipCode,
                            address.Number
                        ));
                    }

                    patients.Add(new Pacient(
                        appointment.Pacient.Id.Id,
                        appointment.Pacient.FirstName,
                        appointment.Pacient.LastName,
                        appointment.Pacient.TypeBlood,
                        appointment.Pacient.Cpf,
                        appointment.Pacient.PhoneNumber,
                        addresses,
                        appointment.Pacient.Created,
                        appointment.Pacient.Updated
                    ));

                }


                DateTime date = DateTime.Now;
                var response = new GetByAppointmentResponse(
                    appointment.Id.Id,
                    appointment.Status,
                    appointment.Description,
                    medics,
                    patients,
                    date
                );

                responses.Add(response);
            }

            return responses;
        }
    }
}
