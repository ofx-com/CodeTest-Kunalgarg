using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;

namespace Ofx.Battleship.Data.EntityTypeConfigurations
{
    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> playerConfiguration)
        {
            playerConfiguration.ToTable("Players", BattleshipContext.Schema);

            playerConfiguration.HasKey(g => g.Id);

            playerConfiguration.HasOne(p => p.Game)
                .WithMany(g => g.Players)
                .HasForeignKey(p => p.GameId);
            playerConfiguration.Ignore(g => g.DomainEvents);

        }
    }
}
