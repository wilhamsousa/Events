using Domain.Model;
using Infra.Repository.Context.Base;
using Infra.Repository.Context.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Context.Configuration
{
    public class EventConfiguration : IModelBuilderConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Event>().HasData(EventData.Itens);
        }
    }
}
