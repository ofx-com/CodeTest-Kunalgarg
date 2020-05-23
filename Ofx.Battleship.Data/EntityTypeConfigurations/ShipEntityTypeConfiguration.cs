using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;

namespace Ofx.Battleship.Data.EntityTypeConfigurations
{
    public class ShipEntityTypeConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> shipConfiguration)
        {
            shipConfiguration.ToTable("Ships", BattleshipContext.Schema);

            shipConfiguration.HasKey(g => g.Id);

            shipConfiguration.OwnsOne(g => g.Location);                      
            
            shipConfiguration.HasOne(p => p.Player)
                .WithMany(p => p.Ships)
                .HasForeignKey(s => s.PlayerId);

            shipConfiguration.Ignore(g => g.DomainEvents);

        }
    }
}
