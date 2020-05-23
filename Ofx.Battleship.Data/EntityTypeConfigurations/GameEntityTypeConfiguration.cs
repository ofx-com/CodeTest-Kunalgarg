using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;

namespace Ofx.Battleship.Data.EntityTypeConfigurations
{
    public class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> gameConfiguration)
        {
            gameConfiguration.ToTable("Games", BattleshipContext.Schema);

            gameConfiguration.HasKey(g => g.Id);

            gameConfiguration.Ignore(g => g.DomainEvents);

        }
    }
}
