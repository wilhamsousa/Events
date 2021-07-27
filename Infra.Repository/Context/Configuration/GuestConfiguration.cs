using Domain.Model.Entity;
using Infra.Repository.Context.Base;
using Infra.Repository.Context.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Context.Configuration
{
    public class GuestConfiguration : IModelBuilderConfiguration
    {
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Payment)
                    .IsRequired(false)
                    .HasPrecision(9, 2);

                entity.Property(e => e.EventId).IsRequired();
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Guest)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_Event");
            });

            modelBuilder.Entity<Guest>().HasData(GuestData.Itens);
        }
    }
}
