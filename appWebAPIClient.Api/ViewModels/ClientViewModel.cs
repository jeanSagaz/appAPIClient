using appWebAPIClient.Domain.Enum;
using System.Collections.Generic;

namespace appWebAPIClient.Api.Models
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }

        public string Cpf { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PhoneViewModel> Phones { get; set; }
    }
}