﻿// <auto-generated />
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations.PostgreSqlDb
{
    [DbContext(typeof(PostgreSqlDbContext))]
    [Migration("20230113233847_DB Initialize")]
    partial class DBInitialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.SmartContract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AbiSerialized")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Abi");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Bytecode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Chain")
                        .HasColumnType("integer");

                    b.Property<string>("ParametersSerialized")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Parameters");

                    b.HasKey("Id");

                    b.ToTable("SmartContract");
                });
#pragma warning restore 612, 618
        }
    }
}
