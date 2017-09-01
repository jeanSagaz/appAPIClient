namespace appWebAPIClient.Domain.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }

        public string Number { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
