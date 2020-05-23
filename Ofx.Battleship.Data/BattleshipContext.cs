using MediatR;
using Microsoft.EntityFrameworkCore;
using Ofx.Battleship.Data.EntityTypeConfigurations;
using Ofx.Battleship.Domain.Aggregates.GameAggregate;
using Ofx.Battleship.Domain.Common;
using Ofx.Battleship.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ofx.Battleship.Data
{
    public class BattleshipContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public BattleshipContext(DbContextOptions<BattleshipContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public const string Schema = "Ofx";

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<ShipPart> ShipParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShipEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShipPartEntityTypeConfiguration());
        }

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var domainEntities = this.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
               .SelectMany(x => x.Entity.DomainEvents)
               .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());
            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
