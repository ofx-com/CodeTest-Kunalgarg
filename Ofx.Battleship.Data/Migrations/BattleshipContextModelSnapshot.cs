﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ofx.Battleship.Data;

namespace Ofx.Battleship.Data.Migrations
{
    [DbContext(typeof(BattleshipContext))]
    partial class BattleshipContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BoardX")
                        .HasColumnType("int");

                    b.Property<int>("BoardY")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("NextTurnPlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Games","Ofx");
                });

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players","Ofx");
                });

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.Ship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DimensionX")
                        .HasColumnType("int");

                    b.Property<int>("DimensionY")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Ships","Ofx");
                });

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.ShipPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ShipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("ShipParts","Ofx");
                });

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.Player", b =>
                {
                    b.HasOne("Ofx.Battleship.Domain.Aggregates.GameAggregate.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.Ship", b =>
                {
                    b.HasOne("Ofx.Battleship.Domain.Aggregates.GameAggregate.Player", "Player")
                        .WithMany("Ships")
                        .HasForeignKey("PlayerId");

                    b.OwnsOne("Ofx.Battleship.Domain.Aggregates.GameAggregate.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("ShipId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("X")
                                .HasColumnType("int");

                            b1.Property<int>("Y")
                                .HasColumnType("int");

                            b1.HasKey("ShipId");

                            b1.ToTable("Ships");

                            b1.WithOwner()
                                .HasForeignKey("ShipId");
                        });
                });

            modelBuilder.Entity("Ofx.Battleship.Domain.Aggregates.GameAggregate.ShipPart", b =>
                {
                    b.HasOne("Ofx.Battleship.Domain.Aggregates.GameAggregate.Ship", "Ship")
                        .WithMany("ShipParts")
                        .HasForeignKey("ShipId");

                    b.OwnsOne("Ofx.Battleship.Domain.Aggregates.GameAggregate.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("ShipPartId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("X")
                                .HasColumnType("int");

                            b1.Property<int>("Y")
                                .HasColumnType("int");

                            b1.HasKey("ShipPartId");

                            b1.ToTable("ShipParts");

                            b1.WithOwner()
                                .HasForeignKey("ShipPartId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
