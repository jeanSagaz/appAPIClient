using appWebAPIClient.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace appWebAPIClient.Infrastructure.EntityConfig
{
    public class PhoneConfig : EntityTypeConfiguration<Phone>
    {
        public PhoneConfig()
        {
            ToTable("Phones");

            HasKey(p => p.PhoneId);

            Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(20);

            HasRequired(c => c.Client)
                .WithMany(p => p.Phones)
                .HasForeignKey(p => p.ClientId)
                //habilita o delete cascade
                .WillCascadeOnDelete();
        }        
    }
}
