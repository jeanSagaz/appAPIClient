namespace appWebAPIClient.Api.Models
{
    public class PhoneViewModel
    {
        public int PhoneId { get; set; }

        public string Number { get; set; }

        public int ClientId { get; set; }

        public virtual ClientViewModel Client { get; set; }
    }
}