﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using base_api_aspNet.Data;

#nullable disable

namespace base_api_aspNet.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230305142817_nome")]
    partial class nome
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("base_api_aspNet.Models.Base", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Altura")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.Property<DateTime?>("Criado_em")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Idade")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Bases");
                });
#pragma warning restore 612, 618
        }
    }
}
