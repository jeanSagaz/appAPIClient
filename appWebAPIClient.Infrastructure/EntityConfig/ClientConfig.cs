using appWebAPIClient.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace appWebAPIClient.Infrastructure.EntityConfig
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            ToTable("Clients");

            HasKey(c => c.ClientId);

            Property(c => c.Cpf)
                .HasColumnAnnotation(
                    //cria um índice no banco de dados do tipo único
                    IndexAnnotation.AnnotationName,                    
                    new IndexAnnotation(new IndexAttribute("IX_CPF", 1) { IsUnique = true }))
                .IsRequired()                
                .HasMaxLength(20);

            Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(500);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.MaritalStatus)
                .IsRequired();
        }

        
    }
}
