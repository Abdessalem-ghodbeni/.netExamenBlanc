using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class TransactionRetraitConfiguration : IEntityTypeConfiguration<TransactionRetrait>
    {
        public void Configure(EntityTypeBuilder<TransactionRetrait> builder)
        {
            builder.ToTable("TransactionRetrait"); // Nom de la table pour la classe TransactionTransfert
        }
    }
}
