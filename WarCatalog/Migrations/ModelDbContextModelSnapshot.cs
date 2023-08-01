﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WarCatalog;

#nullable disable

namespace WarCatalog.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    partial class ModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WarCatalog.Models.Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("TypeName")
                        .HasColumnType("text")
                        .HasColumnName("typename");

                    b.HasKey("ID");

                    b.ToTable("types", (string)null);
                });

            modelBuilder.Entity("WarCatalog.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("text")
                        .HasColumnName("photourl");

                    b.Property<int>("TypeID")
                        .HasColumnType("integer")
                        .HasColumnName("typeid");

                    b.HasKey("ID");

                    b.HasIndex("TypeID");

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("WarCatalog.Models.Vehicle", b =>
                {
                    b.HasOne("WarCatalog.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
