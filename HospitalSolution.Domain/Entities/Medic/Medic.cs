
using emailValidator;
using formatPassword;
using HospitalSolution.Domain.Entities.medic;
using HospitalSolution.Domain.Models;
using medicValidate;

namespace HospitalSolution.Domain.Entities.Medic
{
    public sealed class Medic : AggregateRoot<MedicId>
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public int CRMNumber { get; private set; }
        public string Specialty { get; private set; } = string.Empty;
        public string? HospitalAffiliation { get; private set; }
        public string PhoneNumber { get; private set; } = string.Empty;
        public List<MedicAddress> Addresses { get;  set; } = new List<MedicAddress>();
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }

        private Medic() : base(default) { }

        private Medic(
            MedicId id, string firstName,
            string lastName, string email,
            string password, int crmNumber,
            string specialty, string? hospitalAffiliation, string phoneNumber, List<MedicAddress> addresses)
            : base(id)
        {
            FirstNameSet(firstName);
            LastNameSet(lastName);
            EmailSet(email);
            PasswordSet(password);
            CrmNumberSet(crmNumber);
            SpecialtySet(specialty);
            HospitalAffiliationSet(hospitalAffiliation);
            PhoneNumberSet(phoneNumber);
            AddressesSet(addresses);    
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public static Medic Create(string firstName,
            string lastName, string email,
            string password, int crmNumber,
            string specialty, string? hospitalAffiliation, string phoneNumber, List<MedicAddress> addresses)
        {

            return new Medic(
                MedicId.CreateUnique(), firstName, lastName, email, password, crmNumber, specialty, hospitalAffiliation, phoneNumber, addresses
            );
        }


        private void FirstNameSet(string firstName)
        {
            FirstName = firstName;
            MedicValidate.IsNameNotNull(firstName);
        }
        private void LastNameSet(string lastName)
        {
            LastName = lastName;
            MedicValidate.IsLastNotNull(lastName);
        }
        private void EmailSet(string email)
        {
            Email = email;
            EmailValidator.IsValid(email);
        }
        private void PasswordSet(string password)
        {
            Password = password;
            FormatPassword.IsValidPassword(password);
        }
        private void CrmNumberSet(int crmNumber)
        {
            CRMNumber = crmNumber;
        }
        private void SpecialtySet(string specialty)
        {
            Specialty = specialty;
            MedicValidate.IsSpecialtyNotNull(specialty);
        }
        private void HospitalAffiliationSet(string? hospitalAffiliation){
            HospitalAffiliation = hospitalAffiliation;
        }
        private void PhoneNumberSet(string phoneNumber){
            PhoneNumber = phoneNumber;
            MedicValidate.IsPhoneNumberNotNull(phoneNumber);    
        }
        private void AddressesSet(List<MedicAddress> addresses){
            Addresses = addresses;
        }
    }
}
