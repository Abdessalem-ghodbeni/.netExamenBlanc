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
    public class CompteConfiguration:IEntityTypeConfiguration<Compte>
    {
         

        public void Configure(EntityTypeBuilder<Compte> builder)
        {
  //          builder.HasOne(compte => compte.Banque)
  //.WithMany(compte => compte.CompteList)
  //.HasForeignKey(compte => compte.BanqueFk);
  
        }
    }
}
