
using HospitalSolution.Domain.entities.Pacient;
using HospitalSolution.Domain.Entities.Address.Entities;

using HospitalSolution.Domain.Models;

namespace pacient
{
    public sealed class Paciente : AggregateRoot<PacientId>
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string TypeBlood { get; private set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public List<PacientAddress> Enderecos { get; set; } = new List<PacientAddress>();
        public DateTime Created { get; }
        public DateTime Updated { get; private set; }

        private Paciente() : base(default) { }


        private Paciente(PacientId id, string firstName, string lastName, string cpf, string phoneNumber, string typeBlood, List<PacientAddress> enderecos)
            : base(id)
        {
            FirstNameSet(firstName);
            LastNameSet(lastName);
            TypeBloodSet(typeBlood);
            CpfSet(cpf);
            PhoneNumberSet(phoneNumber);
            AddAddresses(enderecos);
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public static Paciente Create(string firstName, string lastName, string cpf, string phoneNumber, string typeBlood, List<PacientAddress> addresses)
        {
            return new Paciente(PacientId.CreateUnique(), firstName, lastName, cpf, phoneNumber, typeBlood, addresses);
        }


        public void Put(string? firstName, string? lastName, string? cpf, string? phoneNumber, string? typeBlood, List<PacientAddress>? addresses)
        {
            if (firstName != null)
                FirstName = firstName;

            if (lastName != null)
                LastName = lastName;

            if (typeBlood != null)
                TypeBlood = typeBlood;

            if (cpf != null)
                Cpf = cpf;

            if (phoneNumber != null)
                PhoneNumber = phoneNumber;

            if (addresses != null)
                Enderecos = addresses;
        }

        internal void FirstNameSet(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First name cannot be null or empty", nameof(firstName));

            FirstName = firstName;
        }

        internal void LastNameSet(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Last name cannot be null or empty", nameof(lastName));

            LastName = lastName;
        }

        internal void TypeBloodSet(string typeBlood)
        {
            if (string.IsNullOrEmpty(typeBlood))
                throw new ArgumentException("Type blood cannot be null or empty", nameof(typeBlood));

            TypeBlood = typeBlood;
        }

        internal void CpfSet(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("CPF cannot be null or empty", nameof(cpf));

            Cpf = cpf;
        }

        internal void PhoneNumberSet(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentException("Phone number cannot be null or empty", nameof(phoneNumber));

            PhoneNumber = phoneNumber;
        }

        internal void AddAddresses(List<PacientAddress> addresses)
        {
            Enderecos = addresses;
        }
    }
}
