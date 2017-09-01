using appWebAPIClient.Common.Validation;
using appWebAPIClient.Domain.Enum;
using System.Collections.Generic;

namespace appWebAPIClient.Domain.Models
{
    public class Client
    {
        protected Client() { }        
        public Client(string cpf, string address, string name, string email, MaritalStatus maritalStatus, ICollection<Phone> phones)
        {
            this.Cpf = cpf;
            this.Address = address;
            this.Name = name;
            this.Email = email;
            this.MaritalStatus = maritalStatus;
            this.Phones = phones;
        }

        public Client(int clientId, string cpf, string address, string name, string email, MaritalStatus maritalStatus, ICollection<Phone> phones)
        {
            this.ClientId = clientId;
            this.Cpf = cpf;
            this.Address = address;
            this.Name = name;
            this.Email = email;
            this.MaritalStatus = maritalStatus;
            this.Phones = phones;
        }

        public int ClientId { get; private set; }

        public string Cpf { get; private set; }

        public string Address { get; private set; }

        public string Name { get; private set; }

        public string Email { get; set; }
        
        public MaritalStatus MaritalStatus { get; private set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public void SetClientId(int clientId)
        {
            this.ClientId = clientId;
        }

        public void SetAddress(string address)
        {
            this.Address = address;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
        
        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetMaritalStatus(MaritalStatus maritalStatus)
        {
            this.MaritalStatus = maritalStatus;
        }

        public void SetPhones(ICollection<Phone> phones)
        {
            this.Phones = phones;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Address, 3, 500, "Endereço deve ter entre 3 e 500 caracteres.");
            AssertionConcern.AssertArgumentLength(this.Name, 3, 100, "Nome deve ter entre 3 e 100 caracteres.");
            AssertionConcern.AssertArgumentLength(this.Email, 3, 100, "E-mail deve ter entre 3 e 100 caracteres.");
            EmailAssertionConcern.AssertIsValid(this.Email);
            AssertionConcern.AssertArgumentZero(this.MaritalStatus, "Estado civil deve ser informado.");
            AssertionConcern.AssertArgumentNotNull(this.MaritalStatus, "Estado civil deve ser informado.");
            //AssertionConcern.AssertArgumentNotNull(this.Phones, "Telefone deve ser informado.");
        }

        public bool ValidateCpf(string cpf)
        {
            AssertionConcern.AssertArgumentNotNull(cpf, "CPF deve ser informado.");
            bool valido = Utils.ValidarCPF(cpf);

            return valido;            
        }
    }
}
