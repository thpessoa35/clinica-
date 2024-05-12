
using HospitalSolution.Domain.Models;

namespace HospitalSolution.Domain.Appointment.valueObject
{
    public class AgendAppointment : ValueObject
    {
        public DateTime ConsultationDateTime { get; set; } 

        private AgendAppointment(DateTime consultationDateTime)
        {
            ConsultationDateTimeSet(consultationDateTime);
        }
        public static AgendAppointment Create(DateTime consultationDateTime)
        {
            ValidateDateTime(consultationDateTime);
            return new AgendAppointment(consultationDateTime);
        }

        private void ConsultationDateTimeSet(DateTime consultationDateTime)
        {
            
            ConsultationDateTime = consultationDateTime;
        }

        public static AgendAppointment GetAgend(DateTime dateTime){
            return new AgendAppointment(dateTime);
        }

        private static void ValidateDateTime(DateTime consultationDateTime)
        {
            if (consultationDateTime <  DateTime.Now)
            {
                throw new Exception("Cannot schedule an appointment for a past date.");
            }
        }

        public override IEnumerable<object> GetEqualsComponets()
        {
            yield return ConsultationDateTime;
        }
    }
}
