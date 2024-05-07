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
    public class TransactionTransferConfiguration : IEntityTypeConfiguration<TransactionTransfert>
    {
        public void Configure(EntityTypeBuilder<TransactionTransfert> builder)
        {
            builder.ToTable("TransactionTransfert"); // Nom de la table pour la classe TransactionTransfert
        }
    }
}
