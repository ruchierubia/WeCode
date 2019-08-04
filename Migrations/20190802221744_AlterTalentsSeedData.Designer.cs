﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeCode.Models;

namespace WeCode.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20190802221744_AlterTalentsSeedData")]
    partial class AlterTalentsSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeCode.Models.Talent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Skills");

                    b.HasKey("Id");

                    b.ToTable("Talents");

                    b.HasData(
                        new { Id = 1, Email = "KingJames@gmail.com", Name = "Lebron James", Skills = 4 },
                        new { Id = 2, Email = "theBrow@gmail.com", Name = "Anthony Davis", Skills = 1 }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}