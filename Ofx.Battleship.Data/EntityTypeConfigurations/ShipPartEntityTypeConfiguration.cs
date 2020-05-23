using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;

namespace Ofx.Battleship.Data.EntityTypeConfigurations
{
    public class ShipPartEntityTypeConfiguration : IEntityTypeConfiguration<ShipPart>
    {
        public void Configure(EntityTypeBuilder<ShipPart> shipPartConfiguration)
        {
            shipPartConfiguration.ToTable("ShipParts", BattleshipContext.Schema);

            shipPartConfiguration.OwnsOne(s => s.Location);

            shipPartConfiguration.HasOne(s => s.Ship)
                .WithMany(s => s.ShipParts)
                .HasForeignKey(s => s.ShipId);

        }
    }
}
