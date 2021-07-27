using Domain.Model.Entity;
using Infra.Repository.Context.Base;
using Infra.Repository.Context.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Context.Configuration
{
    public class EventConfiguration : IModelBuilderConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observation)
                    .IsRequired(false)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PriceWithDrink)
                    .IsRequired()
                    .HasPrecision(9, 2);

                entity.Property(e => e.PriceWithoutDrink)
                    .IsRequired()
                    .HasPrecision(9, 2);

            });

            modelBuilder.Entity<Event>().HasData(EventData.Itens);
        }
    }
}
