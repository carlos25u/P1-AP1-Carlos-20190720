﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P1_AP1_Carlos_20190720.DAL;

namespace P1_AP1_Carlos_20190720.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("P1_AP1_Carlos_20190720.Entidades.Aportes", b =>
                {
                    b.Property<int>("aporteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fechaAporte")
                        .HasColumnType("TEXT");

                    b.Property<int>("monto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("persona")
                        .HasColumnType("TEXT");

                    b.HasKey("aporteID");

                    b.ToTable("Aportes");
                });
#pragma warning restore 612, 618
        }
    }
}
